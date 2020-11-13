using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RidesLogic
    {
        public static List<DTO.Ride> GetRides()
        {
            return Convert.RideConvert.ConvertRidesToDTO(DAL.RidesDal.GetAllRides());
        }

        public static List<DTO.RideVp> GetVpRides()
        {
            return Convert.RideConvert.ConvertVpRidesToDTO(DAL.RidesDal.getAllVpRides());
        }
        public static List<DTO.TimeRide> GetTimeRides(int rideId)
        {
            return Convert.TimeRideConvert.ConvertTimeRide(DAL.RidesDal.getAllTimeRide(rideId));
        }


        public static List<TimeSpan> TimeToWait(List<DTO.Ride> rides)
        {

            List<TimeSpan> listTime = new List<TimeSpan>();
            foreach (var ride in rides)
            {
                TimeSpan t = new TimeSpan();
                DAL.Rides rideNumberSeets = DAL.RidesDal.getNumberSeetsToRide(ride.RideId);
                int numberSeets = ride.NumberSeets;                
                double secondsToAdd = DAL.RidesDal.SecondsToWaitForRide(Convert.RideConvert.ConvertRideToDAL(ride));
                t = TimeSpan.FromSeconds(secondsToAdd);
                listTime.Add(t);
            }


            return listTime;


        }

        public static List<TimeSpan> TimeToWaitForAllRides(List<DTO.Ride> rides)
        {

            List<TimeSpan> listTime = new List<TimeSpan>();
            foreach (var ride in rides)
            {
                TimeSpan t = new TimeSpan();
                DAL.Rides rideNumberSeets = DAL.RidesDal.getNumberSeetsToRide(ride.RideId);
                int numberSeets = ride.NumberSeets;
                double secondsToAdd = DAL.RidesDal.SecondsToWaitForRideForAllRides(Convert.RideConvert.ConvertRideToDAL(ride));
                t = TimeSpan.FromSeconds(secondsToAdd);
                listTime.Add(t);
            }


            return listTime;


        }
    }
}
