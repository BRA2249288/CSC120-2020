using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertbyte
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int ans = a / 2; 

            //base 2 0 and 1 

            byte x = 0b_1000; //2

            // int b = x >> 2;
            int b = x <<3; 
            Console.WriteLine($"{Convert.ToString(b, toBase: 2)}"); //Output: 1000 
            var test = ""; 

        }
    }
}
