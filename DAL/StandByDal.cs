using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class StandByDal
    {
        public static void AddNewStandBy(UserRide userRide)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    int degel = 0;
                    foreach (var item in park.StandBy)
                    {
                        if(item.UserId==userRide.UserId && item.RideId==userRide.RideId)
                        {
                            degel = 1;
                            item.NumberTimings++;
                        }
                    }
                    if(degel==0)
                    {
                        StandBy newStandBy = new StandBy()
                        {
                            UserId = userRide.UserId,
                            RideId = userRide.RideId,
                            NumberTimings = 1
                        };
                    }
                }
            }
            catch
            {
                return;
            }
        }
    }
}
