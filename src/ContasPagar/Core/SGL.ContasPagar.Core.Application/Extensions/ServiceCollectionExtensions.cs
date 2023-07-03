#nullable disable

using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGL.ContasPagar.Core.Application.AutoMappings;
using SGL.ContasPagar.Core.Application.Commands.ContasPagar;
using SGL.ContasPagar.Core.Application.Handlers;
using SGL.ContasPagar.Core.Application.Queries.ContasPagar;
using SGL.MessageQueue.Configuration;
using SGL.MessageQueue.Extensions;
using SGL.MessageQueue.Models;
using SGL.MessageQueue.Models.ContasPagar;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Util;
using System.Reflection;
using IPublisher = SGL.MessageQueue.Configuration.IPublisher;

namespace SGL.ContasPagar.Core.Application.Extensions
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

            services.AddScoped<IRequestHandler<ObterContasPagarPorIdQuery, ResponseContasPagarOut>, ContasPagareQueryHandler>();
            services.AddScoped<IRequestHandler<ObterTodasContasPagarQuery, IEnumerable<ResponseContasPagarOut>>, ContasPagareQueryHandler>();

            // Command
            services.AddScoped<IRequestHandler<AdicionarContasPagarCommand, DefaultResult>, ContasPagarCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarContasPagarCommand, DefaultResult>, ContasPagarCommandHandler>();

            // RabbitMQ
            services.AddRabbitMq(configuration);
        }

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var builder = new BuilderBus(configuration["RabbitMq:ConnectionString"])
            {
                //Consumers = new HashSet<Consumer>
                //{
                //    new Consumer(
                //        queue: configuration["RabbitMq:ConsumerContasPagar"],
                //        typeConsumer: typeof(RPCConsumerContasPagare),
                //        quorumQueue: true
                //    )
                //},

                Publishers = new HashSet<IPublisher>
                {
                    new Publisher<RequestIn>(queue: configuration["RabbitMq:ConsumerContasPagar"]),
                },

                Retry = new Retry(retryCount: 3, interval: TimeSpan.FromSeconds(60))
            };
            services.AddEventBus(builder);
        }
    }
}
