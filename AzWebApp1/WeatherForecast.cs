using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AzWebApp1
{
    public class WeatherForecast
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("temperatureC", Required = Required.Always)]
        public string TemperatureC { get; set; }

        [JsonIgnore]
        public int TemperatureF => -1;

        [JsonProperty("summary")]
        [JsonRequired]
        public string Summary { get; set; }
    }
}