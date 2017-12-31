using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMonitor.Models;
using WebMonitor.Services;

namespace WebMonitor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISensorsService _sensorService;
        private readonly ISensorsDataWeather _sensorsDataWeather;

        public HomeController(ISensorsService SensorService,ISensorsDataWeather sensorsDataWeather)
        {
            _sensorService = SensorService;
            _sensorsDataWeather = sensorsDataWeather;
        }
        public IActionResult Index()
        {
            WeatherData wd = _sensorsDataWeather.GetLastWeatherData();
            return View(wd);
        }

        public IActionResult UpdateWeatherView()
        {
            WeatherData wd = _sensorsDataWeather.GetLastWeatherData();
            return PartialView("SensorsView1", wd);

        }
        
        public async Task<IActionResult> Trends()
        {
            var data= await _sensorsDataWeather.GetWeatherDataAsync(1);
            
            return View(data);
        }

        public IActionResult Alarms()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public async Task<IActionResult> Sensors()
        {
            var sensor = await _sensorService.GetSensorsAsync();
            var model = new SensorsViewModel()
            {
                Sensors = sensor
            };
            ViewData["Message"] = "Sensors page.";

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Route("Home/AddNewSensor")]
        public async Task<IActionResult> AddNewSensor(String newSensorJSON)
        {
            string Data;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                Data = await reader.ReadToEndAsync();

            }
            
            Sensor newSensor = JsonConvert.DeserializeObject<Sensor>(Data);

 //           if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var succesfull = await _sensorService.AddSensorAsync(newSensor);
            if (!succesfull)
            {
                return BadRequest(new { Error = "could not add sensor" });
            }
            return Ok();
        }

        [HttpPost]
        [Route("Home/AddWeatherData")]
        public async Task<IActionResult> AddWeatherData(string WeatherData)
        {
            string Data;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                Data = await reader.ReadToEndAsync();

            }
            WeatherData weather = JsonConvert.DeserializeObject<WeatherData>(Data);
            _sensorsDataWeather.AddWeatherSensorData(weather);

            return Ok();
        }

        [HttpPost]
        [Route("Home/GetLastWeatherData")]
        public string[] GetLastWeatherData()
        {
            WeatherData wd = _sensorsDataWeather.GetLastWeatherData();
            string[] data = { wd.Temperature.ToString(), wd.Pressure.ToString() };
            return data;
        }
    }
}