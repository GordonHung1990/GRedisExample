using GRedisExample.Domains.Models.Users;
using GRedisExample.Models;
using GRedisExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GRedisExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <remarks>
        /// Note that the key is a GUID and not an integer.
        ///  
        ///     Get /api/User/test
        /// 
        /// </remarks>
        /// <param name="service">The service.</param>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        [HttpGet("{account}")]
        public ValueTask<User> GetAsync(
            [FromServices] IUserService service,
            string account)
            => service.GetAsync(account);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <remarks>
        ///  
        ///     POST /api/User
        ///     {
        ///        "account": "test",
        ///        "name": "test"
        ///     }
        /// 
        /// </remarks>
        /// <param name="service">The service.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public ValueTask<bool> AddAsync(
            [FromServices] IUserService service,
            [FromBody] UserAddViewModel model)
            => service.AddAsync(new User()
            {
                Account = model.Account,
                Name = model.Name,
                CreationDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            });

        /// <summary>
        /// Edits the asynchronous.
        /// </summary>
        /// <remarks>
        ///  
        ///     Put /api/User/test
        ///     {
        ///        "name": "test2"
        ///     }
        /// 
        /// </remarks>
        /// <param name="service">The service.</param>
        /// <param name="model">The model.</param>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        [HttpPut("{account}")]
        public ValueTask<bool> EditAsync(
            [FromServices] IUserService service,
            [FromBody] UserEditViewModel model,
            string account)
            => service.EditAsync(new User()
            {
                Account = account,
                Name = model.Name,
            });
        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <remarks>
        ///  
        ///     Delete /api/User/test
        /// 
        /// </remarks>
        /// <param name="service">The service.</param>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        [HttpDelete("{account}")]
        public ValueTask<bool> DeleteAsync(
            [FromServices] IUserService service,
            string account)
            => service.DeleteAsync(account);
    }
}
