namespace YhtTicket.Common.Redis.Configuration
{
    class RedisConfig : IRedisConfig
    {
        public string RedisEndpoints { get; set; }
        public string RedisPassword { get; set; }
    }
}
