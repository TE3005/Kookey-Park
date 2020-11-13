using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public class StandByLogic
    {
        public static void AddStandBy(DTO.UserRide userRide)
        {
            DAL.StandByDal.AddNewStandBy(Convert.UserRideConvert.ConvertUserRideToDAL(userRide));
        }
    }
}
