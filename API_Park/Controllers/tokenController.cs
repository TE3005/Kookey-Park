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
    [RoutePrefix("token")]
    public class tokenController : ApiController
    {        [HttpGet]
        public string Token(string name, string tz)
        {
            return BL.Token.AddUser(name, tz);
        }

    }
}
