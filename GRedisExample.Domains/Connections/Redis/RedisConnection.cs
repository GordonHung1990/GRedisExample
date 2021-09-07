using GRedisExample.Domains.ConfigurationSettings.Redis;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;

namespace GRedisExample.Domains.Connections.Redis
{
    internal sealed class RedisConnection : IRedisConnection
    {
        private readonly RedisConfigurationSetting _setting;
        private readonly Lazy<ConnectionMultiplexer> _connectionMultiplexer;
        public RedisConnection(IOptions<RedisConfigurationSetting> setting)
        {
            _setting = setting.Value;
            _connectionMultiplexer = new Lazy<ConnectionMultiplexer>(() =>
            {
                var connectionString = $"{_setting.Url}:{_setting.Port},allowAdmin=true";
                if (!string.IsNullOrEmpty(_setting.Autho))
                {
                    connectionString += $",password={_setting.Autho}";
                }

                return ConnectionMultiplexer.Connect(connectionString);
            });
        }
        ConnectionMultiplexer IRedisConnection.Connection => _connectionMultiplexer.Value;

        IDatabase IRedisConnection.DatabaseDefault => _connectionMultiplexer.Value.GetDatabase();

        IDatabase IRedisConnection.GetDatabase(int db)
            => _connectionMultiplexer.Value.GetDatabase(db);


    }
}
