using MartinCostello.SqlLocalDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VueJSDotnet51.Database_Handling
{
    /// <summary>Static Class Database handles all queries</summary>
    public static class Database
    {
        //Create connection
        private static SqlConnection P_CreateConnection() => new($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Directory.GetCurrentDirectory() }\\App_Data\\Database1.mdf;Integrated Security=True");
        //Actual query excecuter per Type, can be used with multiple queries
        /*
        private static List<Sqltest> P_ExampleQuery(string query) 
        {
            //Test();
            SqlConnection sqlConnection = P_CreateConnection();
            SqlCommand command = new(query, sqlConnection);
            sqlConnection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            List<Sqltest> returner = new();
            while (reader.Read())
            {
                Sqltest value = new(reader.GetString(0), reader.GetString(1));
                //Use this as break point, value should have the requested data
                returner.Add(value);
            }

            sqlConnection.Close();
            
            return returner;
        }
         */
        private static List<Sqltest> P_ExampleQuery(string query)
        {
            ISqlLocalDbApi localDB = new SqlLocalDbApi();
            //var instance = localDB.GetOrCreateInstance("MSSQLLocalDB");
            var instance = localDB.CreateInstance("Star-shl","15.0");
            ISqlLocalDbInstanceManager manager = instance.Manage();
            if (!instance.IsRunning)
            {
                manager.Start();
            }
            //var example = localDB.CreateInstance("MSSQLLocalDB","15.0");
            var ConnectionString = instance.GetConnectionString()+ $";AttachDbFilename={Directory.GetCurrentDirectory() }\\App_Data\\Database1.mdf;Integrated Security=True";
            using SqlConnection connection = new(ConnectionString);
            connection.Open();
            SqlCommand command = new(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            List<Sqltest> returner = new();
            while (reader.Read())
            {
                Sqltest value = new(reader.GetInt32(0), reader.GetString(1),reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                //Use this as break point, value should have the requested data
                returner.Add(value);
            }
            Console.WriteLine();
            connection.Close();
            //"Data Source=np:\\\\.\\pipe\\LOCALDB#E0789834\\tsql\\query"
            //$"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Directory.GetCurrentDirectory() }\\App_Data\\Database1.mdf;Integrated Security=True");
            Console.WriteLine();
            manager.Stop();
            return returner;
        }
        //Excecuted query, for clarity I expect all Sql statements in this class
        public static List<Sqltest> ExampleQuery() => P_ExampleQuery("select * from locations");
    }
}
