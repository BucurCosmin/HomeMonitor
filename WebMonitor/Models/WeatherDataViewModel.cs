using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitor.Models
{
    public class WeatherDataViewModel
    {
        public IEnumerable<MonitorData> WeatherDataPoints { get; set; }
    }
}
