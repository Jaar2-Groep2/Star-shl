using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using VueJSDotnet51.Models;


namespace VueJSDotnet51.Controllers
{
    public class LocationList
    {
        public List<Location> locations { get; set; }
    }

    //[Route("[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public partial class LocationController : ControllerBase
    {
        private readonly LocationsContext _context;
        //private readonly ProjectNameOptions _projectNameOptions;
        private readonly IConfiguration _configuration;

        public LocationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select id as ""id"",
                        city as ""city"",
                        locationname as ""name"",
                        street as ""street"",
                        postcode as ""postcode"",
                        openinghours as ""openinghours"",
                        particularities as ""particularities"",
                        lat as ""lat"",
                        lon as ""lon""
                FROM ""Locations"";
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("LocationAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }
    }
}

    