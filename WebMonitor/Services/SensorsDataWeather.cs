using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMonitor.Data;
using WebMonitor.Models;

namespace WebMonitor.Services
{
    public class SensorsDataWeather : ISensorsDataWeather
    {
        private readonly ApplicationDbContext _context;
        public SensorsDataWeather(ApplicationDbContext context)
        {
            _context = context;
        }


        public void AddWeatherSensorData(WeatherData data)
        {
            MonitorData newdata = new MonitorData
            {
                Pressure = data.Pressure,
                Temperature = data.Temperature,
                Timestamp = DateTime.Now
            };
            _context.SensorsData.Add(newdata);
            _context.SaveChanges();

         }

        public WeatherData GetLastWeatherData()
        {
            MonitorData data=_context.SensorsData.Last<MonitorData>();
            return new WeatherData
            {
                Temperature = data.Temperature,
                Pressure = data.Pressure
            };
        }
    }
}
