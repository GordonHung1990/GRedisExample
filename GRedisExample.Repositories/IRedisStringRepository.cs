using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace GRedisExample.Repositories
{
    public interface IRedisStringRepository
    {
        Task<bool> StringSetAsync(string key, string value);
        Task<RedisValue> StringGetAsync(string key);
        Task<bool> KeyExistsAsync(string key);
        Task<bool> StringSetAsync(string key, string value, TimeSpan timeSpan);
        Task<bool> KeyDeleteAsync(string key);
    }
}
