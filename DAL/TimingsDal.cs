using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TimingsDal
    {
        public void DeleteTimingUser (UserRide userRide)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {

                    foreach (var item in park.Timings)
                    {
                        if (userRide.UserRideId == item.UserRideId)
                        {
                            park.Timings.Remove(item);
                            park.SaveChanges();
                        }
                    }
                }
            }
            catch
            {

            }
    }
}
