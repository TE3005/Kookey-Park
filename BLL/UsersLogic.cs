
using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class UsersLogic
    {
      
        public static  User loginUser(User user)
        {
            User current_user = new User();
            using (DAL.Data)
            {

            }
            return current_user;
        }
    }
}
