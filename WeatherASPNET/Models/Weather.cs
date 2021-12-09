using System;
namespace WeatherASPNET.Models
{
    public class Weather
    {
        public Weather()
        {
        }

        public string ZipCode { get; set; }
        public string APIResponse { get; set; }
        public Coord Coordinate { get; set; }
        public string WxCondition { get; set; }
        public string WxDescription { get; set; }
        public string WxIcon { get; set; }
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public double Visibility { get; set; }
        public double WindSpeed { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
