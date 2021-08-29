using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RidesDal
    {
        public static List<RidesVp> getAllVpRides()
        {
            List<TimeRide> allTimeRides = new List<TimeRide>();
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    TimeSpan timeNow = DateTime.Now.TimeOfDay;
                    TimeSpan fiveMinutes = new TimeSpan(0, 5, 0);
                    List<Rides> rides = GetAllRides();
                    List<RidesVp> ridesVp = new List<RidesVp>();
                    int NumMinutes = 0;
                    
                    
                    foreach (var ride in rides)
                    {
                        foreach (var time in park.TimeRide)
                        {
                            if(time.RideId==ride.RideId && time.Mone<ride.NumberSeets &&time.TimeStart>timeNow 
                                && time.TimeStart-timeNow<= fiveMinutes
                                )
                            {
                                ridesVp.Add(new RidesVp()
                                {
                                    RideId = ride.RideId,
                                    RideName = ride.RideName,
                                    Image = ride.Image,
                                    AgeUser = ride.AgeUser,
                                    DuringUsing = ride.DuringUsing,
                                    NumberSeets = ride.NumberSeets,
                                    CurrentTime = DateTime.Parse(time.TimeStart.ToString()),
                                    Mone = time.Mone,
                                    NumMinutes=5
                                    
                                });
                            }

                            if (time.RideId == ride.RideId && time.Mone < ride.NumberSeets && time.TimeStart > timeNow
                               && time.TimeStart - timeNow <= new TimeSpan(0,7,0)
                               )
                            {
                                ridesVp.Add(new RidesVp()
                                {
                                    RideId = ride.RideId,
                                    RideName = ride.RideName,
                                    Image = ride.Image,
                                    AgeUser = ride.AgeUser,
                                    DuringUsing = ride.DuringUsing,
                                    NumberSeets = ride.NumberSeets,
                                    CurrentTime = DateTime.Parse(time.TimeStart.ToString()),
                                    Mone = time.Mone,
                                    NumMinutes = 7

                                });
                            }

                            if (time.RideId == ride.RideId && time.Mone < ride.NumberSeets && time.TimeStart > timeNow
                               && time.TimeStart - timeNow <= new TimeSpan(0,10,0)
                               )
                            {
                                ridesVp.Add(new RidesVp()
                                {
                                    RideId = ride.RideId,
                                    RideName = ride.RideName,
                                    Image = ride.Image,
                                    AgeUser = ride.AgeUser,
                                    DuringUsing = ride.DuringUsing,
                                    NumberSeets = ride.NumberSeets,
                                    CurrentTime = DateTime.Parse(time.TimeStart.ToString()),
                                    Mone = time.Mone,
                                    NumMinutes = 10

                                });
                            }
                        }
                    }
                    return ridesVp;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static List<TimeRide> getAllTimeRide(int rideId)
        {
            List<TimeRide> allTimeRides = new List<TimeRide>();
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    TimeSpan timeNow = DateTime.Now.TimeOfDay;
                    Rides ride = getRide(rideId);
                    int sumPlaces = ride.NumberSeets;
                    TimeSpan endOfShift = new TimeSpan(16, 0, 0);
                    if (timeNow > endOfShift)
                        endOfShift = new TimeSpan(24, 0, 0);
                    foreach (var item in park.TimeRide)
                    {
                        if (item.RideId == ride.RideId && item.TimeStart > timeNow +new TimeSpan(0,10,0)&& item.TimeStart < endOfShift && sumPlaces - item.Mone > 0)
                        {
                            allTimeRides.Add(item);
                        }
                    }
                    return allTimeRides;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
      

        public static List<Rides> GetAllRides()

        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    return park.Rides.ToList();
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public static Rides getRide(int RideId)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    foreach (var item in park.Rides)
                    {
                        if (item.RideId == RideId)
                            return item;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public static double SecondsToWaitForRide(Rides ride)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    TimeSpan timeNow = DateTime.Now.TimeOfDay;
                    foreach (var item in park.TimeRide)
                    {
                        if (item.TimeStart > timeNow && item.RideId == ride.RideId && item.Mone < ride.NumberSeets)
                        {
                            return item.TimeStart.TotalSeconds;
                        }
                    }
                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }

        public static double SecondsToWaitForRide2(Rides ride)
        {
            try
            {
                using (Amusement_ParkEntities2 park = new Amusement_ParkEntities2())
                {
                    TimeSpan timeNow = DateTime.Now.TimeOfDay;
                    foreach (var item in park.TimeRide)
                    {
                        if (item.TimeStart > timeNow + new TimeSpan(0, 10, 0) && item.RideId == ride.RideId && item.Mone < ride.NumberSeets)
                        {
                            return item.TimeStart.TotalSeconds;
                        }
                    }
                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }


    }
}
