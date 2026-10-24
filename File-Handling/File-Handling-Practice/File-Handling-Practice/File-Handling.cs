using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Handling
{
    internal class File
    {
        public void WriteData()
        {
            FileStream fs = new FileStream(@"C:\Users\shubh\source\repos\dotnet-developer-roadmap\File-Handling\File-Handling-Practice\new.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Welcome to FileHandling Series.");
            sw.Close();
            fs.Close();
            Console.WriteLine("Data Written Successfully.");
        }
        public void ReadData()
        {
            FileStream fs = new FileStream(@"C:\Users\shubh\source\repos\dotnet-developer-roadmap\File-Handling\File-Handling-Practice\new.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string data;
            while((data = sr.ReadLine()) != null)
            {
                Console.WriteLine(data);
            }
            sr.Close();
            fs.Close();
            Console.WriteLine("Data Read Successfully.");

        }
        public void Sqaure()
        {
            FileStream fs = new FileStream(@"C:\Users\shubh\source\repos\dotnet-developer-roadmap\File-Handling\File-Handling-Practice\square.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            int i;
            for(i = 1; i <= 10; i++)
            {
                sw.WriteLine($"Square of {i} = {i * i}");
            }
            sw.Close();
            fs.Close();
            Console.WriteLine("Data Written Successfully.");
        }
        public void BinaryWrite()
        {
            FileStream fs = new FileStream(@"C:\Users\shubh\source\repos\dotnet-developer-roadmap\File-Handling\File-Handling-Practice\Square.txt", FileMode.Append, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            int i = 30;
            string s = "Hello Binary Writer";
            const double pi = 3.14;
            bool b = true;
            bw.Write(i);
            bw.Write(s);
            bw.Write(pi);
            bw.Write(b);
            bw.Close();
            fs.Close();
            Console.WriteLine("Data Written Successfully.");
        }
        public void BinaryRead()
        {
            FileStream fs = new FileStream(@"C:\Users\shubh\source\repos\dotnet-developer-roadmap\File-Handling\File-Handling-Practice\Square.txt", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            int i = br.ReadInt32();
            string s = br.ReadString();
            double pi = br.ReadDouble();
            bool b = br.ReadBoolean();
            Console.WriteLine($"Integer: {i}");
            Console.WriteLine($"String: {s}");
            Console.WriteLine($"Double: {pi}");
            Console.WriteLine($"Boolean: {b}");
            fs.Close();
        }
    }
}
