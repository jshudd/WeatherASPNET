using System;
using WeatherASPNET.Models;

namespace WeatherASPNET
{
    public interface IWeatherRepo
    {
        public string GetAPIResponse(string zipCode);

        public Weather ParseResponse(string response);
    }
}
