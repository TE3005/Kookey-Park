using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TimeRide
    {
        public int TimeRideId { get; set; }
        public int RideId { get; set; }
        public TimeSpan TimeStart { get; set; }
        public int Mone { get; set; }
    }
}
