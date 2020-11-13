using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public  class Ride
    {

        public int RideId { get; set; }
        public string RideName { get; set; }
        public string Image { get; set; }
        public int NumberSeets { get; set; }
        public TimeSpan DuringUsing { get; set; }
        public int AgeUser { get; set; }

    }
}
