using System;
using System.Threading.Tasks;
using backend.Code.Model;
using backend.Code.Repo;
using backend.Code.Utils;
using backend.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace backend.Code.Controllers {
    [Route("api/weather/[controller]")]
    public class ForecastController : Controller {    
        private readonly OpenWeatherSecrets _openWeatherSecrets;
        private IRepository<WeatherDay> WeatherRepository { get; }

        public ForecastController(IOptions<OpenWeatherSecrets> openWeatherSecrets) {
            _openWeatherSecrets = openWeatherSecrets.Value ?? throw new ArgumentException(nameof(openWeatherSecrets));
            WeatherRepository = new OpenWeatherRepository(_openWeatherSecrets);
        }

        [HttpGet()]
        [QueryStringConstraint(Constants.CITY_PARAM, true)]
        [QueryStringConstraint(Constants.ZIP_CODE_PARAM, false)]
        public async Task<IActionResult> ForecastByCity(string city) {
            var result = await WeatherRepository.FindEntitiesAsync(Constants.CITY_PARAM, city);
            return Ok(new ForecastResponse());
        }

        [HttpGet()]
        [QueryStringConstraint(Constants.ZIP_CODE_PARAM, true)]
        [QueryStringConstraint(Constants.CITY_PARAM, false)]
        public async Task<IActionResult> ForecastByZip([FromQuery(Name = Constants.ZIP_CODE_PARAM)] string zip) {
            var result = await WeatherRepository.FindEntitiesAsync(Constants.ZIP_CODE_PARAM, zip);
            return Ok(new ForecastResponse());
        }
    }
}