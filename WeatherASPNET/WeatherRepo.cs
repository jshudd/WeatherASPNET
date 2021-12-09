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

            return weather;
        }
    }
}
