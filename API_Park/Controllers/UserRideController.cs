using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API_Park.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("userRide")]
    public class UserRideController : ApiController
    {
        
        [HttpDelete]
        [Route("deleteUserRides")]
        public void DeleteUserRides(List<DTO.UserRide> usersToDelete)
        {

            int i = 0;
            foreach(var item in usersToDelete) 
            {
                TimeSpan t = new TimeSpan();
                t = usersToDelete[i].TimeVp.TimeOfDay;
                usersToDelete[i].CurrentTime = t;
                BL.UserRideLogic.deleteUserRide(usersToDelete);
                i++;
            }
        }
        [HttpDelete]
        [Route("deleteWithoutMone")]
        public void DeleteWithoutMone(List<DTO.UserRide> usersToDelete)
        {
            int i = 0;
            foreach (var item in usersToDelete)
            {
                TimeSpan t = new TimeSpan();
                t = usersToDelete[i].TimeVp.TimeOfDay;
                usersToDelete[i].CurrentTime = t;
                BL.UserRideLogic.deleteUserRide2(usersToDelete);
                i++;
            }
        }


        [Route("registerListRides")]
        [HttpPost]
        public List<DTO.UserRide> AddUserRides(List<DTO.UserRide> userRide)
        {
            return BL.UserRideLogic.Math1(userRide);
        }

        
        [Route("getUserRides")]
        [HttpPost]
        public List<DTO.UserRideDetail> GetAllUserRides(DTO.User user)
        {
            return BL.UserRideLogic.getAllUserRides(user);
        }

        [Route("registerRide")]
        [HttpPost]
        public List<DTO.User> Login(List<DTO.UserRide> userRide)
        {
            return BL.UserRideLogic.AddUserRide(userRide);

        }
        [Route("deleteUserRide")]
        [HttpDelete]
        public void deleteUserRide(int userRideId)
        {
             BL.UserRideLogic.deleteUserRide(userRideId);

        }
    }
}
