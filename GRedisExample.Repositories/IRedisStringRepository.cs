using System;
using System.Threading.Tasks;

namespace GRedisExample.Repositories
{
    public interface IRedisStringRepository
    {
        ValueTask<bool> StringSetAsync(string key, string value);
        ValueTask<string> StringGetAsync(string key);
        ValueTask<bool> KeyExistsAsync(string key);
        ValueTask<bool> StringSetAsync(string key, string value, TimeSpan timeSpan);
        ValueTask<bool> KeyDeleteAsync(string key);
    }
}
