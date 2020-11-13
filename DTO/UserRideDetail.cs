using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserRideDetail
    {
        //public User User { get; set; }
        //public List<UserRide> UserRide { get; set; }
        //public List<Ride> Rides { get; set; }
        public int RideId { get; set; }
        public string RideName { get; set; }
        public int NumberSeets { get; set; }
        public string Image { get; set; }
        public TimeSpan DuringUsing { get; set; }
        public DateTime? CurrentTime { get; set; }
        public DateTime TimeVp { get; set; }
        public int UserRideId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

}
