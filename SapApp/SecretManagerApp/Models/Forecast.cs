using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SecretManagerApp.Models
{
    public class Forecast
    {
        [JsonPropertyName("forecastday")]
        public List<Forecastday> Forecastday { get; set; }
    }
}
