using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitor.Models
{
    public class AlarmData
    {
        [Key]
        public int Id { get; set; }
        public string Sensor { get; set; }
        public string Description { get; set; }
        public bool Acknowledged { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
