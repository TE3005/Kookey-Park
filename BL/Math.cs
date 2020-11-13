using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Math
    {

        static List<List<DAL.UserRide>> comb;
        static bool[] used;
        public static List<List<DAL.UserRide>> alloptions;
        public Math()
        {
            alloptions = new List<List<DAL.UserRide>>();
        }
        public List<List<DAL.UserRide>> GetCombinationSample(DAL.UserRide [] arr )
        {
            
            used = new bool[arr.Length];
            for (int i = 0; i < used.Length; i++)
            {
                used[i] = false;
            }
            comb = new List<List<DAL.UserRide>>();
            List<DAL.UserRide> c = new List<DAL.UserRide>();
            GetComb(arr, 0, c);
            foreach (var item in comb)
            {
                List<DAL.UserRide> numbers = new List<DAL.UserRide>();
                foreach (var x in item)
                {
                    numbers.Add(x);
                }
                alloptions.Add(numbers);
            }
            return alloptions;
        }
        static void GetComb(DAL.UserRide[] arr, int colindex, List<DAL.UserRide> c)
        {

            if (colindex >= arr.Length)
            {
                comb.Add(new List<DAL.UserRide>(c));
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    c.Add(arr[i]);
                    GetComb(arr, colindex + 1, c);
                    c.RemoveAt(c.Count - 1);
                    used[i] = false;
                }
            }

        }
    }
}
