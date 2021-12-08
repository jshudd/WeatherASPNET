using System;
namespace WeatherASPNET.Models
{
    public class Weather
    {
        public Weather()
        {
        }

        public string ZipCode { get; set; }
        public Coord Coordinate { get; set; }
        public string WxMainDesc { get; set; }
        public string WxDescription { get; set; }
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public int Visibility { get; set; }
        public double WindSpeed { get; set; }
        public double WindDeg { get; set; }
        public double WindGust { get; set; }
        public string City { get; set; }
    }
}
