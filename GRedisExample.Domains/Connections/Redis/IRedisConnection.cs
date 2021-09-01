using StackExchange.Redis;

namespace GRedisExample.Domains.Connections.Redis
{
    public interface IRedisConnection
    {
        ConnectionMultiplexer GetConnection();

        IDatabase GetDatabaseDefault();

        IDatabase GetDatabase(int dbIndex);
    }
}
