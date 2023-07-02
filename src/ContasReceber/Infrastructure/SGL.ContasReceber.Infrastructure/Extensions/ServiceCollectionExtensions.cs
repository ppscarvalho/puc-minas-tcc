#nullable disable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGL.ContasReceber.Core.Application.Extensions;
using SGL.ContasReceber.Core.Application.Interfaces.Repositories.Domain;
using SGL.ContasReceber.Infrastructure.DbContexts;
using SGL.ContasReceber.Infrastructure.Repositories;
using SGL.Resource.Data;
using SGL.Resource.Messagens.CommonMessage.Notifications;

namespace SGL.ContasReceber.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationLayer(configuration);
            services.AddDatabasePersistence(configuration);

            // Repositories
            services.AddRepositories();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Context
            services.AddScoped<ContasReceberDbContext>();
            services.AddScoped<IUnitOfWork, ContasReceberDbContext>();
        }

        private static void AddDatabasePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContasReceberDbContext>(options =>
                options.UseMySQL(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)
                ),
                ServiceLifetime.Scoped);
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IContasReceberRepository, ContasReceberRepository>();
        }
    }
}
