using StackExchange.Redis.Extensions.Core.Abstractions;

namespace YhtTicket.Common.Redis
{
    public interface IRedisClientFactory
    {
        IRedisCacheClient Connect();
    }
}
