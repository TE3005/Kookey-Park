using DTO;
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
    [RoutePrefix("Rides")]
    public class RidesController : ApiController
    {
        [Route("getAllRides")]
        [HttpGet]
        public List<DTO.Ride> GetAllRides()
        {
            return BL.RidesLogic.GetRides();
        }

        [Route("getVpRides")]
        [HttpGet]
        public List<DTO.RideVp> GetVpRides()
        {
            return BL.RidesLogic.GetVpRides();
        }
        //[Route("getAllTimeRides/{rideId:int}")]
        //[HttpGet]
        //public List<DTO.TimeRide> GetAllTimeRides(int rideId)
        //{
        //    return BL.RidesLogic.GetTimeRides(rideId);
        //}
        [Route("getAvg")]
        [HttpPost]
        public List<TimeSpan> time(List<Ride> rides)
        {
            return BL.RidesLogic.TimeToWait(rides);
        }

        [Route("getAvgForAllRides")]
        [HttpPost]
        public List<TimeSpan> timeAll(List<Ride> rides)
        {
            return BL.RidesLogic.TimeToWaitForAllRides(rides);
        }
        
    }
}
