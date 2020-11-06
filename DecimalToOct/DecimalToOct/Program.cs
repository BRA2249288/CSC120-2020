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
            int n = 2333; //Create array to store each number so you have a place for the remainder
            // array to store octal number
            int[] octalNum = new int[100];//Set Decimal place to 100 //setup a counter for array

            // counter for octal number array
            int i = 0;//setup a loop to go through the remainders and store them these are the R above
            while (n != 0) //Is the Mod modifier getting the Remainder
            {

                // storing remainder in octal array % is the MOD so remainder of the number of 8 than divide by 8
                octalNum[i] = n % 8; //Is the Mod modifier getting the Remainder
                n = n / 8; // add the current number left over and divide it by 8 until 0 which stops loop
                i++; //Add one to the counter to loop once
            }

           
            System.Console.WriteLine("Result:");
            var result = 0; // store result.
            for (int j = i - 1; j >= 0; j--) 
 //perform loop until j is empty basically going backwards from length down to zero to output the numbers;
            {
                // Printing octal number array in reverse order
                Console.Write(octalNum[j]);
                //Concate int strings to get results 
                result = int.Parse(result.ToString() + octalNum[j].ToString());
// converts so can add result and add each digit of j so it’s not lost and stored in the result. 
            }

            Console.WriteLine("This result should match with top Result: " + result);
            Console.ReadLine(); 

               
            


        }
    }
}
