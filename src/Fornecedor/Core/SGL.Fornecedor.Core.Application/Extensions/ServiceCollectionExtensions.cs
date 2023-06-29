#nullable disable

using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGL.Fornecedor.Core.Application.AutoMappings;
using SGL.Fornecedor.Core.Application.Commands.Fornecedor;
using SGL.Fornecedor.Core.Application.Consumers;
using SGL.Fornecedor.Core.Application.Handlers;
using SGL.Fornecedor.Core.Application.Models;
using SGL.Fornecedor.Core.Application.Queries.Fornecedor;
using SGL.MessageQueue.Configuration;
using SGL.MessageQueue.Extensions;
using SGL.MessageQueue.Models;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Util;
using System.Reflection;
using IPublisher = SGL.MessageQueue.Configuration.IPublisher;
namespace SGL.Fornecedor.Core.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // AutoMapping
            services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()), typeof(object));

            // Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Query
            services.AddScoped<IRequestHandler<ObterFornecedorPorIdQuery, FornecedorModel>, FornecedorQueryHandler>();
            services.AddScoped<IRequestHandler<ObterTodosFornecedoresQuery, IEnumerable<FornecedorModel>>, FornecedorQueryHandler>();

            // Command
            services.AddScoped<IRequestHandler<AdicionarFornecedorCommand, DefaultResult>, FornecedorCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarFornecedorCommand, DefaultResult>, FornecedorCommandHandler>();

            // RabbitMQ
            services.AddRabbitMq(configuration);
        }

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var builder = new BuilderBus(configuration["RabbitMq:ConnectionString"])
            {
                Consumers = new HashSet<Consumer>
                {
                    new Consumer(
                        queue: configuration["RabbitMq:ConsumerFornecedor"],
                        typeConsumer: typeof(ConsumerFornecedor),
                        quorumQueue: true
                    )
                },

                Publishers = new HashSet<IPublisher>
                {
                    new Publisher<RequestIn>(queue: configuration["RabbitMq:ConsumerFornecedor"]),
                },

                Retry = new Retry(retryCount: 3, interval: TimeSpan.FromSeconds(60))
            };
            services.AddEventBus(builder);
        }
    }
}
