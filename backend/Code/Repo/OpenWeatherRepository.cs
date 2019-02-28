using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Code.Model;
using backend.Configuration;
using backend.Code.Services;
using backend.Code.Model.OpenWeatherResponse;
using System.Linq;

namespace backend.Code.Repo {
    public class OpenWeatherRepository : IRepository<WeatherDay> {
        private readonly OpenWeatherService _service;

        public OpenWeatherRepository(OpenWeatherSecrets openWeatherSecrets, OpenWeatherService service) {
            _service = service;
            _service.AppID = openWeatherSecrets.APISecret;
        }

        public async Task<IList<WeatherDay>> FindEntitiesAsync(string key, string value) {
            OpenWeatherResponse response = null;
            if (key.Equals(Constants.CITY_PARAM)) {
                response = await _service.GetFiveDaysForecastByCity(value);

            } else if (key.Equals(Constants.ZIP_CODE_PARAM)) {
                response = await _service.GetFiveDaysForecastByZip(value);
            }

            var result = new List<WeatherDay>();
            if (response != null && response.Days != null && response.Days.Count > 0) {
                var days = response.Days.GroupBy(day => day, new DayDateEqualityComparer())
                                        .Select(group => {
                                            var avgtemp = group.Select(day => day.Main.Temp).Average();
                                            var avgHum = group.Select(day => day.Main.Humidity).Average();

                                            return WeatherDay.Build(group.Key, avgtemp, avgHum); ; 
                                        }).ToList();

                result = days;
            }

            return result;
        }
    }
}
