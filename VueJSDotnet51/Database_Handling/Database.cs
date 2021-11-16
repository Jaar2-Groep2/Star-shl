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
        private static SqlConnection P_CreateConnection() => new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Directory.GetCurrentDirectory() }\\App_Data\\Database1.mdf;Integrated Security=True");
        //Actual query excecuter per Type, can be used with multiple queries
        private static List<Sqltest> P_ExampleQuery(string query) 
        {
            SqlConnection sqlConnection = P_CreateConnection();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            List<Sqltest> returner = new List<Sqltest>();
            while (reader.Read())
            {
                Sqltest value = new Sqltest(reader.GetString(0), reader.GetString(1));
                //Use this as break point, value should have the requested data
                returner.Add(value);
            }

            sqlConnection.Close();
            return returner;
        }
        //Excecuted query, for clarity I expect all Sql statements in this class
        public static List<Sqltest> ExampleQuery() => P_ExampleQuery("select username, h_pword from Admins");
    }
}
