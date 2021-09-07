using System;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using StackExchange.Redis;

namespace GRedisExample.Repositories.UnitTest
{
    [TestFixture]
    public class RedisStringRepositoryUnitTest
    {
        [Test]
        public async Task KeyExistsAsync()
        {
            var _repository = Substitute.For<IRedisStringRepository>();
            _ = _repository.KeyExistsAsync("test").Returns(Task.FromResult(true));
            var actual = await _repository.KeyExistsAsync("test").ConfigureAwait(false);
            Assert.AreEqual(true, actual);
        }
        [Test]
        public async Task StringSetAsync()
        {
            var _repository = Substitute.For<IRedisStringRepository>();
            _ = _repository.StringSetAsync("test", "{}").Returns(Task.FromResult(true));
            var actual = await _repository.StringSetAsync("test", "{}").ConfigureAwait(false);
            Assert.AreEqual(true, actual);
        }
        [Test]
        public async Task StringGetAsync()
        {
            var _repository = Substitute.For<IRedisStringRepository>();
            _ = _repository.StringGetAsync("test").Returns(Task.FromResult((RedisValue)"{}"));
            var actual = await _repository.StringGetAsync("test").ConfigureAwait(false);
            Assert.AreEqual("{}", actual.ToString());
        }
        [Test]
        public async Task StringSetAsync_TimeSpan()
        {
            var _repository = Substitute.For<IRedisStringRepository>();
            _ = _repository.StringSetAsync("test", "{}", TimeSpan.FromSeconds(30)).Returns(Task.FromResult(true));
            var actual = await _repository.StringSetAsync("test", "{}", TimeSpan.FromSeconds(30)).ConfigureAwait(false);
            Assert.AreEqual(true, actual);
        }
        [Test]
        public async Task KeyDeleteAsync()
        {
            var _repository = Substitute.For<IRedisStringRepository>();
            _ = _repository.StringSetAsync("test", "{}").Returns(Task.FromResult(true));
            _ = _repository.KeyDeleteAsync("test").Returns(Task.FromResult(true));
            var actual = await _repository.KeyDeleteAsync("test").ConfigureAwait(false);
            Assert.AreEqual(true, actual);
        }
    }
}