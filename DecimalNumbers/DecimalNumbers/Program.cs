using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {  ///345790
            var decimalNumber = 345790;

            // Step one you need to each digit
            // The first Step to Convert it to Value to Spring -> Character
            // So that you can get to each 2 3 and 9 

            var characterArray = decimalNumber.ToString().ToCharArray();
            var result = 0;
            var maxpower = characterArray.Length;
            var counter = 0; 
            foreach (var item in characterArray)
            {   
                
                var digit = int.Parse(item.ToString());
                var power = Math.Pow(10, maxpower - ++counter);
                result = result + (int)(digit * power);
                
                Console.WriteLine(item);
                

            }
            Console.WriteLine(result);

        }
    }
}
