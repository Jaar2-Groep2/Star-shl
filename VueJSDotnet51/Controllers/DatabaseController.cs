using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

namespace VueJSDotnet51.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
        //not implemented yet
        private readonly ILogger<DatabaseController> _logger;
        //not implemented yet
        public DatabaseController(ILogger<DatabaseController> logger)
        {
            _logger = logger;
        }
        //kinda working, only username returned, error with the function though, not with the sql connection
        [HttpGet]
        public IEnumerable<Sqltest> Get()
        {
            String connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Directory.GetCurrentDirectory() }\\App_Data\\Database1.mdf;Integrated Security=True";

            String queryResult = "select username, h_pword from Admins";
            var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(queryResult, connection);

            // Do work here; connection closed on following line.
            using SqlDataReader reader = command.ExecuteReader();
            List<Sqltest> returner = new List<Sqltest>();
            while (reader.Read())
            {
                //Console.WriteLine(String.Format("{0}, {1}",
                //reader[0], reader[1]));

                Sqltest value = new Sqltest(reader.GetString(0), reader.GetString(1));
                //Use this as break point, value should have the requested data
                Console.WriteLine();
                returner.Add(value);
            }
            connection.Close();
            return returner;
        }
    }
}