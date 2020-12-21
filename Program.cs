using System;
using System.Collections.Generic;
using System.IO;

namespace SimpleCircuits
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadTruthTable();
        }

         private static void ReadTruthTable()
        {
            // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            //if file doesn't exist create input data .txt 
            if (!File.Exists(@"C:\Data2\inputdata.txt"))
            {
                //commented out new updated code 
                var fs = new FileStream(@"C:\Data2\inputdata.txt", FileMode.Create);
                var sw = new StreamWriter(fs);
                sw.WriteLine("A,D,X,L");
                sw.WriteLine("0,0,0,0");
                sw.WriteLine("0,0,1,0");
                sw.WriteLine("0,1,0,1");
                sw.WriteLine("0,1,1,1");
                sw.WriteLine("1,0,0,1");
                sw.WriteLine("1,1,0,1");
                sw.WriteLine("1,1,1,1");
                sw.Flush();
                sw.Close();
                fs.Close();
                //var fs = new FileStream(@"C:\Data2\inputdata.txt", FileMode.Create);
                //var sw = new StreamWriter(fs);
                //sw.WriteLine("I1,V1,V2,R1,D1");
                //sw.WriteLine("2,0,0,0,0");
                //sw.WriteLine("3,0,0,1,0");
                //sw.WriteLine("4,0,1,0,1");
                //sw.WriteLine("5,0,1,1,1");
                //sw.WriteLine("6,1,0,0,1");
                //sw.WriteLine("7,1,1,0,1");
                //sw.WriteLine("8,1,1,1,1");
                //sw.WriteLine("9,0,0,0,0");
                //sw.WriteLine("2,0,0,1,0");
                //sw.Flush();
                //sw.Close();
                //fs.Close();
            }
            string[] STORAGE = System.IO.File.ReadAllLines(@"C:\Data2\inputdata.txt");
            
            
               
            
            // Display the file contents by using a foreach loop.
            var inputRow = new TruthTable();
            var inputList = new List<TruthTable>();
            foreach (string data in STORAGE)
            {
                var dataElements = data.Split(',');
                // Use a tab to indent each line of the file.
                
                                //int addRes = 3;
                //int inputCir = inputRow.I1;
                //int totalResult = addRes * inputCir; 

                inputRow.A = Utility.ConvertToBoolean(dataElements[0]);
                inputRow.X = Utility.ConvertToBoolean(dataElements[1]);
                inputRow.D = Utility.ConvertToBoolean(dataElements[2]);
                inputRow.R = Utility.ConvertToBoolean(dataElements[3]);
                inputList.Add(inputRow);
                bool YesComma = true;
                bool NoComma = false;
                
                //totalResult = int.Parse(dataElements[0]);
                //inputRow.V1 = Utility.ConvertToBoolean(dataElements[1]);
                //inputRow.V2 = Utility.ConvertToBoolean(dataElements[2]);
                //inputRow.D1 = Utility.ConvertToBoolean(dataElements[4]);
                //inputRow.R1 = Utility.ConvertToBoolean(dataElements[5]);
                //inputList.Add(inputRow);
                //bool YesComma = true;
                //bool NoComma = false;

               // SaveData(line);
               //Outputs the Simple Circut results
                SaveData(inputRow.A.ToString(), YesComma);
                Console.Write(inputRow.A.ToString() + ",");
                SaveData(inputRow.X.ToString(), YesComma);
                Console.Write(inputRow.X.ToString() + ",");
                SaveData(inputRow.D.ToString(), YesComma);
                Console.Write(inputRow.D.ToString() + ",");
                SaveData(inputRow.R.ToString(), NoComma);
                Console.Write(inputRow.R.ToString() + ",");
                Console.WriteLine();
                SaveLine();
                
                //SaveData(inputRow.I1.ToString(), YesComma);
                //Console.Write(inputRow.I1.ToString() + ",");
                //SaveData(inputRow.V1.ToString(), YesComma);
                //Console.Write(inputRow.V1.ToString() + ",");
                //SaveData(inputRow.V2.ToString(), YesComma);
                //Console.Write(inputRow.V2.ToString() + ",");
                //SaveData(inputRow.D1.ToString(), YesComma);
                //Console.Write(inputRow.D1.ToString() + ",");
                //SaveData(inputRow.R1.ToString(), NoComma);
                //Console.Write(inputRow.R1.ToString() + ",");
                //Console.WriteLine();
                //SaveLine();
                //backup memory data
                BackupData(inputRow.A.ToString());
                BackupData(inputRow.X.ToString());
                BackupData(inputRow.D.ToString());
                BackupData(inputRow.R.ToString());
                //BackupData(inputRow.I1.ToString());
                //BackupData(inputRow.V1.ToString());
                //BackupData(inputRow.V2.ToString());
                //BackupData(inputRow.D1.ToString());
                //BackupData(inputRow.R1.ToString());
                //Control + C or Control + Q pressed will save current line to file
               // Console.WriteLine("\t" + data);
                //stope with Read key to test Control + C 
                //Console.ReadKey();

            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        public static bool SaveData(string val, bool CommaResponse)
        {
            string STORAGE = "C:/Data2/truthtable.txt";
            
                var fs = new FileStream(STORAGE, FileMode.Append);
                var sw = new StreamWriter(fs);
            //does it need a comma? 
                if (CommaResponse == true)
                {
                    sw.Write(val + ",");
                }
                else
                {
                    sw.Write(val);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            return true;
        }

        public static bool SaveLine()
        {
            //Apends to current file
            string STORAGE = "C:/Data2/truthtable.txt";
            var fs = new FileStream(STORAGE, FileMode.Append);
            var sw = new StreamWriter(fs);
            sw.WriteLine();
            sw.Flush();
            sw.Close();
            fs.Close();
            return true;
        }
        public static bool BackupData(string val)
        {    
            //save current backup data creates 
            string STORAGE = "C:/Data2/backupmemory.txt";
            var fs = new FileStream(STORAGE, FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.WriteLine(val);
            sw.Flush();
            sw.Close();
            fs.Close();
            return true;
        }
    }
}
