namespace YhtTicket.Common.Redis.Configuration
{
    public interface IRedisConfig
    {
        public string RedisEndpoints { get; }
        public string RedisPassword { get; }
    }
}
