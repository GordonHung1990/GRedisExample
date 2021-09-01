using System;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace GRedisExample.Repositories.UnitTest
{
    [TestFixture]
    public class RedisStringRepositoryUnitTest
    {
        [Test]
        public async Task KeyExistsAsync()
        {
            var _repository = Substitute.For<IRedisStringRepository>();
            _repository.KeyExistsAsync("test").Returns(await Task.FromResult(true));
            var actual = await _repository.KeyExistsAsync("test").ConfigureAwait(false);
            Assert.AreEqual(true, actual);
        }
        [Test]
        public async Task StringSetAsync()
        {
            var _repository = Substitute.For<IRedisStringRepository>();
            _repository.StringSetAsync("test", "{}").Returns(await Task.FromResult(true));
            var actual = await _repository.StringSetAsync("test", "{}").ConfigureAwait(false);
            Assert.AreEqual(true, actual);
        }
        [Test]
        public async Task StringGetAsync()
        {
            var _repository = Substitute.For<IRedisStringRepository>();
            _repository.StringGetAsync("test").Returns(await Task.FromResult("{}"));
            var actual = await _repository.StringGetAsync("test").ConfigureAwait(false);
            Assert.AreEqual("{}", actual);
        }
        [Test]
        public async Task StringSetAsync_TimeSpan()
        {
            var _repository = Substitute.For<IRedisStringRepository>();
            _repository.StringSetAsync("test", "{}", TimeSpan.FromSeconds(30)).Returns(await Task.FromResult(true));
            var actual = await _repository.StringSetAsync("test", "{}", TimeSpan.FromSeconds(30)).ConfigureAwait(false);
            Assert.AreEqual(true, actual);
        }
    }
}