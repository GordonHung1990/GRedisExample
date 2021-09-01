using System.Threading.Tasks;
using GRedisExample.Domains.Models.Users;

namespace GRedisExample.Services
{
    public interface IUserService
    {
        ValueTask<bool> AddAsync(User user);

        ValueTask<bool> EditAsync(User user);

        ValueTask<User> GetAsync(string account);

        ValueTask<bool> DeleteAsync(string account);
    }
}
