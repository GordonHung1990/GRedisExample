using StackExchange.Redis;

namespace GRedisExample.Domains.Connections.Redis
{
    public interface IRedisConnection
    {
        ConnectionMultiplexer Connection { get; }

        IDatabase DatabaseDefault { get; }

        IDatabase GetDatabase(int dbIndex);
    }
}
