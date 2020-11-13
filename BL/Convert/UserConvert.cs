using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Convert
{
    public class UserConvert
    {
        public static DAL.Users ConvertUserToDAL(DTO.User user)
        {
            if (user == null)
                return null;
            return new DAL.Users()
            {
                UserId=user.UserId,
                UserName=user.UserName,
                Tz = user.Tz,
                ParentId =user.parentId,
               NumberChildren=user.NumberChildren,
                Age=user.Age,
                Phone=user.Phone
               
               
            };

        }
        public static DTO.User ConvertUserToDTO(DAL.Users user)
        {
            if(user==null)
                return null;
            return new DTO.User()
            {
             UserId=user.UserId,
             UserName=user.UserName,
             Tz=user.Tz,
             parentId=user.ParentId,
             Age=user.Age,
             NumberChildren=user.NumberChildren,
             Phone=user.Phone
            };

        }
        public static List<DTO.User> ConvertUsersToDTO(List<DAL.Users> users)
        {
            List<DTO.User> usersDTO = new List<DTO.User>();

            foreach (var user in users)
            {
                if (user == null)
                {
                    usersDTO.Add(null);
                }
                else
                {
                    DTO.User u = new DTO.User()

                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                        Tz = user.Tz,
                        parentId = user.ParentId,
                        Age = user.Age,
                        NumberChildren = user.NumberChildren,
                        Phone = user.Phone
                    };
                    usersDTO.Add(u);
                }
            }
            return usersDTO;
        }
      
      
    }
}
