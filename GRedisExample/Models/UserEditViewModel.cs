using System.Text.Json.Serialization;

namespace GRedisExample.Models
{
    public record UserEditViewModel
    {
        /// <summary>
        /// The name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
