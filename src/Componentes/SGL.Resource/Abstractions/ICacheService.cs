using RedLockNet;
using System;
using System.Threading.Tasks;

namespace SGL.Resource.Abstractions
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T data, TimeSpan duration);
        bool TryGetValue<T>(string key, out T value);
        Task RemoveAsync(string key);
        IDistributedLockFactory LockFactory { get; }
    }
}
