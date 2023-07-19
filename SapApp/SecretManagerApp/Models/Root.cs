using System.Text.Json.Serialization;

namespace SecretManagerApp.Models
{
    public class Root
    {
        [JsonPropertyName("forecast")]
        public Forecast Forecast { get; set; }
    }
}
