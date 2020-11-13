using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Convert
{
   public class TimeRideConvert
    {
        public static List<DTO.TimeRide> ConvertTimeRide(List<DAL.TimeRide> TimeRideDal)
        {
            List<DTO.TimeRide> TimeRideListDTO = new List<DTO.TimeRide>();
            foreach (var TimeRide in TimeRideDal)
            {
                DTO.TimeRide TimeRideDTO = new DTO.TimeRide()
                {
                    TimeRideId = TimeRide.TimeRideId,
                    TimeStart = TimeRide.TimeStart,
                    RideId = TimeRide.RideId,
                    Mone = TimeRide.Mone
                };
                TimeRideListDTO.Add(TimeRideDTO);
            }
            return TimeRideListDTO;
        }
    }
}
