using System;
using GRedisExample.Domains.ConfigurationSettings.Redis;
using GRedisExample.Domains.Connections.Redis;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConnectionExtensions
    {
        /// <summary>
        /// Adds the redis connection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="redisConfigurationSetting">The redis configuration setting.</param>
        /// <returns></returns>
        public static IServiceCollection AddRedisConnection(this IServiceCollection services, Action<RedisConfigurationSetting, IServiceProvider> redisConfigurationSetting)
        {
            return services
            .AddOptions<RedisConfigurationSetting>()
            .Configure(redisConfigurationSetting)
            .Services
            .AddSingleton<IRedisConnection, RedisConnection>();
        }
    }
}
