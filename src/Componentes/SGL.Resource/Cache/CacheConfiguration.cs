namespace SGL.Resource.Cache
{
    public class CacheConfiguration
    {
        public string? RedisConnectionString { get; set; }
        public int WorkerThreads { get; set; }
        public int CompletionPortThreads { get; set; }
    }
}
