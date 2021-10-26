using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VueJSDotnet51.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DatabaseController> _logger;

        public DatabaseController(ILogger<DatabaseController> logger)
        {
            _logger = logger;
        }
        /*
         
        [HttpGet]
        public IEnumerable<Sqltest> Get()
        {
            //temporary until I figure out databases proper lmao
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Sqltest
            {
                Username = rng.ToString(),
                Password = rng.Next().ToString()
            })
            .ToArray();
        }
        //database reading here
        */
        [HttpGet]
        public IEnumerable<Sqltest> Get()
        {
            //this string isn't the right one yet, we'll getr there soon ok
            String connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\\{Directory.GetCurrentDirectory() }\\..\\App_Data\\Database1.mdf;Integrated Security=True";
            //String queryLength = "Select count(*) from Admins";
            String queryResult = "select username, h_pword from Admins";
            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(queryResult, connection);
            connection.Open();
            // Do work here; connection closed on following line.
            using SqlDataReader reader = command.ExecuteReader();
            List<Sqltest> returner = new List<Sqltest>();
            while (reader.Read())
            {
                //Console.WriteLine(String.Format("{0}, {1}",
                //reader[0], reader[1]));
                returner.Add(new Sqltest((String)reader[0], (String)reader[1]));
            }
            return returner;
            /*
                         var rng = new Random();
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
    })
    .ToArray();
             */
        }
    }
}
