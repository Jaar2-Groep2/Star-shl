using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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


        //[HttpGet("{GetLocations}")]
        // [HttpGet]
        //public IActionResult GetLocations()
        //{
        //    Console.WriteLine("Test");
        //    var locations_AUX = (
        //                       from l in _context.Locations

        //                       select new
        //                       {
        //                           LocationCity = l.city,
        //                           LocationName = l.locname,
        //                           LocationStreet = l.address,
        //                           LocationPostalcode = l.postalCode,
        //                           LocationOpenTimes = l.openTimes,
        //                           LocationAdditional = l.additional
        //                       }).ToList();

        //    var locations = locations_AUX;

        //    return Ok(locations);
        //}


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select id as ""l.id"",
                        city as ""l.city"",
                        locationname as ""l.name"",
                        street as ""l.street"",
                        postcode as ""l.postcode"",
                        openinghours as ""l.openinghours"",
                        particularities as ""l.particularities"",
                        lat as ""l.lat"",
                        lon as ""l.lon""
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

    


    //    [ApiController]
    //    [Route("api/[controller]")]

    //    public class LocationController : ControllerBase
    //    {
    //        private readonly IConfiguration _configuration;

    //        public LocationController(IConfiguration configuration)
    //        {
    //            _configuration = configuration;
    //        }

    //        [HttpGet]

    //        public JsonResult Get()
    //        {
    //            string query = @"

    //"           ;
    //        }

    //        }
    //    }

