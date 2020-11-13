using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Convert
{
    public class UserRideConvert
    {
        public static DAL.UserRide  ConvertUserRideToDAL(DTO.UserRide userRide)
        {
            return new DAL.UserRide()
            {
              UserRideId=userRide.UserRideId,
              UserId=userRide.UserId,
              RideId=userRide.RideId,
              CurrentTime=userRide.CurrentTime
            };

        }
        public static List<DAL.UserRide> convertUserRidesToDAL(List<DTO.UserRide> userRides)
        {
            List<DAL.UserRide> userRidesDAL = new List<DAL.UserRide>();
            foreach (var item in userRides)
            {
                DAL.UserRide userRide=new  DAL.UserRide()
                {
                    UserRideId = item.UserRideId,
                    UserId = item.UserId,
                    RideId = item.RideId,
                    CurrentTime = item.CurrentTime,
                    TimeVp=item.TimeVp.TimeOfDay
                };
                userRidesDAL.Add(userRide);
            }
            return userRidesDAL;
        }
        public static List<DTO.UserRide> ConvertUserRideToDTO(List<DAL.UserRide> userRides)
        {
            List<DTO.UserRide> userRidesDto = new List<DTO.UserRide>();
            foreach (var item in userRides)
            {
                DTO.UserRide u = new DTO.UserRide()
                {
                    UserRideId = item.UserRideId,
                    UserId = item.UserId,
                    RideId = item.RideId,
                    CurrentTime = item.CurrentTime.Value
                };
                userRidesDto.Add(u);
            }
            return userRidesDto;

        }
    }
}
