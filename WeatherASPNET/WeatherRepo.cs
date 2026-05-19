using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using WeatherASPNET.Models;

namespace WeatherASPNET
{
    public class WeatherRepo : IWeatherRepo
    {
        private readonly string _conn;

        public WeatherRepo(string conn)
        {
            _conn = conn;
        }

        public Weather GetAPIResponse(string zipCode)
        {
            var weather = new Weather();

            var client = new HttpClient();

            var apiCall = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&units=imperial&appid={_conn}";

            weather.APIResponse = client.GetStringAsync(apiCall).Result;
                        
            var coord = new Coord();
            coord.Latitude = double.Parse(JObject.Parse(weather.APIResponse)["coord"]["lat"].ToString());
            coord.Longitude = double.Parse(JObject.Parse(weather.APIResponse)["coord"]["lon"].ToString());
            weather.Coordinate = coord;

            weather.WxCondition = JObject.Parse(weather.APIResponse)["weather"][0]["main"].ToString();
            weather.WxDescription = JObject.Parse(weather.APIResponse)["weather"][0]["description"].ToString();
            weather.WxIcon = JObject.Parse(weather.APIResponse)["weather"][0]["icon"].ToString();
            weather.Temp = double.Parse(JObject.Parse(weather.APIResponse)["main"]["temp"].ToString());
            weather.FeelsLike = double.Parse(JObject.Parse(weather.APIResponse)["main"]["feels_like"].ToString());
            weather.TempMax = double.Parse(JObject.Parse(weather.APIResponse)["main"]["temp_max"].ToString());
            weather.TempMin = double.Parse(JObject.Parse(weather.APIResponse)["main"]["temp_min"].ToString());
            weather.Pressure = double.Parse(JObject.Parse(weather.APIResponse)["main"]["pressure"].ToString());
            weather.Humidity = double.Parse(JObject.Parse(weather.APIResponse)["main"]["humidity"].ToString());
            weather.Visibility = double.Parse(JObject.Parse(weather.APIResponse)["visibility"].ToString());
            weather.WindSpeed = double.Parse(JObject.Parse(weather.APIResponse)["wind"]["speed"].ToString());
            weather.City = JObject.Parse(weather.APIResponse)["name"].ToString();
            weather.Country = JObject.Parse(weather.APIResponse)["sys"]["country"].ToString();

            //calculate Sunrise & Sunset
            var sunrise = long.Parse(JObject.Parse(weather.APIResponse)["sys"]["sunrise"].ToString());
            var sunriseOffset = DateTimeOffset.FromUnixTimeSeconds(sunrise);
            weather.Sunrise = sunriseOffset.DateTime.ToLocalTime().ToString("h:mm tt");

            var sunset = long.Parse(JObject.Parse(weather.APIResponse)["sys"]["sunset"].ToString());
            var sunsetOffset = DateTimeOffset.FromUnixTimeSeconds(sunset);
            weather.Sunset = sunsetOffset.DateTime.ToLocalTime().ToString("h:mm tt");

            //get Google Maps key
            var key = System.IO.File.ReadAllText("appsettings.json");
            weather.MapsKey = JObject.Parse(key).GetValue("MapsKey").ToString();

            //generate Google Maps embed address
            weather.MapsURL = $"https://www.google.com/maps/embed/v1/view?&key={weather.MapsKey}&center={weather.Coordinate.Latitude},{weather.Coordinate.Longitude}&zoom=9&maptype=satellite";

            return weather;
        }
    }
}
