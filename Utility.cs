using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCircuits
{
    class Utility
    {
        public static Boolean ConvertToBoolean(string data)
        {
            return (data == "1" ? true : false);
        }

        public static int ConvertToBit(Boolean data)
        {
            return Convert.ToInt16(data);
        }
    }
}
