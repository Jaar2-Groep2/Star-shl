using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VueJSDotnet51.Models;


namespace VueJSDotnet51.Controllers
{
    public class LocationList
    {
        public List<Location> locations { get; set; }
    }

    [Route("[controller]")]

    public partial class LocationController : Controller
    {
        private readonly SimpleModelsAndRelationsContext _context;
        private readonly ProjectNameOptions _projectNameOptions;

        // !!! FOR ADDING A PRODUCT TO THE DATABASE !!!
        //
        //public LocationController(SimpleModelsAndRelationsContext context, IOptions<ProjectNameOptions> projectNameOptions)
        //{
        //    _context = context;
        //    _projectNameOptions = projectNameOptions.Value;
        //    if (_context.Products.Count() == 0)
        //    {
        //        _context.Products.AddRange(new Product[]{
        //        new Product(){Name="Potato", Price=1},
        //        new Product(){Name="Tomato", Price=0.75f},
        //        new Product(){Name="Apple", Price=1},
        //        new Product(){Name="Ananas", Price=1.5f},
        //        new Product(){Name="Carrot", Price=0.5f},
        //        new Product(){Name="Egg", Price=2}
        //      });
        //        _context.SaveChanges();
        //    }


        [HttpGet("GetLocations")]
        public IActionResult GetLocations()
        {
            var locations_AUX = (
                               from l in _context.Locations

                               select new
                               {
                                   LocationCity = l.city,
                                   LocationStreet = l.address,
                                   LocationPostalcode = l.postalCode,
                                   LocationOpenTimes = l.openTimes,
                                   LocationAdditional = l.additional
                               }).ToList();

            var locations = locations_AUX;

            return Ok(locations);
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

