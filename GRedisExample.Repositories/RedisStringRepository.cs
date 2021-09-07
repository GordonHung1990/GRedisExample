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

        Task<RedisValue> IRedisStringRepository.StringGetAsync(string key)
           => _connection.DatabaseDefault.StringGetAsync(key);

        Task<bool> IRedisStringRepository.StringSetAsync(string key, string value)
           => _connection.DatabaseDefault.StringSetAsync(key, value);

        Task<bool> IRedisStringRepository.KeyExistsAsync(string key)
           => _connection.DatabaseDefault.KeyExistsAsync(key);

        Task<bool> IRedisStringRepository.StringSetAsync(string key, string value, TimeSpan timeSpan)
           => _connection.DatabaseDefault.StringSetAsync(key, value, timeSpan);

        Task<bool> IRedisStringRepository.KeyDeleteAsync(string key)
           => _connection.DatabaseDefault.KeyDeleteAsync(key);
    }
}
