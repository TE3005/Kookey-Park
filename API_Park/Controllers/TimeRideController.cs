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
    [RoutePrefix("TimeRides")]
    public class TimeRideController : ApiController
    {
        [Route("getAllTimeRides/{rideId:int}")]
        [HttpGet]
        public List<DTO.TimeRide> GetAllTimeRides(int rideId)
        {
            return BL.RidesLogic.GetTimeRides(rideId);
        }
    }
}
