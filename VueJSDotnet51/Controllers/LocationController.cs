using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using VueJSDotnet51.Models;

namespace VueJSDotnet51.Controllers
{
    public class LocationList
    {
        public List<Location> locations { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]

    public partial class LocationController : ControllerBase
    {
        private readonly LocationsContext _context;
        private readonly IConfiguration _configuration;

        public LocationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            bool test = true;

            if (test)
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

                DataTable table = new();
                string sqlDataSource = _configuration.GetConnectionString("LocationAppCon");
                NpgsqlDataReader myReader;
                using (NpgsqlConnection myCon = new(sqlDataSource))
                {
                    myCon.Open();
                    using NpgsqlCommand myCommand = new(query, myCon);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
                return new JsonResult(table);
            }
            return new JsonResult(null);
        }
    }
}

