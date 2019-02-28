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

            if (response != null) {
                var days = response.Days.Select(WeatherDay.Build).ToList().GroupBy(day => day, new WeatherDayDateEqualityComparer()).ToDictionary(g => g.Key, g => g.ToList());
                Console.WriteLine(days);
            }

            throw new NotImplementedException();
        }
    }
}
