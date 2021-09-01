using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
