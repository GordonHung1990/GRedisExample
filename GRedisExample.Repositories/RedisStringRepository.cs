using System;
using System.Threading.Tasks;
using GRedisExample.Domains.Connections.Redis;

namespace GRedisExample.Repositories
{
    internal class RedisStringRepository : IRedisStringRepository
    {
        private readonly IRedisConnection _connection;
        public RedisStringRepository(IRedisConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        async ValueTask<string> IRedisStringRepository.StringGetAsync(string key)
            => await _connection.GetDatabaseDefault().StringGetAsync(key).ConfigureAwait(false);

        async ValueTask<bool> IRedisStringRepository.StringSetAsync(string key, string value)
            => await _connection.GetDatabaseDefault().StringSetAsync(key, value).ConfigureAwait(false);

        async ValueTask<bool> IRedisStringRepository.KeyExistsAsync(string key)
            => await _connection.GetDatabaseDefault().KeyExistsAsync(key).ConfigureAwait(false);

        async ValueTask<bool> IRedisStringRepository.StringSetAsync(string key, string value, TimeSpan timeSpan)
            => await _connection.GetDatabaseDefault().StringSetAsync(key, value, timeSpan).ConfigureAwait(false);

        async ValueTask<bool> IRedisStringRepository.KeyDeleteAsync(string key)
            => await _connection.GetDatabaseDefault().KeyDeleteAsync(key).ConfigureAwait(false);
    }
}
