using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMonitor.Models
{
    public class Sensor
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("AlarmHI")]
        public double AlarmHI { get; set; }
        [JsonProperty("AlarmHIHI")]
        public double AlarmHIHI { get; set; }
        [JsonProperty("AlarmLO")]
        public double AlarmLO { get; set; }
        [JsonProperty("AlarmLOLO")]
        public double AlarmLOLO { get; set; }
        [JsonProperty("Logging")]
        public bool Logging { get; set; }
        [JsonProperty("MaxValue")]
        public double MaxValue { get; set; }
        [JsonProperty("MinValue")]
        public double MinValue { get; set; }
        [JsonProperty("DeadBand")]
        public double DeadBand { get; set; }
    }
}
