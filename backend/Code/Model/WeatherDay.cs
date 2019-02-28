using System;
using System.Collections.Generic;
using backend.Code.Extensions;

namespace backend.Code.Model {
    public class WeatherDay {
        public double AverageTemperature { get; }
        public double AverageHumidity { get; }
        public double WindSpeed { get; }

        public int TimeStamp { get; }

        public string ShotDate => TimeStamp.UnixTimeStampToDateTime().ToShortDateString();

        public WeatherDay(double temperature, double humidity, double windSpeed, int timeStamp) {
            AverageTemperature = temperature;
            AverageHumidity = humidity;
            WindSpeed = windSpeed;
            TimeStamp = timeStamp;
        }

        public static WeatherDay Build(OpenWeatherResponse.Day day, double avgTemp, double avgHmd) {
            var wind = day.Wind.Speed;
            var time = day.Dt;
            return new WeatherDay(avgTemp, avgHmd, wind, time);
        }
    }
}
