using System;
using System.Threading.Tasks;
using GRedisExample.Domains.Models.Users;
using NSubstitute;
using NUnit.Framework;

namespace GRedisExample.Services.UnitTest
{
    [TestFixture]
    public class UserServiceUnitTest
    {
        [Test]
        public async Task AddAsync()
        {
            var data = new User()
            {
                Account = "test",
                Name = "test",
                CreationDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };
            var service = Substitute.For<IUserService>();
            _ = service.AddAsync(data).Returns(ValueTask.FromResult(true));
            var actual = await service.AddAsync(data).ConfigureAwait(false);
            Assert.AreEqual(true, actual);
        }
        [Test]
        public async Task EditAsync()
        {
            var data = new User()
            {
                Account = "test",
                Name = "test",
                CreationDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };
            var service = Substitute.For<IUserService>();
            _ = service.GetAsync("test").Returns(ValueTask.FromResult(data));
            data.Name = "test2";
            _ = service.EditAsync(data).Returns(ValueTask.FromResult(true));
            _ = await service.EditAsync(data).ConfigureAwait(false);
            var actual = await service.GetAsync("test").ConfigureAwait(false);
            Assert.AreEqual(data.Name, actual.Name);
        }
        [Test]
        public async Task GetAsync()
        {
            var data = new User()
            {
                Account = "test",
                Name = "test",
                CreationDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };
            var service = Substitute.For<IUserService>();
            _ = service.GetAsync("test").Returns(ValueTask.FromResult(data));
            var actual = await service.GetAsync("test").ConfigureAwait(false);
            Assert.AreEqual(data.Account, actual.Account);
        }
        [Test]
        public async Task DeleteAsync()
        {
            var data = new User()
            {
                Account = "test",
                Name = "test",
                CreationDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };
            var service = Substitute.For<IUserService>();

            _ = service.AddAsync(data).Returns(ValueTask.FromResult(true));
            _ = service.DeleteAsync(data.Account).Returns(ValueTask.FromResult(true));
            var actual = await service.DeleteAsync(data.Account).ConfigureAwait(false);
            Assert.AreEqual(true, actual);
        }
    }
}