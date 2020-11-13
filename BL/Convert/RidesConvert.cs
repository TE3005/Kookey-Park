using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Convert
{
   public class RidesConvert
    {
        public static List< DTO.Rides> ConvertRidesToDTO(List<DAL.Ride> rides)
        {
            List<DTO.Rides> ridesss=new List<DTO.Rides>();
            foreach (var item in rides)
            {
                DTO.Rides r = new DTO.Rides();
                r.IdRide = item.Id_ride;
                r.name = item.name;
                ridesss.Add(r);
            }
            return ridesss;
        }
    }
}
