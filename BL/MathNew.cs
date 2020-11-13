using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
namespace BL
{
    public class MathNew
    {
        static List<List<List<DAL.UserRide>>> comb;
        static bool[] used;
        public static List<List<List<DAL.UserRide>>> alloptions;
        public MathNew()
        {
            alloptions = new List<List<List<DAL.UserRide>>>();
        }
        public List<List<List<DAL.UserRide>>> GetCombinationSample(List<DAL.UserRide>[] arr)
        {

            used = new bool[arr.Length];
            for (int i = 0; i < used.Length; i++)
            {
                used[i] = false;
            }
            comb = new List<List<List<DAL.UserRide>>>();
            List<List<DAL.UserRide>> c = new List<List<DAL.UserRide>>();
            GetComb(arr, 0, c);
            foreach (var item in comb)
            {
                List<List<DAL.UserRide>> numbers = new List<List<DAL.UserRide>>();
                foreach (var x in item)
                {
                    numbers.Add(x);
                }
                alloptions.Add(numbers);
            }
            return alloptions;
        }
        static void GetComb(List<DAL.UserRide>[] arr, int colindex, List<List<DAL.UserRide>> c)
        {

            if (colindex >= arr.Length)
            {
                comb.Add(new List<List<DAL.UserRide>>(c));
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


