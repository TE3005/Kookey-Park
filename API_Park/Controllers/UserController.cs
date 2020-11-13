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
    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        [HttpPost]
        public  DTO.User Register(User user)
        {
            return BL.UsersLogic.Register(user);
        }
       
        [HttpPut]
        public DTO.User Update([FromBody] DTO.User user)
        {
            return BL.UsersLogic.UpdateDetails(user.UserId,user);
        }
        [Route("login")]
        [HttpPost]
        public DTO.User Login(User user)
        {
            DTO.User userDTO = BL.UsersLogic.loginUser(user);
            return userDTO;
        }
    }
}
