using System;
using System.Collections.Generic;
using backend.Code.Extensions;

namespace backend.Code.Model {
    public class WeatherDay {
        public double Temperature { get; }
        public double Humidity { get; }
        public double WindSpeed { get; }

        public int TimeStamp { get; }

        public string ShotDate => TimeStamp.UnixTimeStampToDateTime().ToShortDateString();

        public WeatherDay(double temperature, double humidity, double windSpeed, int timeStamp) {
            Temperature = temperature;
            Humidity = humidity;
            WindSpeed = windSpeed;
            TimeStamp = timeStamp;
        }

        public static WeatherDay Build(OpenWeatherResponse.Day day) {
            var temperature = day.Main.Temp;
            var humidity = day.Main.Humidity;
            var wind = day.Wind.Speed;
            var time = day.Dt;
            return new WeatherDay(temperature, humidity, wind, time);
        }
    }

    public class WeatherDayDateEqualityComparer : IEqualityComparer<WeatherDay> {
        public bool Equals(WeatherDay x, WeatherDay y) {
            var xDate = x.TimeStamp.UnixTimeStampToDateTime().ToShortDateString();
            var yDate = y.TimeStamp.UnixTimeStampToDateTime().ToShortDateString();
            return xDate.Equals(yDate);
        }

        public int GetHashCode(WeatherDay obj) {
            return obj.TimeStamp.UnixTimeStampToDateTime().ToShortDateString().GetHashCode();
        }
    }
}
