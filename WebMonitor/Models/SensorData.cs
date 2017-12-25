using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitor.Models
{
    public class SensorData
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double? AlarmHI { get; set; }
        public double? AlarmHIHI { get; set; }
        public double? AlarmLO { get; set; }
        public double? AlarmLOLO { get; set; }
    }
}
