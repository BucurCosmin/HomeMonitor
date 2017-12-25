using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMonitor.Data;
using WebMonitor.Models;
using Microsoft.EntityFrameworkCore;

namespace WebMonitor.Services
{
    public class SensorService : ISensorsService
    {
        private readonly ApplicationDbContext _context;

        public SensorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SensorData>> GetSensorsAsync()
        {
            var sensors = await _context.Sensors.ToArrayAsync();
            return sensors;
        }
    }
}
