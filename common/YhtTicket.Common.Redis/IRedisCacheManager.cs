using System;
using System.Threading.Tasks;

namespace YhtTicket.Common.Redis
{
    public interface IRedisCacheManager
    {
        Task AddAsync<T>(string key, T value, TimeSpan ttl);
        Task<T> GetAsync<T>(string key);
        Task RemoveAsync<T>(string key);
    }
}
