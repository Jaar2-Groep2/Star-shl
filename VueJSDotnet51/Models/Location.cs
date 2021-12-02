using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


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

    public partial class SimpleModelsAndRelationsContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        public SimpleModelsAndRelationsContext(DbContextOptions<SimpleModelsAndRelationsContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Location> ()
        //        .HasKey(c => new { c.ProductId, c.OrderId });
        //}
        
    }
}
