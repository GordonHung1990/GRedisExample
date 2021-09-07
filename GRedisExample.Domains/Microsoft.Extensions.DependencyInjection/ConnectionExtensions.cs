using System;
using GRedisExample.Domains.ConfigurationSettings.Redis;
using GRedisExample.Domains.Connections.Redis;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConnectionExtensions
    {
        /// <summary>
        /// Adds the repositories.
        /// </summary>
        /// <param name="services">The services.</param>
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
