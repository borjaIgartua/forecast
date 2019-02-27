using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Code.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Code.Controllers {
    [Route("api/weather/[controller]")]
    public class ForecastController : Controller {

        [HttpGet()]
        [QueryStringConstraint("city", true)]
        [QueryStringConstraint("zipCode", false)]
        public async Task<IActionResult> ForecastByCity(string city) {
        
            return Ok();
        }

        [HttpGet()]
        [QueryStringConstraint("zipCode", true)]
        [QueryStringConstraint("city", false)]
        public async Task<IActionResult> ForecastByZip([FromQuery(Name = "zipCode")] string zip) {

            return Ok();
        }
    }
}