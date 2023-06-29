#nullable disable

using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGL.MessageQueue.Configuration;
using SGL.MessageQueue.Extensions;
using SGL.MessageQueue.Models;
using SGL.MessageQueue.Models.Produto;
using SGL.Produto.Core.Application.AutoMappings;
using SGL.Produto.Core.Application.Commands.Produto;
using SGL.Produto.Core.Application.Handlers;
using SGL.Produto.Core.Application.Queries.Produto;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Util;
using System.Reflection;
using IPublisher = SGL.MessageQueue.Configuration.IPublisher;
namespace SGL.Produto.Core.Application.Extensions
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
            services.AddScoped<IRequestHandler<ObterProdutoPorIdQuery, ResponseProdutoOut>, ProdutoQueryHandler>();
            services.AddScoped<IRequestHandler<ObterTodosProdutosQuery, IEnumerable<ResponseProdutoOut>>, ProdutoQueryHandler>();

            // Command
            services.AddScoped<IRequestHandler<AdicionarProdutoCommand, DefaultResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarProdutoCommand, DefaultResult>, ProdutoCommandHandler>();

            // RabbitMQ
            services.AddRabbitMq(configuration);
        }

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var builder = new BuilderBus(configuration["RabbitMq:ConnectionString"])
            {
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
