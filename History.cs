using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class History
    {
        private string processes, conclusion, path;
        FileInfo file;
        StreamWriter writer = null;
        StreamReader reader = null;

        public History(string processes, string conclusion) 
        { 
            this.processes = processes;
            this.conclusion = conclusion;
            path = @"C:\Users\User\Desktop\DOSYALAR\NTP\My Project\Calculator\History.txt";
            file = new FileInfo(path);
        }

        public History()
        {
            path = @"C:\Users\User\Desktop\DOSYALAR\NTP\My Project\Calculator\History.txt";
            file = new FileInfo(path);
        }

        public void yaz()
        {
            writer = new StreamWriter(path, true);
            writer.WriteLine(processes + " = " + conclusion);
            writer.Close();
        }
        
        public string oku()
        {
            
            reader = new StreamReader(path);

            StringBuilder sb = new StringBuilder();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine() + "\n";
                sb.AppendLine(line);
            }

            string tumSatirlar = sb.ToString();

            return tumSatirlar;
        }
    }
}
