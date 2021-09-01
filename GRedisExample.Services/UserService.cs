using System;
using System.Text.Json;
using System.Threading.Tasks;
using GRedisExample.Domains.Models.Users;
using GRedisExample.Repositories;

namespace GRedisExample.Services
{
    internal class UserService : IUserService
    {
        private readonly IRedisStringRepository _redisStringRepository;
        public UserService(IRedisStringRepository redisStringRepository)
        {
            _redisStringRepository = redisStringRepository ?? throw new ArgumentNullException(nameof(redisStringRepository));
        }

        public async ValueTask<bool> AddAsync(User user)
            => await _redisStringRepository.KeyExistsAsync(user.Account).ConfigureAwait(false)
                ? true
                : await _redisStringRepository.StringSetAsync(user.Account, JsonSerializer.Serialize(user)).ConfigureAwait(false);

        public async ValueTask<bool> EditAsync(User user)
        {
            if (!await _redisStringRepository.KeyExistsAsync(user.Account).ConfigureAwait(false))
            {
                return false;
            }
            var getUser = JsonSerializer.Deserialize<User>(await _redisStringRepository.StringGetAsync(user.Account).ConfigureAwait(false));
            getUser.Name = user.Name;
            getUser.ModifiedDate = DateTimeOffset.UtcNow;
            return await _redisStringRepository.StringSetAsync(getUser.Account, JsonSerializer.Serialize(getUser)).ConfigureAwait(false);
        }

        public async ValueTask<User> GetAsync(string account)
        {
            var value = await _redisStringRepository.StringGetAsync(account).ConfigureAwait(false);
            return string.IsNullOrEmpty(value) ? null : JsonSerializer.Deserialize<User>(value);
        }

        public async ValueTask<bool> DeleteAsync(string account)
           => await _redisStringRepository.KeyExistsAsync(account).ConfigureAwait(false)
               ? await _redisStringRepository.KeyDeleteAsync(account).ConfigureAwait(false)
               : false;
    }
}
