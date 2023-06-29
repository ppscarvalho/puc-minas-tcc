using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Threading;
using SGL.Resource.Abstractions;
using SGL.Resource.Cache;

namespace SGL.Resource.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddJCACache(this IServiceCollection services, IConfiguration configuration, string sectionCacheConfig = "CacheConfiguration", CacheConfiguration cacheConfiguration = null)
        {
            services.AddOptions();

            if (cacheConfiguration is null)
            {
                cacheConfiguration = new CacheConfiguration();
                var sectionConfigurationCacheConfig = configuration.GetSection(sectionCacheConfig);
                services.Configure<CacheConfiguration>(sectionConfigurationCacheConfig);
                sectionConfigurationCacheConfig.Bind(cacheConfiguration);
            }
            else
            {
                services.Configure<CacheConfiguration>(o =>
                {
                    o.RedisConnectionString = cacheConfiguration.RedisConnectionString;
                    o.CompletionPortThreads = cacheConfiguration.CompletionPortThreads;
                    o.WorkerThreads = cacheConfiguration.WorkerThreads;
                });
            }

            services.AddMemoryCache();
            services.TryAddTransient<IRedisConnection, RedisConnection>();
            services.TryAddTransient<ICacheService, CacheService>();

            if (cacheConfiguration.WorkerThreads > 0 && cacheConfiguration.CompletionPortThreads > 0)
                ThreadPool.SetMinThreads(cacheConfiguration.WorkerThreads, cacheConfiguration.CompletionPortThreads);
        }
    }
}
