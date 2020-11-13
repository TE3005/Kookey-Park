using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Token
    {
        public static string GetToken(string tz)
        {
            string str = "";
            int index = 0;
            for (int i = 0; i < tz.Length; i += index)
            {
                str += tz[i]*2;
                index = tz[i];
            }
            return str;
        }



        public static string AddUser(string name,string tz)
        {
            Random random = new Random();
            string str = "";
            int x = int.Parse(tz);
            int mon = 0;
            int i = 0;
            for (int j = 0; j < 9; j++)
            {
                str += tz[j];
                for (i = 0; i < int.Parse(tz[j].ToString())*2; i++)
                {
                    str += random.Next(0, 9);

                }

            }
            return str;
        }



    }
}
