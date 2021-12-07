using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Core.Implementations;
using StackExchange.Redis.Extensions.Jil;
using YhtTicket.Common.Redis.Configuration;

namespace YhtTicket.Common.Redis.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConfig = ReadConfiguration(configuration);

            if (string.IsNullOrWhiteSpace(redisConfig.RedisEndpoints))
            {
                throw new System.ApplicationException("Invalid Redis Configuration");
            }

            services.AddSingleton<IRedisConfig>(redisConfig);
            services.AddSingleton<IRedisCacheManager, RedisCacheManager>();
            services.AddSingleton<IRedisCacheConnectionPoolManager, RedisCacheConnectionPoolManager>();
            services.AddSingleton<ISerializer, JilSerializer>();
            services.AddSingleton<RedisConfiguration>();
            services.AddSingleton<IRedisCacheClient, RedisCacheClient>();
            services.AddSingleton<IRedisClientFactory, RedisClientFactory>();
        }

        private static RedisConfig ReadConfiguration(IConfiguration configuration)
        {
            var config = new RedisConfig
            {
                RedisEndpoints = configuration.GetValue<string>("Redis.Endpoints"),
                RedisPassword = configuration.GetValue<string>("Redis.Password"),
            };

            return config;
        }
    }
}
