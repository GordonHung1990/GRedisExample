using System.Threading.Tasks;
using GRedisExample.Domains.Models.Users;

namespace GRedisExample.Services
{
    public interface IUserService
    {
        Task<bool> AddAsync(User user);

        Task<bool> EditAsync(User user);

        Task<User> GetAsync(string account);

        Task<bool> DeleteAsync(string account);
    }
}
