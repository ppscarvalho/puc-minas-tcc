#nullable disable

using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGL.ContasReceber.Core.Application.AutoMappings;
using SGL.ContasReceber.Core.Application.Commands.ContasReceber;
using SGL.ContasReceber.Core.Application.Handlers;
using SGL.ContasReceber.Core.Application.Queries.ContasReceber;
using SGL.MessageQueue.Configuration;
using SGL.MessageQueue.Extensions;
using SGL.MessageQueue.Models;
using SGL.MessageQueue.Models.ContasReceber;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Util;
using System.Reflection;
using IPublisher = SGL.MessageQueue.Configuration.IPublisher;

namespace SGL.ContasReceber.Core.Application.Extensions
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

            services.AddScoped<IRequestHandler<ObterContasReceberPorIdQuery, ResponseContasReceberOut>, ContasRecebereQueryHandler>();
            services.AddScoped<IRequestHandler<ObterTodasContasReceberQuery, IEnumerable<ResponseContasReceberOut>>, ContasRecebereQueryHandler>();

            // Command
            services.AddScoped<IRequestHandler<AdicionarContasReceberCommand, DefaultResult>, ContasReceberCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarContasReceberCommand, DefaultResult>, ContasReceberCommandHandler>();

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
                //        queue: configuration["RabbitMq:ConsumerContasReceber"],
                //        typeConsumer: typeof(RPCConsumerContasRecebere),
                //        quorumQueue: true
                //    )
                //},

                Publishers = new HashSet<IPublisher>
                {
                    new Publisher<RequestIn>(queue: configuration["RabbitMq:ConsumerContasReceber"]),
                },

                Retry = new Retry(retryCount: 3, interval: TimeSpan.FromSeconds(60))
            };
            services.AddEventBus(builder);
        }
    }
}
