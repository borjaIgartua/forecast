using Newtonsoft.Json;
using backend.Code.Extensions;

namespace backend.Code.Model {
    public class ForecastItemResponse {    

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("timestamp")]
        public double TimeStamp { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        public ForecastItemResponse(double tmp, double hmd, double wind, double date, string city) {
            Temperature = tmp;
            Humidity = hmd;
            WindSpeed = wind;
            TimeStamp = date;
            City = city;
        }


        public static ForecastItemResponse Build(WeatherDay day) {
            var tmp = day.AverageTemperature;
            var hmd = day.AverageHumidity;
            var wind = day.WindSpeed;
            var date = day.TimeStamp;
            var city = day.City;
            return new ForecastItemResponse(tmp, hmd, wind, date, city);
        }
    }
}
