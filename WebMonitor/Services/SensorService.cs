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

        public async Task<bool> AddSensorAsync(Sensor newSensor)
        {
            var entity = new SensorData()
            {
                AlarmHI = newSensor.AlarmHI,
                Name = newSensor.Name,
                AlarmHIHI = newSensor.AlarmHIHI,
                AlarmLO = newSensor.AlarmLO,
                AlarmLOLO = newSensor.AlarmLOLO,
                Logging = newSensor.Logging,
                DeadBand = newSensor.DeadBand,
                MaxValue = newSensor.MaxValue,
                MinValue = newSensor.MinValue
            };
            _context.Sensors.Add(entity);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
