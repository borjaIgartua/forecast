using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Code.Model;
using backend.Code.Extensions;
using backend.Configuration;

namespace backend.Code.Repo {
    public class OpenWeatherRepository : IRepository<WeatherDay> {
        private static string BASE_URL = "https://samples.openweathermap.org/data/2.5/forecast";
        private static string OW_CITY_PARAM = "q";
        private static string OW_ZIP_PARAM = "zip";
        private readonly OpenWeatherSecrets _openWeatherSecrets;

        public OpenWeatherRepository(OpenWeatherSecrets openWeatherSecrets) {
            _openWeatherSecrets = openWeatherSecrets;
        }

        Task<IList<WeatherDay>> IRepository<WeatherDay>.FindEntitiesAsync(string key, string value) {
            if (key == null || value == null) {
                throw new ArgumentException();
            }

            var uriBuilder = new UriBuilder(BASE_URL);
            if (key.Equals(Constants.CITY_PARAM)) {
                uriBuilder.AddParam(OW_CITY_PARAM, value);

            } else if (key.Equals(Constants.CITY_PARAM)) {
                uriBuilder.AddParam(OW_ZIP_PARAM, value);
            }


            throw new NotImplementedException();
        }
    }
}
