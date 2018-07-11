using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DemoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=demo;Integrated Security=True";
            cnn.FireInfoMessageEventOnUserErrors = true;
            var result = cnn.Query<LogEntry>("Select * From Logs");

            foreach (var r in result)
            {
                Console.WriteLine($"{r.id} {r.message} {r.date}");
            }

            cnn.Execute("raiserror 11, @@servername");

            cnn.InfoMessage += Cnn_InfoMessage;
            //AdoNet(cnn);
            Console.ReadLine();
        }

        private static void Cnn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void AdoNet(SqlConnection cnn)
        {
            var cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "Select * From Logs";

            cnn.Open();
            var rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                var id = rdr.GetInt32(0);
                var msg = rdr.GetString(1);
                var dt = rdr.GetDateTime(2);
                Console.WriteLine($"{id} {msg} {dt}");
            }
        }
    }

    class LogEntry
    {
        public int id { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
    }


}
