﻿using Newtonsoft.Json;
using backend.Code.Extensions;

namespace backend.Code.Model {
    public class ForecastItemResponse {    

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("day")]
        public string Day { get; set; }

        public ForecastItemResponse(double tmp, double hmd, double wind, string day) {
            Temperature = tmp;
            Humidity = hmd;
            WindSpeed = wind;
            Day = day;
        }


        public static ForecastItemResponse Build(WeatherDay day) {
            var tmp = day.AverageTemperature;
            var hmd = day.AverageHumidity;
            var wind = day.WindSpeed;
            var date = day.TimeStamp.UnixTimeStampToDateTime().ToString("dddd");
            return new ForecastItemResponse(tmp, hmd, wind, date);
        }
    }
}
