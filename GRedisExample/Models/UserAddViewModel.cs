using System.Text.Json.Serialization;

namespace GRedisExample.Models
{
    public record UserAddViewModel
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
    }
}
