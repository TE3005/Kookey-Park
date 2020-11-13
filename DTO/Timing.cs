using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Timing
    {
        public int TimingId { get; set; }
        public int UserRideId { get; set; }
        public DateTime OperatingTime { get; set; }
        public int CountTimings { get; set; }
    }
}
