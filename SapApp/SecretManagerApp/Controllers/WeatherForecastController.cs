using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SecretManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SecretManagerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<WeatherApiOptions> _weatherApiOptions;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IHttpClientFactory httpClientFactory,
            IOptions<WeatherApiOptions> weatherApiOptions)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _weatherApiOptions = weatherApiOptions;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var client = _httpClientFactory.CreateClient();
            var url = $"{_weatherApiOptions.Value.Url}?key={_weatherApiOptions.Value.Key}&q=Brisbane&days=3";

            var data = await client.GetFromJsonAsync<Root>(url);
            return data.Forecast.Forecastday.Select(a => new WeatherForecast()
            {
                Date = DateTime.Parse(a.Date).Date,
                Summary = a.Day.Condition.Text,
                TemperatureC = a.Day.AvgtempC
            });
        }
    }
}

