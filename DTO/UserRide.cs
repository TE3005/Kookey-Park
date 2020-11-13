using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class UserRide
    {
        public int UserRideId { get; set;  }
        public int RideId { get; set; }
        public int UserId { get; set; }
        public TimeSpan CurrentTime { get; set; }
        public DateTime TimeVp { get; set; }
    }
}
