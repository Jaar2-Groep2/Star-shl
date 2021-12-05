using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace VueJSDotnet51.Models
{
    public class Location
    {
        public int id { get; set; }
        public string city { get; set; }
        public string locname { get; set; }
        public string address { get; set; }
        public string postalCode { get; set; }
        public string openTimes { get; set; }
        public string additional { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class LocationList
    {
        public List<Location> locations { get; set; }
    }


    public class LocationsContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Location> Locations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //here we define the name of our database (make sure to put the correct password)
            optionsBuilder.UseNpgsql(@"Server=145.24.222.238;Port=8001;User Id=postgres;Password=Star-Shl;Database=postgres;");
        }

        public LocationsContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
