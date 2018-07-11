using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMLLInqDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            XDocument doc = new XDocument(
                new XElement("Order",
                    new XElement("Details",
                        new XAttribute("ID", 1),
                        new XElement("Line","OrderLine1")
                    )
                )
                );
            var wr = XmlWriter.Create("order.xml");
            doc.WriteTo(wr);
            wr.Close();




        }
    }
}
