using Jil;
using Microsoft.Extensions.Logging;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Core.Implementations;
using StackExchange.Redis.Extensions.Jil;
using System.Collections.Generic;
using System.Linq;
using YhtTicket.Common.Redis.Configuration;

namespace YhtTicket.Common.Redis
{
    public class RedisClientFactory : IRedisClientFactory
    {
        private readonly IRedisConfig _redisConfig;
        private readonly ILogger<RedisClientFactory> _logger;

        private IRedisCacheClient _redisCacheClient;

        public RedisClientFactory(IRedisConfig redisConfig, ILogger<RedisClientFactory> logger)
        {
            _redisConfig = redisConfig;
            _logger = logger;
        }

        public IRedisCacheClient Connect()
        {
            if (_redisCacheClient == null)
            {
                InitializeConnectionMultiplexer();
            }

            return _redisCacheClient;
        }

        private void InitializeConnectionMultiplexer()
        {
            var redisConfiguration = new RedisConfiguration
            {
                Password = _redisConfig.RedisPassword,
                AbortOnConnectFail = false,
                ConnectTimeout = 10000,
                AllowAdmin = true,
                Ssl = false,
                SyncTimeout = 3000,
            };

            var endpoints = _redisConfig.RedisEndpoints.Split(',')
                .Where(x => string.IsNullOrWhiteSpace(x) is false)
                .Select(x => x.Trim());

            var list = new List<RedisHost>();
            foreach (var endpoint in endpoints)
            {
                var splitted = endpoint.Split(':');
                list.Add(new RedisHost
                {
                    Host = splitted[0],
                    Port = int.Parse(splitted[1]),
                });
            }

            redisConfiguration.Hosts = list.ToArray();

            var connectionPoolManager = new RedisCacheConnectionPoolManager(redisConfiguration);

            var options = new Options(excludeNulls: true);

            _redisCacheClient = new RedisCacheClient(connectionPoolManager, new JilSerializer(options), redisConfiguration);
        }
    }
}
