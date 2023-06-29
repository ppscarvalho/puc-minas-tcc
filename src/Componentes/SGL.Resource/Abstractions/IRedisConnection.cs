using StackExchange.Redis;

namespace SGL.Resource.Abstractions
{
    public interface IRedisConnection
    {
        void ForceReconnect();
        ConnectionMultiplexer GetConnection();
    }
}
