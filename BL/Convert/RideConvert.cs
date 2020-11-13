using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Convert
{
    public class RideConvert
    {
         public static List<DTO.Ride> ConvertRidesToDTO(List<DAL.Rides> rides)
        {
            List<DTO.Ride> DTORides = new List<DTO.Ride>();
            foreach (var item in rides)
            {
                DTO.Ride ride = new DTO.Ride();
                ride.RideId = item.RideId;
                ride.RideName = item.RideName;
                ride.Image = item.Image;
                ride.NumberSeets = item.NumberSeets;
                ride.AgeUser = item.AgeUser;

                DTORides.Add(ride);
            }
            return DTORides;
        }
        public static List<DTO.RideVp> ConvertVpRidesToDTO(List<DAL.RidesVp> rides)
        {
            List<DTO.RideVp> DTORides = new List<DTO.RideVp>();
            foreach (var item in rides)
            {
                DTO.RideVp ride = new DTO.RideVp();
                ride.RideId = item.RideId;
                ride.RideName = item.RideName;
                ride.Image = item.Image;
                ride.NumberSeets = item.NumberSeets;
                ride.AgeUser = item.AgeUser;
                ride.CurrentTime= item.CurrentTime;
                ride.Mone = item.Mone;
                ride.NumMinutes = item.NumMinutes;
                DTORides.Add(ride);
            }
            return DTORides;
        }
        public static DAL.Rides ConvertRideToDAL(DTO.Ride ride)
        {
            if (ride == null)
                return null;
            return new DAL.Rides()
            {
                RideId = ride.RideId,
                RideName=ride.RideName,
                Image=ride.Image,
                AgeUser=ride.AgeUser,
                DuringUsing=ride.DuringUsing,
                NumberSeets=ride.NumberSeets

            };

        }

    }
}

