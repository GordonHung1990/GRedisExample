using System;
using System.Threading.Tasks;
using GRedisExample.Domains.Connections.Redis;
using StackExchange.Redis;

namespace GRedisExample.Repositories
{
    internal class RedisStringRepository : IRedisStringRepository
    {
        private readonly IRedisConnection _connection;
        public RedisStringRepository(IRedisConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public Task<RedisValue> StringGetAsync(string key)
           => _connection.DatabaseDefault.StringGetAsync(key);

        public Task<bool> StringSetAsync(string key, string value)
           => _connection.DatabaseDefault.StringSetAsync(key, value);

        public Task<bool> KeyExistsAsync(string key)
           => _connection.DatabaseDefault.KeyExistsAsync(key);

        public Task<bool> StringSetAsync(string key, string value, TimeSpan timeSpan)
           => _connection.DatabaseDefault.StringSetAsync(key, value, timeSpan);

        public Task<bool> KeyDeleteAsync(string key)
           => _connection.DatabaseDefault.KeyDeleteAsync(key);
    }
}
