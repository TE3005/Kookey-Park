using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDal
    {
        //Login
        public static Users Login(Users user)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    foreach (var item in park.Users)
                    {
                        if (item.Tz == user.Tz)
                            return item;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public static Users Register(Users user)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    park.Users.Add(user);
                    park.SaveChanges();
                    return user; 
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public static Users ReturnUser(int UserId)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    foreach (var item in park.Users)
                    {
                        if(item.UserId==UserId)
                        {
                            return item;
                        }
                    }
                }
                return null;
            }
            catch
            {
                return null; 
            }
        }
        public static List<Users> ReturnChildrenForUser(int userId)
        {
            try
            {
                List<Users> children = new List<Users>();
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    foreach (var item in park.Users)
                    {
                        if(item.ParentId==userId)
                        {
                            children.Add(item);
                        }
                    }
                }
                return children;
            }
            catch
            {
                return null;
            }
        }
        public static DAL.Users ChangeDetails(int userId,DAL.Users userDAL)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    DAL.Users user = new Users();
                    foreach (var item in park.Users)
                    {
                        if(item.UserId==userId)
                        {
                            item.UserName = userDAL.UserName;
                            user= item;
                            break;
                        }
                    }

                    park.SaveChanges();
                    return user;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
