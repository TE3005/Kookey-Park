using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRideDal
    {
        public static void AddUserRide(UserRide userRide)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    park.UserRide.Add(userRide);
                    park.SaveChanges();
                }

            }
            catch (Exception e)
            {
                return;
            }

        }
        public static List<UserRide> getUserRidesToUser(Users user)
        {
            List<UserRide> userRides = new List<UserRide>();
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    foreach (var item in park.UserRide)
                    {

                        //todo add to userRides the children of this user
                        if (user.UserId == item.UserId)
                        {
                            userRides.Add(item);
                        }

                    }
                    return userRides;
                }

            }
            catch (Exception e)
            {
                return null;
            }

        }
        public static List<DAL.UserRide> getAllUserRides()
        {

            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    return park.UserRide.ToList();
                }

            }
            catch (Exception e)
            {
                return null;
            }

        }


        public static void deleteUserRide(UserRide u)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {

                    foreach (var item in park.TimeRide)
                    {
                        if (item.RideId == u.RideId && item.TimeStart == u.CurrentTime)
                        {
                            item.Mone--;
                        }
                    }
                    foreach (var i in park.UserRide)
                    {
                        if (i.UserRideId == u.UserRideId)
                        {
                            park.UserRide.Remove(i);

                            break;
                        }
                    }
                    park.SaveChanges();

                }

            }
            catch (Exception e)
            {
                return;
            }

        }
        public static int getWaitingForRide(int rideId)
        {

            try
            {
                int waiting = 0;
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    foreach (var item in park.UserRide)
                    {
                        if (item.RideId == rideId)
                        {
                            waiting++;
                        }
                    }
                    return waiting;
                }

            }
            catch (Exception e)
            {
                return -1;
            }

        }
        public static void upMoneForTimeRide(int RideId, TimeSpan time, int sumToUp)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    foreach (var item in park.TimeRide)
                    {
                        if (item.RideId == RideId && item.TimeStart == time)
                        {
                            item.Mone += sumToUp;
                        }
                    }
                    park.SaveChanges();

                }
            }
            catch (Exception e)
            {

            }
        }
        public static void downMoneForTimeRide(int RideId, TimeSpan time, int sumToDown)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    foreach (var item in park.TimeRide)
                    {
                        if (item.RideId == RideId && item.TimeStart == time)
                        {
                            item.Mone -= sumToDown;
                        }
                    }

                }
            }
            catch (Exception e)
            {

            }
        }
        public static Boolean CheckHours(UserRide userRide)
        {
            Users user = new Users() { UserId = userRide.UserId };
            List<UserRide> allUserRides = new List<UserRide>();
            allUserRides = getUserRidesToUser(user);
            List<Rides> allRides = new List<Rides>();
            allRides = RidesDal.GetAllRides();
            TimeSpan? timeRegister = new TimeSpan();
            timeRegister = (userRide.CurrentTime);
            TimeSpan timeStart = new TimeSpan();
            TimeSpan timeEnd = new TimeSpan();
            TimeSpan minutes = new TimeSpan(0, 5, 0);
            foreach (var item in allUserRides)
            {
                if (item.CurrentTime.HasValue)
                {
                    timeStart = item.CurrentTime.Value;
                    timeEnd = item.CurrentTime.Value;
                }

                foreach (var i in allRides)
                {
                    if (item.RideId == i.RideId)
                    {
                        timeEnd = timeEnd.Add(i.DuringUsing);
                        timeEnd = timeEnd.Add(minutes);
                        timeStart = timeStart - new TimeSpan(0, 5, 0);
                        break;
                    }
                }
                if (timeRegister >= timeStart && timeRegister <= timeEnd)
                    return false;
            }
            return true;

        }
        public static TimeSpan CalacHoursWithChildren(List<List<UserRide>> userRides, ref int sumRides)
        {
            sumRides = 0;
            TimeSpan timeNow = new TimeSpan();
            timeNow = DateTime.Now.TimeOfDay;
            TimeSpan endOfShift = new TimeSpan(15, 0, 0);
            if (timeNow > endOfShift)
                endOfShift = new TimeSpan(24, 0, 0);
            TimeSpan duringTime = new TimeSpan();
            TimeSpan during = new TimeSpan();
            TimeSpan add = new TimeSpan();
            duringTime = DateTime.Now.TimeOfDay;
            int sumTimes = 0;
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    int flag = 0;
                    foreach (var item1 in userRides)
                    {
                        if (sumTimes > 0)
                        {
                            duringTime = during;
                            duringTime = duringTime.Add(add);
                            duringTime = duringTime.Add(new TimeSpan(0, 5, 0));
                        }
                        sumTimes++;
                        foreach (var item in item1)
                        {
                            flag = 0;
                            Rides ride = DAL.RidesDal.getRide(item.RideId);
                            int numberSeets = ride.NumberSeets;
                            foreach (var time in park.TimeRide)
                            {
                                if (flag == 1)
                                {
                                    break;
                                }
                                if (item.RideId == time.RideId && time.Mone < numberSeets && time.TimeStart > duringTime && time.TimeStart < endOfShift)
                                {
                                    item.CurrentTime = time.TimeStart;
                                    if (CheckHours(item))
                                    {
                                        during = time.TimeStart;
                                        add.Add(ride.DuringUsing);
                                        sumRides++;
                                        flag = 1;
                                    }
                                }
                            }
                        }

                    }
                    return duringTime;
                }
            }
            catch
            {
                return new TimeSpan();
            }

        }
        public static TimeSpan CalacHoursForUser(List<UserRide> userRides, ref int sumRides)
        {
            sumRides = 0;
            TimeSpan timeNow = new TimeSpan();
            timeNow = DateTime.Now.TimeOfDay;
            TimeSpan endOfShift = new TimeSpan(15, 0, 0);
            if (timeNow > endOfShift)
                endOfShift = new TimeSpan(24, 0, 0);
            TimeSpan duringTime = new TimeSpan();
            duringTime = DateTime.Now.TimeOfDay;
            int flag = 0;
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    foreach (var item in userRides)
                    {
                        flag = 0;
                        Rides ride = DAL.RidesDal.getRide(item.RideId);
                        int numberSeets = ride.NumberSeets;
                        foreach (var time in park.TimeRide)
                        {
                            if (flag == 1)
                            {
                                break;
                            }
                            if (item.RideId == time.RideId && time.Mone < numberSeets && time.TimeStart > duringTime && time.TimeStart < endOfShift)
                            {
                                item.CurrentTime = time.TimeStart;
                                if (CheckHours(item))
                                {
                                    duringTime = time.TimeStart;
                                    duringTime = duringTime.Add(ride.DuringUsing);
                                    duringTime = duringTime.Add(new TimeSpan(0, 5, 0));
                                    sumRides++;
                                    flag = 1;
                                }
                            }
                        }
                    }
                    return duringTime;
                }
            }
            catch
            {
                return new TimeSpan();
            }

        }

        public static void deleteUserRide(int userRideId)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    UserRide u = park.UserRide.First(a => a.UserRideId == userRideId);
                    foreach (var item in park.TimeRide)
                    {
                        if (item.RideId == u.RideId && item.TimeStart == u.CurrentTime)
                        {
                            item.Mone--;
                        }
                    }
                    park.UserRide.Remove(u);
                    park.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("error");
            }





        }
    }
    }
