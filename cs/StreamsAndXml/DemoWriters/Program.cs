using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DemoWriters
{
    class Program
    {
        static void Main(string[] args)
        {
            //WriteFile();
            //ReadFile();
            
            var file = File.OpenRead("file.txt");
            BinaryReader br = new BinaryReader(file);

            byte[] block = new byte[128];
            int index = 0;
            int readed = 0;
            while ((readed =br.Read(block, index, block.Length))> 0)
            {
                Console.WriteLine("readed {0}", readed);
               
            }


        }

        private static void ReadFile()
        {
            var file = File.Open("file.txt", FileMode.Open);
            StreamReader sr = new StreamReader(file);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);

            }
        }

        private static void WriteFile()
        {
            var file = File.Create("file.txt");
            StreamWriter wr = new StreamWriter(file);

            for (int i = 0; i < 10000; i++)
            {
                wr.WriteLine($"{i} line ............");
            }

            wr.Close();
            file.Close();
        }
    }
}
