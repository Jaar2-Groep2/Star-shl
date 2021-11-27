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
    /// In case of errors, open powershell or command line and run:
    /// sqllocaldb stop star-shl
    /// sqllocaldb delete star-shl
    /// Then try again, if issues persists then search help
    public static class Database
    {
        //Original method for comparison
        //@Depricated
        private static List<Sqltest> P2_ExampleQuery(string query)
        {
            //Creates an object with info about the localdb installations
            ISqlLocalDbApi localDB = new SqlLocalDbApi();
            //Starts a localdb instance with name "Star-shl" with localdb version 15 (download provided on the drive, TODO: Add this to system requirements)
            var instance = localDB.CreateInstance("Star-shl","15.0");
            //Allows managing of the instance
            ISqlLocalDbInstanceManager manager = instance.Manage();
            if (!instance.IsRunning)
            {
                manager.Start();
            }
            //creates the needed connectionstring
            var ConnectionString = instance.GetConnectionString()+ $";AttachDbFilename={Directory.GetCurrentDirectory() }\\App_Data\\Database1.mdf;Integrated Security=True";
            //Opens the connection
            using SqlConnection connection = new(ConnectionString);
            connection.Open();
            //Creates the command we want
            SqlCommand command = new(query, connection);
            //Executes the query, output is a stream we need to turn into the requested output though
            using SqlDataReader reader = command.ExecuteReader();
            //Creates the list we will return
            List<Sqltest> returner = new();
            //Reads thourgh the stream
            while (reader.Read())
            {
                //Gets the outpu per row
                Sqltest value = new(reader.GetInt32(0), reader.GetString(1),reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                //Use this as break point, value should have the requested data
                returner.Add(value);
            }
            //Console.WriteLine();
            //CLoses the connection
            connection.Close();
            //"Data Source=np:\\\\.\\pipe\\LOCALDB#E0789834\\tsql\\query"
            //$"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Directory.GetCurrentDirectory() }\\App_Data\\Database1.mdf;Integrated Security=True");
            //Console.WriteLine();
            //Stops the instance (at least it's supposed to)
            manager.Stop();
            //Returns the result
            return returner;
        }

        //Starts an instance and connection
        private static Tuple<ISqlLocalDbInstanceInfo,ISqlLocalDbInstanceManager> InstanceStart() {
            //Creates an object with info about the localdb installations
            ISqlLocalDbApi localDB = new SqlLocalDbApi();
            //Starts a localdb instance with name "Star-shl" with localdb version 15 (download provided on the drive, TODO: Add this to system requirements)
            var instance = localDB.CreateInstance("Star-shl", "15.0");
            //Allows managing of the instance
            ISqlLocalDbInstanceManager manager = instance.Manage();
            if (!instance.IsRunning)
            {
                manager.Start();
            }
            return new(instance,manager);
        }
        //Creates a connection
        private static SqlConnection CreateConnection(Tuple<ISqlLocalDbInstanceInfo, ISqlLocalDbInstanceManager> info) => new((info.Item1.GetConnectionString() + $";AttachDbFilename={Directory.GetCurrentDirectory() }\\App_Data\\Database1.mdf;Integrated Security=True"));
        //Example query, can be re-used for any query with returns a List<SqlTest>, hence there being 2 methods
        private static List<Sqltest> P_ExampleQuery(string query)
        {
            //Starts the instance and connection
            var info = InstanceStart();
            var connection = CreateConnection(info);
            connection.Open();
            SqlCommand command = new(query, connection);
            //Executes the query, output is a stream we need to turn into the requested output though
            using SqlDataReader reader = command.ExecuteReader();
            //Creates the list we will return
            List<Sqltest> returner = new();
            //Reads thourgh the stream
            while (reader.Read())
            {
                //Gets the output per row
                Sqltest value = new(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                //Use this as break point, value should have the requested data
                returner.Add(value);
            }
            //Stops the connection and instance
            connection.Close();
            info.Item2.Stop();
            //Returns the value
            return returner;
        }

        //Excecuted query, for clarity I expect all Sql statements in this class
        public static List<Sqltest> ExampleQuery() => P_ExampleQuery("select distinct city,name,address,postalcode,opentimes,additional from locations order by name");
    }
}
