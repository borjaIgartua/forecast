using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace backend.Code.Model.OpenWeatherResponse {

    public class OpenWeatherResponse {

        [JsonProperty("cod")]
        public string Cod { get; set; }

        [JsonProperty("message")]
        public double Message { get; set; }

        [JsonProperty("cnt")]
        public int Cnt { get; set; }

        [JsonProperty("list")]
        public IList<Day> Days { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }

    public class Main {

        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("temp_min")]
        public double Temp_min { get; set; }

        [JsonProperty("temp_max")]
        public double Temp_max { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("sea_level")]
        public double Sea_level { get; set; }

        [JsonProperty("grnd_level")]
        public double Grnd_level { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_kf")]
        public double Temp_kf { get; set; }
    }

    public class Weather {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class Clouds {

        [JsonProperty("all")]
        public int All { get; set; }
    }

    public class Wind {

        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public double Deg { get; set; }
    }

    public class Sys {

        [JsonProperty("pod")]
        public string Pod { get; set; }
    }

    public class Rain {

        [JsonProperty("3h")]
        public double Threehours { get; set; }
    }

    public class Snow {

        [JsonProperty("3h")]
        public double Threehours { get; set; }
    }

    public class Day {

        [JsonProperty("dt")]
        public int Dt { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("weather")]
        public IList<Weather> Weather { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("dt_txt")]
        public string Dt_txt { get; set; }

        [JsonProperty("rain")]
        public Rain Rain { get; set; }

        [JsonProperty("snow")]
        public Snow Snow { get; set; }
    }

    public class Coord {

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }

    public class City {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
