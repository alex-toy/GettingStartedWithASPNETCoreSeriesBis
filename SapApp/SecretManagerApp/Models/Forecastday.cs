using System.Text.Json.Serialization;

namespace SecretManagerApp.Models
{
    public class Forecastday
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("date_epoch")]
        public int DateEpoch { get; set; }

        [JsonPropertyName("day")]
        public Day Day { get; set; }
    }
}
