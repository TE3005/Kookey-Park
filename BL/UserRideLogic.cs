using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserRideLogic
    {
        public static List<DTO.UserRideDetail> getAllUserRides(DTO.User user)
        {
            List<DTO.UserRide> usersRide = BL.Convert.UserRideConvert.ConvertUserRideToDTO(DAL.UserRideDal.getUserRidesToUser(Convert.UserConvert.ConvertUserToDAL(user)));
            List<DTO.Ride> rides = BL.Convert.RideConvert.ConvertRidesToDTO(DAL.RidesDal.GetAllRides());
            List<DTO.UserRideDetail> newUserRides = new List<DTO.UserRideDetail>();
            List<DTO.UserRide> userRideChild;



            foreach (var item in usersRide)
            {
                List<DTO.UserRideDetail> userRidesDetails = new List<DTO.UserRideDetail>();
                var q = (from i in rides
                         join ii in usersRide on i.RideId equals ii.RideId
                         where i.RideId == item.RideId && ii.UserRideId == item.UserRideId
                         select new DTO.UserRideDetail()
                         {
                             RideId = i.RideId,
                             RideName = i.RideName,
                             NumberSeets = i.NumberSeets,
                             Image = i.Image,
                             DuringUsing = i.DuringUsing,
                             TimeVp = ii.TimeVp,
                             UserRideId = ii.UserRideId,
                             UserId = ii.UserId,
                             CurrentTime = DateTime.Parse(ii.CurrentTime.ToString())
                         }).ToList();

                newUserRides.AddRange(q);
            }
            if (user.Children != null)
            {


                foreach (var child in user.Children)
                {
                    userRideChild = BL.Convert.UserRideConvert.ConvertUserRideToDTO(DAL.UserRideDal.getUserRidesToUser(Convert.UserConvert.ConvertUserToDAL(child)));
                    foreach (var item in userRideChild)
                    {
                        var q1 = (from i in rides
                                  join ii in userRideChild
                                  on i.RideId equals ii.RideId
                                  where child.UserId == ii.UserId
                                  //&& i.RideId == item.RideId
                                  && ii.UserRideId == item.UserRideId
                                  select new DTO.UserRideDetail()
                                  {
                                      RideId = i.RideId,
                                      RideName = i.RideName,
                                      NumberSeets = i.NumberSeets,
                                      Image = i.Image,
                                      DuringUsing = i.DuringUsing,
                                      TimeVp = ii.TimeVp,
                                      UserRideId = ii.UserRideId,
                                      UserId = child.UserId,
                                      CurrentTime = DateTime.Parse(ii.CurrentTime.ToString())
                                  }).ToList();

                        newUserRides.AddRange(q1);
                    }
                }

            }
            return newUserRides;
        }

        public static List<DTO.User> AddUserRide(List<DTO.UserRide> userRide)
        {
            int flag = 0;
            List<DAL.Users> users = new List<DAL.Users>();
            foreach (var item in userRide)
            {
                if (DAL.UserRideDal.CheckHours(Convert.UserRideConvert.ConvertUserRideToDAL(item)) == false)
                {
                    DAL.Users u = DAL.UserDal.ReturnUser(item.UserId);
                    users.Add(u);
                }
                else
                {
                    users.Add(null);
                }

            }
            foreach (var item in users)
            {
                if (item != null)
                    flag = 1;
            }
            if (flag == 0)
            {
                foreach (var item in userRide)
                {
                    DAL.UserRideDal.AddUserRide(Convert.UserRideConvert.ConvertUserRideToDAL(item));
                    DAL.UserRideDal.upMoneForTimeRide(item.RideId, item.CurrentTime, 1);
                }

            }

            DAL.Rides ride = DAL.RidesDal.getRide(userRide[0].RideId);
            return BL.Convert.UserConvert.ConvertUsersToDTO(users);

        }
        public static void deleteUserRide(List<DTO.UserRide> usersDelete)
        {
            int sumDownMone = 0;
            foreach (var userRideDelete in usersDelete)
            {
                DAL.UserRideDal.deleteUserRide(Convert.UserRideConvert.ConvertUserRideToDAL(userRideDelete));
                sumDownMone++;
            }
            DAL.UserRideDal.downMoneForTimeRide(usersDelete[0].RideId, usersDelete[0].CurrentTime, sumDownMone);

        }
        public static void deleteUserRide2(List<DTO.UserRide> usersDelete)
        {
            foreach (var userRideDelete in usersDelete)
            {
                DAL.UserRideDal.deleteUserRide(Convert.UserRideConvert.ConvertUserRideToDAL(userRideDelete));
            }
            
        }

        public static void deleteUserRide(int userRideId)
        {
            DAL.UserRideDal.deleteUserRide(userRideId);
        }

        public static List<DTO.UserRide> Math1(List<DTO.UserRide> userRides)
        {
            bool flag = true;
            int userId = userRides[0].UserId;
            List<DAL.UserRide> listNew = new List<DAL.UserRide>();
            foreach (var item in userRides)
            {
                if (item.UserId != userId)
                {
                    flag = false;
                }
            }
            if (flag)
            {

                List<DAL.UserRide> userRidess = BL.Convert.UserRideConvert.convertUserRidesToDAL(userRides);
                Math m = new Math();
                TimeSpan t = new TimeSpan();
                List<List<DAL.UserRide>> results = m.GetCombinationSample(userRidess.ToArray());
                int sumRides = 0;
                int mostSumRides = 0;
                List<DAL.UserRide> list = new List<DAL.UserRide>();
                TimeSpan r = new TimeSpan(24, 0, 0);
                foreach (var item in results)
                {
                    t = DAL.UserRideDal.CalacHoursForUser(item, ref sumRides);
                    if (t < r && sumRides >= mostSumRides)
                    {
                        mostSumRides = sumRides;
                        r = t;
                        list = new List<DAL.UserRide>();
                        foreach (var i in item)
                        {
                            list.Add(new DAL.UserRide()
                            {
                                CurrentTime = i.CurrentTime,
                                RideId = i.RideId,
                                Rides = i.Rides,
                                Users = i.Users,
                                UserId = i.UserId,
                                UserRideId = i.UserRideId,
                                TimeVp = i.TimeVp,
                                Timings = i.Timings
                            });
                        }
                    }

                }
                List<DTO.UserRide> listDTO = new List<DTO.UserRide>();
                listDTO = BL.Convert.UserRideConvert.ConvertUserRideToDTO(list);
                AddUserRide(listDTO);
                return listDTO;
            }
            else
            {
                Dictionary<int, List<List<DAL.UserRide>>> dictionary = new Dictionary<int, List<List<DAL.UserRide>>>();
                List<DAL.UserRide> userRidesDAL = new List<DAL.UserRide>();
                userRidesDAL = Convert.UserRideConvert.convertUserRidesToDAL(userRides);
                List<DAL.Rides> listRides = new List<DAL.Rides>();
                listRides = DAL.RidesDal.GetAllRides();
                dictionary.Add(0, new List<List<DAL.UserRide>>());
                foreach (var item in listRides)
                {
                    dictionary.Add(item.RideId, new List<List<DAL.UserRide>>());
                }
               
                
                foreach (var item in userRidesDAL)
                {
                    if(dictionary[item.RideId].Count==0)
                    {
                        dictionary[item.RideId].Add( new List<DAL.UserRide>());
                        dictionary[item.RideId][0].Add(item);
                    }
                  else if (dictionary[item.RideId][dictionary[item.RideId].Count - 1][0].TimeVp == item.TimeVp)
                    {
                        dictionary[item.RideId][dictionary[item.RideId].Count - 1].Add(item);
                    }
                    else
                    {
                        dictionary[item.RideId].Add(new List<DAL.UserRide>());
                        dictionary[item.RideId][dictionary[item.RideId].Count - 1].Add(item);
                    }

                }
                MathNew m = new MathNew();
                List<List<DAL.UserRide>> list = new List<List<DAL.UserRide>>();
                foreach (var item in dictionary)
                {
                    foreach (var i in dictionary[item.Key])
                    {
                        list.Add(i);
                    }
                }
                List<List<List<DAL.UserRide>>> listOptions = new List<List<List<DAL.UserRide>>>();
                listOptions=m.GetCombinationSample(list.ToArray());
                TimeSpan t = new TimeSpan();
                int sumRides = 0;
                int mostSumRides = 0;
                TimeSpan r = new TimeSpan(24, 0, 0);
                foreach (var item in listOptions)
                {
                    t = DAL.UserRideDal.CalacHoursWithChildren(item, ref sumRides);
                    if (t < r && sumRides >= mostSumRides)
                    {

                        listNew = new List<DAL.UserRide>();
                        mostSumRides = sumRides;
                        r = t;
                        foreach (var ii in item)
                        {
                            foreach (var i in ii)
                            {
                                listNew.Add(new DAL.UserRide()
                                {
                                    CurrentTime = i.CurrentTime,
                                    RideId = i.RideId,
                                    Rides = i.Rides,
                                    Users = i.Users,
                                    UserId = i.UserId,
                                    UserRideId = i.UserRideId,
                                    TimeVp = i.TimeVp,
                                    Timings = i.Timings
                                });
                            }
                           
                        }
                    }

                }

            }

             List<DTO.UserRide> listUserRidesDTO= BL.Convert.UserRideConvert.ConvertUserRideToDTO(listNew);
            BL.UserRideLogic.AddUserRide(listUserRidesDTO);
            return listUserRidesDTO;

        }


       
    }
}
