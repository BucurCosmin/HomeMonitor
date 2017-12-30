using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMonitor.Models;

namespace WebMonitor.Services
{
    public interface ISensorsDataWeather
    {
        void AddWeatherSensorData(WeatherData data);
        WeatherData GetLastWeatherData();
    }
}
