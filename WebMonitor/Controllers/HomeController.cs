using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMonitor.Models;
using WebMonitor.Services;

namespace WebMonitor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISensorsService _sensorService;

        public HomeController(ISensorsService SensorService)
        {
            _sensorService = SensorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
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
    }
}
