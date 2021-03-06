using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace VueJSDotnet51.Models
{
    public class Content
    {
        public int id { get; set; }
        public string content { get; set; }

    }

    public class ContentList
    {
        public List<Content> Contentlist { get; set; }
    }


    public class ContentContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Content> Contentlist { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //here we define the name of our database (make sure to put the correct password)
            optionsBuilder.UseNpgsql(@"Server=145.24.222.238;Port=8001;User Id=postgres;Password=Star-Shl;Database=postgres;");
        }

        public ContentContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
