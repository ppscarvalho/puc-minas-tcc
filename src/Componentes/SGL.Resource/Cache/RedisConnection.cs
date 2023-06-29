using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using SGL.Resource.Abstractions;
using SGL.Resource.Cache;

namespace SGL.Resource.Cache
{
    public class RedisConnection : IRedisConnection
    {
        private readonly ILogger<RedisConnection> _logger;
        private static string _connectionString;
        private readonly object _reconnectLock;
        private static DateTimeOffset _lastReconnectTime;
        private static DateTimeOffset _firstError;
        private static DateTimeOffset _previousError;
        private static Lazy<ConnectionMultiplexer> _multiplexer;

        // In general, let StackExchange.Redis handle most reconnects, 
        // so limit the frequency of how often this will actually reconnect.
        private readonly TimeSpan _reconnectMinFrequency;

        // if errors continue for longer than the below threshold, then the 
        // multiplexer seems to not be reconnecting, so re-create the multiplexer
        private readonly TimeSpan _reconnectErrorThreshold;

        // Connection        
        private readonly ConnectionMultiplexer _connection;

        /// <summary>
        /// Get Connection
        /// </summary>
        /// <returns></returns>
        public ConnectionMultiplexer GetConnection() => _connection;

        /// <summary>
        /// Ctor
        /// </summary>
        public RedisConnection(IOptions<CacheConfiguration> options, ILogger<RedisConnection> logger)
        {
            _logger = logger;
            _connectionString = options.Value.RedisConnectionString;
            _lastReconnectTime = DateTimeOffset.MinValue;
            _firstError = DateTimeOffset.MinValue;
            _previousError = DateTimeOffset.MinValue;
            _reconnectLock = new object();
            _reconnectMinFrequency = TimeSpan.FromSeconds(60);
            _reconnectErrorThreshold = TimeSpan.FromSeconds(30);
            _multiplexer = CreateMultiplexer();
            _connection = _multiplexer.Value;
        }

        /// <summary>
        /// Force a new ConnectionMultiplexer to be created.  
        /// NOTES: 
        ///     1. Users of the ConnectionMultiplexer MUST handle ObjectDisposedExceptions, which can now happen as a result of calling ForceReconnect()
        ///     2. Don't call ForceReconnect for Timeouts, just for RedisConnectionExceptions or SocketExceptions
        ///     3. Call this method every time you see a connection exception, the code will wait to reconnect:
        ///         a. for at least the "ReconnectErrorThreshold" time of repeated errors before actually reconnecting
        ///         b. not reconnect more frequently than configured in "ReconnectMinFrequency"
        /// </summary>    
        public void ForceReconnect()
        {
            var utcNow = DateTimeOffset.UtcNow;
            var previousReconnect = _lastReconnectTime;
            var elapsedSinceLastReconnect = utcNow - previousReconnect;

            // If multiple threads call ForceReconnect at the same time, we only want to honor one of them.
            if (elapsedSinceLastReconnect <= _reconnectMinFrequency) return;

            lock (_reconnectLock)
            {
                utcNow = DateTimeOffset.UtcNow;
                elapsedSinceLastReconnect = utcNow - _lastReconnectTime;

                if (_firstError == DateTimeOffset.MinValue)
                {
                    // We haven't seen an error since last reconnect, so set initial values.
                    _firstError = utcNow;
                    _previousError = utcNow;
                    return;
                }

                if (elapsedSinceLastReconnect < _reconnectMinFrequency)
                    return; // Some other thread made it through the check and the lock, so nothing to do.

                var elapsedSinceFirstError = utcNow - _firstError;
                var elapsedSinceMostRecentError = utcNow - _previousError;

                var shouldReconnect =
                    elapsedSinceFirstError >=
                    _reconnectErrorThreshold // make sure we gave the multiplexer enough time to reconnect on its own if it can
                    && elapsedSinceMostRecentError <=
                    _reconnectErrorThreshold; //make sure we aren't working on stale data (e.g. if there was a gap in errors, don't reconnect yet).

                // Update the previousError timestamp to be now (e.g. this reconnect request)
                _previousError = utcNow;

                if (!shouldReconnect) return;

                _firstError = DateTimeOffset.MinValue;
                _previousError = DateTimeOffset.MinValue;

                var oldMultiplexer = _multiplexer;
                CloseMultiplexer(oldMultiplexer);
                _multiplexer = CreateMultiplexer();
                _lastReconnectTime = utcNow;
            }
        }

        /// <summary>
        /// CreateMultiplexer
        /// </summary>
        /// <returns></returns>
        private static Lazy<ConnectionMultiplexer> CreateMultiplexer()
            => new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(_connectionString));

        /// <summary>
        /// CloseMultiplexer
        /// </summary>
        /// <param name="oldMultiplexer"></param>
        private void CloseMultiplexer(Lazy<ConnectionMultiplexer> oldMultiplexer)
        {
            if (oldMultiplexer == null) return;

            try
            {
                oldMultiplexer.Value.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ServiceName}: {MethodName} message: {Message}", nameof(RedisConnection), nameof(CloseMultiplexer), ex.Message);
            }
        }
    }
}
