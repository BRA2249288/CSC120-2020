using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_Latches
{
    class Program
    {
        static void Main(string[] args)
        {
            //RSQq
            //0010 1
            //1001 2
            //0001 3
            //0110 4
            //0101 5
            //1010 6
            //1100 7
            if (!File.Exists(@"C:\Data3\inputdata.txt"))
            {
                var fs = new FileStream(@"C:\Data3\inputdata.txt", FileMode.Create);
                var sw = new StreamWriter(fs);
                sw.WriteLine("R,S,Q,q");
                sw.WriteLine("0,0,1,0");
                sw.WriteLine("1,0,0,1");
                sw.WriteLine("0,0,0,1");
                sw.WriteLine("0,1,1,0");
                sw.WriteLine("0,1,0,1");
                sw.WriteLine("1,0,1,0");
                sw.WriteLine("1,1,0,0");
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            string[] STORAGE = System.IO.File.ReadAllLines(@"C:\Data3\inputdata.txt");
            List<IndentityInput> inputs = BuildtruthTable();
            var inputRow = new TruthTable();
            var inputList = new List<TruthTable>();
            // Step 1 complete the rest of the input through table values

            // Step 2 now loop through each item rown in the truth table
            ProcessLogicGates(inputs);
            foreach (string data in STORAGE)
            {
                var dataElements = data.Split(',');
                // Use a tab to indent each line of the file.

                inputRow.R = Utility.ConvertToBoolean(dataElements[0]);
                inputRow.S = Utility.ConvertToBoolean(dataElements[1]);
                inputRow.Q = Utility.ConvertToBoolean(dataElements[2]);
                inputRow.q = Utility.ConvertToBoolean(dataElements[3]);
                inputList.Add(inputRow);
                bool YesComma = true;
                bool NoComma = false;

                // SaveData(line);
                SaveData(inputRow.R.ToString(), YesComma);
                SaveData(inputRow.S.ToString(), YesComma);
                SaveData(inputRow.Q.ToString(), YesComma);
                SaveData(inputRow.q.ToString(), NoComma);
                SaveLine();
                //backup memory data
                BackupData(inputRow.R.ToString());
                BackupData(inputRow.S.ToString());
                BackupData(inputRow.Q.ToString());
                BackupData(inputRow.q.ToString());
                //Control + C or Control + Q pressed will save current line to file
                Console.WriteLine("\t" + data);
                //stope with Read key to test Control + C 
                //Console.ReadKey();

            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }

        private static bool BackupData(string val)
        {
            string STORAGE = "C:/Data3/backupmemory.txt";
            var fs = new FileStream(STORAGE, FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.WriteLine(val);
            sw.Flush();
            sw.Close();
            fs.Close();
            return true;
        }

        private static bool SaveLine()
        {
            string STORAGE = "C:/Data3/inputdata.txt";
            var fs = new FileStream(STORAGE, FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.Write("");
            sw.Flush();
            sw.Close();
            fs.Close();
            return true;
        }

        private static bool SaveData(string val, bool CommaResponse)
        {
            string STORAGE = "C:/Data3/truthtable.txt";

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

        private static void ProcessLogicGates(List<IndentityInput> inputs)
        {
            foreach (var item in inputs)
            {
                var identity = new Identity();
                identity.SetInputS = item.S;
                identity.SetInputR = item.R;
                identity.SetInputQ = item.Q;
                identity.SetInputq = item.q;

                var output = identity.Validate();
                Console.WriteLine($" S = {identity.SetInputS}," +
                    $" R = {identity.SetInputR}, " +
                    $" Q = {identity.SetInputQ}" +
                    $" q = {identity.SetInputq}" +
                    $" OutPut= {output}");
            }
        }

        private static List<IndentityInput> BuildtruthTable()
        {
            var inputs = new List<IndentityInput>();
            inputs.Add(new IndentityInput() { R = false, S = false, Q = true, q = false });
            inputs.Add(new IndentityInput() { R = true, S = false, Q = false, q = true });
            inputs.Add(new IndentityInput() { R = false, S = false, Q = false, q = true });
            inputs.Add(new IndentityInput() { R = false, S = true, Q = true, q = false });
            inputs.Add(new IndentityInput() { R = false, S = true, Q = false, q = true });
            inputs.Add(new IndentityInput() { R = true, S = false, Q = true, q = false });
            inputs.Add(new IndentityInput() { R = true, S = true, Q = false, q = false });
            return inputs;
        }
    }

   

    class IndentityInput
    {
        public bool S { get; set; }
        public bool R { get; set; }
        public bool Q { get; set; }
        public bool q { get; set; }

    }
    class TruthTable
    {

        public Boolean S { get; set; }
        public Boolean R { get; set; }
        public Boolean Q { get; set; }
        public Boolean q { get; set; }
    }
    class Identity
    {
        public bool SetInputS { get; set; }

        public bool SetInputR { get; set; }


        public bool SetInputQ { get; set; }


        public bool SetInputq { get; set; }

        public bool Output { get; set; }

        public bool Validate()
        {
            var result = true;

            return result;

        }
    }
}
