using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo03
{
    class Program
    {
        static void Main(string[] args)
        {

            var l = LogManager.GetCurrentClassLogger();
            l.Debug("debug message");
            l.Warn("warn message");
            l.Error("error message");
            LogManager.Flush();
            Console.ReadLine();

        }
    }
}
