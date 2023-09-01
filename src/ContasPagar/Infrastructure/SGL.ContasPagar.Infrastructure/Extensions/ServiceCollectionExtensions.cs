#nullable disable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGL.ContasPagar.Core.Application.Extensions;
using SGL.ContasPagar.Core.Application.Interfaces.Repositories.Domain;
using SGL.ContasPagar.Infrastructure.DbContexts;
using SGL.ContasPagar.Infrastructure.Repositories;
using SGL.Resource.Data;
using SGL.Resource.Messagens.CommonMessage.Notifications;

namespace SGL.ContasPagar.Infrastructure.Extensions
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
            services.AddScoped<ContasPagarDbContext>();
            services.AddScoped<IUnitOfWork, ContasPagarDbContext>();
        }

        private static void AddDatabasePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContasPagarDbContext>(options =>
                options.UseMySQL(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)
                ),
                ServiceLifetime.Scoped);
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IContasPagarRepository, ContasPagarRepository>();
        }
    }
}
