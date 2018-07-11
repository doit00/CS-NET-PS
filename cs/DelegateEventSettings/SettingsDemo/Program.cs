using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var defSettings = SettingsDemo.Properties.Settings.Default;

            var cs = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            Console.WriteLine("{0} {1}",defSettings.InitialCounter, cs);

            


        }
    }
}
