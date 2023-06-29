using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RedLockNet;
using RedLockNet.SERedis;
using RedLockNet.SERedis.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGL.Resource.Abstractions;
using SGL.Resource.Cache;

namespace SGL.Resource.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<CacheService> _logger;
        private readonly ConnectionMultiplexer _connection;
        private readonly IDatabase _database;
        private readonly JsonSerializerSettings _serializerSettings;
        public IDistributedLockFactory LockFactory { get; }

        public CacheService(IRedisConnection redisConnection, IMemoryCache memoryCache, ILogger<CacheService> logger)
        {
            _memoryCache = memoryCache;
            _logger = logger;
            _connection = redisConnection.GetConnection();
            _database = _connection.GetDatabase();
            _serializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            LockFactory = RedLockFactory.Create(new List<RedLockMultiplexer> { _connection });
        }

        public async Task RemoveAsync(string key)
        {
            _logger.LogInformation("{ServiceName}: {MethodName} remove [key]: {Key}", nameof(CacheService), nameof(RemoveAsync), key);

            if (!_connection.IsConnected) _memoryCache.Remove(key);
            else await _database.KeyDeleteAsync(key);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            _logger.LogInformation("{ServiceName}: {MethodName} get [key]: {Key}", nameof(CacheService), nameof(GetAsync), key);

            if (!_connection.IsConnected) return _memoryCache.Get<T>(key);
            var json = await _database.StringGetAsync(key);
            return string.IsNullOrEmpty(json) ? default : JsonConvert.DeserializeObject<T>(json);
        }

        public T Get<T>(string key)
        {
            _logger.LogInformation("{ServiceName}: {MethodName} get [key]: {Key}", nameof(CacheService), nameof(GetAsync), key);

            if (!_connection.IsConnected) return _memoryCache.Get<T>(key);
            var json = _database.StringGet(key);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public bool TryGetValue<T>(string key, out T value)
        {
            _logger.LogInformation("{ServiceName}: {MethodName} get [key]: {Key}", nameof(CacheService), nameof(TryGetValue), key);

            value = default;
            if (!_connection.IsConnected) return _memoryCache.TryGetValue(key, out value);
            var hasCache = _database.KeyExists(key);
            if (hasCache)
                value = Get<T>(key);
            return hasCache;
        }

        public async Task SetAsync<T>(string key, T data, TimeSpan duration)
        {
            _logger.LogInformation("{ServiceName}: {MethodName} set [key]: {Key}", nameof(CacheService), nameof(SetAsync), key);

            var json = JsonConvert.SerializeObject(data, _serializerSettings);

            if (!_connection.IsConnected) _memoryCache.Set(key, json);
            else await _database.StringSetAsync(key, json, duration);
        }
    }
}
