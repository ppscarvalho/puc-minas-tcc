#nullable disable

using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGL.Cliente.Core.Application.AutoMappings;
using SGL.Cliente.Core.Application.Commands.Cliente;
using SGL.Cliente.Core.Application.Consumers;
using SGL.Cliente.Core.Application.Handlers;
using SGL.Cliente.Core.Application.Models;
using SGL.Cliente.Core.Application.Queries.Cliente;
using SGL.MessageQueue.Configuration;
using SGL.MessageQueue.Extensions;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Util;
using System.Reflection;

namespace SGL.Cliente.Core.Application.Extensions
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
            services.AddScoped<IRequestHandler<ObterClientePorIdQuery, ClienteModel>, ClienteQueryHandler>();
            services.AddScoped<IRequestHandler<ObterTodosClientesQuery, IEnumerable<ClienteModel>>, ClienteQueryHandler>();

            // Command
            services.AddScoped<IRequestHandler<AdicionarClienteCommand, DefaultResult>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarClienteCommand, DefaultResult>, ClienteCommandHandler>();

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
                        queue: configuration["RabbitMq:ConsumerCliente"],
                        typeConsumer: typeof(ConsumerCliente),
                        quorumQueue: true
                    )
                },

                //Publishers = new HashSet<IPublisher>
                //{
                //    new Publisher<RequestIn>(queue: configuration["RabbitMq:ConsumerCliente"])
                //},

                Retry = new Retry(retryCount: 3, interval: TimeSpan.FromSeconds(60))
            };
            services.AddEventBus(builder);
        }
    }
}
