using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World");
            AddTwoNumbers(4, 6);
        }

        private static void AddTwoNumbers(int v1, int v2)
        {
            var results = v1 + v2;
            Console.WriteLine(results); 
        }
    }
}
