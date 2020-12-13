using System;
using System.Collections.Generic;
using System.IO;

namespace ReadFromFile
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
            if (!File.Exists(@"C:\Data\inputdata.txt"))
            {
                var fs = new FileStream(@"C:\Data\inputdata.txt", FileMode.Create);
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
            }
            string[] STORAGE = System.IO.File.ReadAllLines(@"C:\Data\inputdata.txt");
            
            
               
            
            // Display the file contents by using a foreach loop.
            var inputRow = new TruthTable();
            var inputList = new List<TruthTable>();
            foreach (string data in STORAGE)
            {
                var dataElements = data.Split(',');
                // Use a tab to indent each line of the file.

                inputRow.A = Utility.ConvertToBoolean(dataElements[0]);
                inputRow.X = Utility.ConvertToBoolean(dataElements[1]);
                inputRow.D = Utility.ConvertToBoolean(dataElements[2]);
                inputRow.R = Utility.ConvertToBoolean(dataElements[3]);
                inputList.Add(inputRow);
                bool YesComma = true;
                bool NoComma = false;

               // SaveData(line);
                SaveData(inputRow.A.ToString(), YesComma);
                SaveData(inputRow.X.ToString(), YesComma);
                SaveData(inputRow.D.ToString(), YesComma);
                SaveData(inputRow.R.ToString(), NoComma);
                SaveLine();
                //backup memory data
                BackupData(inputRow.A.ToString());
                BackupData(inputRow.X.ToString());
                BackupData(inputRow.D.ToString());
                BackupData(inputRow.R.ToString());
                //Control + C or Control + Q pressed will save current line to file
                Console.WriteLine("\t" + data);
                //stope with Read key to test Control + C 
                //Console.ReadKey();

            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        public static bool SaveData(string val, bool CommaResponse)
        {
            string STORAGE = "C:/Data/truthtable.txt";
            
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
            string STORAGE = "C:/Data/truthtable.txt";
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
            string STORAGE = "C:/Data/backupmemory.txt";
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
