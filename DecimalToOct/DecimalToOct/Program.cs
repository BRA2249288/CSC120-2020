using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalToOct
{
    class Program
    {
     
          
       
        public static void Main()
        {

            // if 88 is base 130 be the result 
            // if 2333 is base 4435 be the result
            int n = 2333; 
            // array to store octal number
            int[] octalNum = new int[100];

            // counter for octal number array
            int i = 0;
            while (n != 0)
            {

                // storing remainder in octal array % is the MOD so remainder of the number of 8 than divide by 8
                octalNum[i] = n % 8;
                n = n / 8;
                i++;
            }

           
            System.Console.WriteLine("Result:");
            var result = 0; 
            for (int j = i - 1; j >= 0; j--)
            {
                // Printing octal number array in reverse order
                Console.Write(octalNum[j]);
                //Concate int strings to get results 
                result = int.Parse(result.ToString() + octalNum[j].ToString());
            }

            Console.WriteLine("This result should match with top Result: " + result);
            Console.ReadLine(); 

             
            


        }
    }
}
