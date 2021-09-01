using GRedisExample.Domains.ConfigurationSettings.Redis;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRedisExample.Domains.Connections.Redis
{
    public class RedisConnection : IRedisConnection
    {
        private readonly RedisConfigurationSetting _setting;
        private readonly Lazy<ConnectionMultiplexer> _connectionMultiplexer;
        public RedisConnection(IOptions<RedisConfigurationSetting> setting)
        {
            _setting = setting.Value;
            _connectionMultiplexer = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect($"{_setting.Url}:{_setting.Port},password={_setting.Autho}");
            });
        }
        ConnectionMultiplexer IRedisConnection.GetConnection()
            => _connectionMultiplexer.Value;

        IDatabase IRedisConnection.GetDatabase(int db)
            => _connectionMultiplexer.Value.GetDatabase(db);

        IDatabase IRedisConnection.GetDatabaseDefault()
            => _connectionMultiplexer.Value.GetDatabase();
    }
}
