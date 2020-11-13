using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            API_Park.Controllers.UserController u = new API_Park.Controllers.UserController();
            u.Login(new User() {IdUser=5,NameUser="cvcvxc",Password="5435" });
        }
    }
}
