using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Threading.Tasks;

namespace YhtTicket.Common.Redis
{
    public class RedisCacheManager : IRedisCacheManager
    {
        private readonly IRedisDatabase _redisDatabase;
        private readonly ILogger<RedisCacheManager> _logger;

        public RedisCacheManager(ILogger<RedisCacheManager> logger, IRedisClientFactory redisClientFactory, int dbNumber = 0)
        {
            _logger = logger;
            _redisDatabase = redisClientFactory.Connect().GetDb(dbNumber);
        }

        public async Task AddAsync<T>(string key, T value, TimeSpan ttl)
        {
            try
            {
                await _redisDatabase.Database.StringSetAsync(key, JsonConvert.SerializeObject(value), ttl);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error while adding cache to {key}");
                throw;
            }
        }

        public async Task<T> GetAsync<T>(string key)
        {
            try
            {
                var json = await _redisDatabase.Database.StringGetAsync(key);
                if (string.IsNullOrEmpty(json) is false)
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }

                return default;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error while getting cache from {key}");
                throw;
            }
        }

        public async Task RemoveAsync<T>(string key)
        {
            try
            {
                await _redisDatabase.RemoveAsync(key);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error while removing cache at {key}");
                throw;
            }
        }
    }
}
