using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRedisExample.Domains.ConfigurationSettings.Redis
{
    public record RedisConfigurationSetting
    {
        /// <summary>
        /// The URL
        /// </summary>
        public string Url { get; init; }
        /// <summary>
        /// The port
        /// </summary>
        public string Port { get; init; }
        /// <summary>
        /// The autho
        /// </summary>
        public string Autho { get; init; }
    }
}
