using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMonitor.Models;

namespace WebMonitor.Services
{
    public interface ISensorsService
    {
        Task<IEnumerable<SensorData>> GetSensorsAsync();
    }
}
