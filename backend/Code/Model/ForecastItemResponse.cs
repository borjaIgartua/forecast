using System;
using Newtonsoft.Json;

namespace backend.Code.Model {
    public class ForecastItemResponse {    

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        public ForecastItemResponse(double tmp, double hmd, double wind) {
            Temperature = tmp;
            Humidity = hmd;
            WindSpeed = wind;
        }


        public static ForecastItemResponse Build(WeatherDay day) {
            var tmp = day.AverageTemperature;
            var hmd = day.AverageHumidity;
            var wind = day.WindSpeed;
            return new ForecastItemResponse(tmp, hmd, wind);
        }
    }
}
