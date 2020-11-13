using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RideVp
    {

        public int RideId { get; set; }
        public string RideName { get; set; }
        public string Image { get; set; }
        public int NumberSeets { get; set; }
        public TimeSpan DuringUsing { get; set; }
        public int AgeUser { get; set; }
        public int Mone { get; set; }
        public int NumMinutes { get; set; }

        public DateTime CurrentTime { get; set; }


    }
}
