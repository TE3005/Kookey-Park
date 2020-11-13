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
        public static DTO.User UpdateDetails(int userId,DTO.User user)
        {
           DAL.Users userDal = BL.Convert.UserConvert.ConvertUserToDAL(user);
            return BL.Convert.UserConvert.ConvertUserToDTO( DAL.UserDal.ChangeDetails(userId, userDal));
        }
        public static DTO.User loginUser(DTO.User user)
        {
           DTO.User userDTO= Convert.UserConvert.ConvertUserToDTO(DAL.UserDal.Login( Convert.UserConvert.ConvertUserToDAL(user)));
            if (userDTO != null)
            {
                List<DAL.Users> children = DAL.UserDal.ReturnChildrenForUser(userDTO.UserId);
                userDTO.Children = new List<DTO.User>();
                if (children != null && children.Count != 0)
                {
                    foreach (var item in children)
                    {
                        DTO.User userD = Convert.UserConvert.ConvertUserToDTO(item);
                        userDTO.Children.Add(userD);
                    }
                }
            }
            return userDTO;


        }
        public static DTO.User  Register(DTO.User userWithChildren)
        {
            List<DTO.User> users = new List<DTO.User>();
            Users u= DAL.UserDal.Register(Convert.UserConvert.ConvertUserToDAL(userWithChildren));
            DTO.User us= BL.Convert.UserConvert.ConvertUserToDTO(u);
            us.Children = new List<User>();
            if (userWithChildren.Children!=null)
            {
                foreach (var userToAdd in userWithChildren.Children)
                {
                    users.Add(new DTO.User() { Tz = userToAdd.Tz, UserName = userToAdd.UserName, Age = userToAdd.Age,parentId=us.UserId });
                }
                foreach (var item in users)
                {
                    Users uu=DAL.UserDal.Register(Convert.UserConvert.ConvertUserToDAL(item));
                    us.Children.Add(BL.Convert.UserConvert.ConvertUserToDTO(uu));
                }
            }
            return us;
            
        }

    }
}
