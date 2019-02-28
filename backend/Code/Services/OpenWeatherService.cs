using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using backend.Code.Extensions;
using backend.Code.Model.OpenWeatherResponse;

namespace backend.Code.Services {
    public class OpenWeatherService {
        private const string BASE_URL = "https://samples.openweathermap.org";

        private const string FORECAST_PATH = "/data/2.5/forecast";
        private const string FORECAST_CITY_PARAM = "q";
        private const string FORECAST_ZIP_PARAM = "zip";
        private const string FORECAST_APPID_PARAM = "appid";

        public HttpClient Client { get; }
        public string AppID { get; set; }

        public OpenWeatherService(HttpClient client) {
            client.BaseAddress = new Uri(BASE_URL);
            Client = client;
        }

        public async Task<OpenWeatherResponse> GetFiveDaysForecastByCity(string city) {
            var response = await Client.GetAsync(BuildQuery(FORECAST_PATH, AppID, city));
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<OpenWeatherResponse>();
            return result;
        }

        public async Task<OpenWeatherResponse> GetFiveDaysForecastByZip(string zipCode) {
            var response = await Client.GetAsync(BuildQuery(FORECAST_PATH, AppID, null, zipCode));
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<OpenWeatherResponse>();
            return result;
        }

        protected string BuildQuery(string path, string appIdentifier, string city, string zipCode = null) {
            if ((!String.IsNullOrEmpty(city) && !String.IsNullOrEmpty(zipCode)) || (String.IsNullOrEmpty(city) && String.IsNullOrEmpty(zipCode))) {
                throw new ArgumentException("The service do not allow a Query with this parameters");
            }

            if (String.IsNullOrEmpty(appIdentifier)) {
                throw new ArgumentException("Requests without identifier are not allowed");
            }

            return path.AddParam(FORECAST_CITY_PARAM, city)
                        .AddParam(FORECAST_ZIP_PARAM, zipCode)
                        .AddParam(FORECAST_APPID_PARAM, appIdentifier);
        }
    }
}
