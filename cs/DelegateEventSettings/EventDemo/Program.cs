using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient cli = new WebClient();
            var file = @"https://docs.oracle.com/javase/specs/jls/se8/jls8.pdf";
            //cli.DownloadFile(file, "java.pdf");
            cli.DownloadFileCompleted += Cli_DownloadFileCompleted;
            cli.DownloadFileAsync(new Uri(file), "java.pdf");
            Console.WriteLine("download started");
            
            Console.ReadLine();
        }

        private static void Cli_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine(e.Error);
            }
            else
            {
                Console.WriteLine("download completed");
            }
        }
    }
}
