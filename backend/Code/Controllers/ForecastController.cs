﻿using System;
using System.Linq;
using System.Threading.Tasks;
using backend.Code.Model;
using backend.Code.Repo;
using backend.Code.Services;
using backend.Code.Utils;
using backend.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace backend.Code.Controllers {
    [Route("api/weather/[controller]")]
    public class ForecastController : Controller {    
        private IRepository<WeatherDay> WeatherRepository { get; }

        public ForecastController(IOptions<OpenWeatherSecrets> openWeatherSecrets, OpenWeatherService service) {
            WeatherRepository = new OpenWeatherRepository(openWeatherSecrets.Value, service);
        }

        [HttpGet()]
        [QueryStringConstraint(Constants.CITY_PARAM, true)]
        [QueryStringConstraint(Constants.ZIP_CODE_PARAM, false)]
        public async Task<IActionResult> ForecastByCity(string city) {
            var result = await WeatherRepository.FindEntitiesAsync(Constants.CITY_PARAM, city);
            return Ok(result.Select(ForecastItemResponse.Build).ToList());
        }

        [HttpGet()]
        [QueryStringConstraint(Constants.ZIP_CODE_PARAM, true)]
        [QueryStringConstraint(Constants.CITY_PARAM, false)]
        public async Task<IActionResult> ForecastByZip([FromQuery(Name = Constants.ZIP_CODE_PARAM)] string zip) {
            var result = await WeatherRepository.FindEntitiesAsync(Constants.ZIP_CODE_PARAM, zip);
            return Ok(result.Select(ForecastItemResponse.Build).ToList());
        }
    }
}