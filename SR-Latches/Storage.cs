using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_Latches
{
    class Storage
    {
        public static bool SaveData(string val, bool CommaResponse)
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

        public static bool SaveLine()
        {
            //Apends to current file
            string STORAGE = "C:/Data3/truthtable.txt";
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
            string STORAGE = "C:/Data3/backupmemory.txt";
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
