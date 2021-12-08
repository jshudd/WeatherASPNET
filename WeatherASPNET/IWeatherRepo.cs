using System;
using WeatherASPNET.Models;

namespace WeatherASPNET
{
    public interface IWeatherRepo
    {
        public Weather GetAPIResponse(string zipCode);
    }
}
