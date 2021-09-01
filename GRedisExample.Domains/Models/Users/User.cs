using System;
using System.Text.Json.Serialization;

namespace GRedisExample.Domains.Models.Users
{
    public record User
    {
        /// <summary>
        /// The account
        /// </summary>
        [JsonPropertyName("account")]
        public string Account { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The creation date
        /// </summary>
        [JsonPropertyName("creationDate")]
        public DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// The modified date
        /// </summary>
        [JsonPropertyName("modifiedDate")]
        public DateTimeOffset ModifiedDate { get; set; }
    }
}
