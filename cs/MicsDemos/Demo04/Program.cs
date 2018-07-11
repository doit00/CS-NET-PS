using System;
using System.Globalization;
using System.Linq;

namespace Demo04
{
    class Program
    {
        static void Main(string[] args)
        {

            var cc = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            cc.ToList().ForEach(c => Console.WriteLine($"{c.DisplayName}"));
            var first = cc.First();
            Console.WriteLine(first.DisplayName);
            var dtPatterns = first.DateTimeFormat.GetAllDateTimePatterns();
            foreach (var p in dtPatterns)
            {
                Console.WriteLine(p);
            }

           
        }
    }
   


}
