using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherASPNET.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherASPNET.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherRepo repo;

        public WeatherController(IWeatherRepo weatherRepo)
        {
            this.repo = weatherRepo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var weather = new Weather();

            return View(weather);
        }

        public IActionResult Weather(string zipCode)
        {
            var weather = repo.GetAPIResponse(zipCode);

            return View(weather);
        }
    }
}
