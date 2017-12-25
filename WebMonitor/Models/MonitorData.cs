using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebMonitor.Models
{
    public class MonitorData
    {
        [Key]
        public int Id { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
