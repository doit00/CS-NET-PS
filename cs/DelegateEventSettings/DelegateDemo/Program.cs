using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{

    //delegate void LogMethod(string a);
    
    class Program
    {

        static void Main(string[] args)
        {
            Action<string> log = null;
            log += FileLogger.LogToFile;
            log += ConsoleLogger.Log;

            log("Start");

            log("Stop");

        }
              

    }
    class ConsoleLogger
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }

    }
    class FileLogger
    {
        public static void LogToFile(string data)
        {
            File.AppendAllText("file.log",data);
        }
    }
}
