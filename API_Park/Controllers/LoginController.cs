using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DTO;

namespace API_Park.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("login")]
    public class LoginController : ApiController
    {
        //{
        //    [Route("login")]
        //    [HttpPost]
        //    public DTO.User Login(User user)
        //    {
        //        DTO.User userDTO = BL.UsersLogic.loginUser(user);
        //        return userDTO;
        //    }
        
    }
}
