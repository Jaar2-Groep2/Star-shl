using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using VueJSDotnet51.Models;


namespace VueJSDotnet51.Controllers
{
    public class ContentList
    {
        public List<Content> Contentlist { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public partial class ContentController : ControllerBase
    {
        private readonly ContentContext _context;
        private readonly IConfiguration _configuration;

        public ContentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetContent()
        {
            string query = @"
                select id as ""id"",
                content as ""content""
                FROM ""Content""
                ORDER BY ""id"";
            ";

            DataTable table = new();
            string sqlDataSource = _configuration.GetConnectionString("LocationAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon);
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);

                myReader.Close();
                myCon.Close();
            }
            return new JsonResult(table);
        }

        [HttpPut]
        public JsonResult Put(Content _content)
        {
            string query = @"
                UPDATE ""Content""
                SET content = @content
                WHERE id = @id
                ;
            ";
            ;

            DataTable table = new();
            string sqlDataSource = _configuration.GetConnectionString("LocationAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new(sqlDataSource))
            {
                myCon.Open();
                using NpgsqlCommand myCommand = new(query, myCon);
                myCommand.Parameters.AddWithValue("@content", _content.content);
                myCommand.Parameters.AddWithValue("@id", _content.id);
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);

                myReader.Close();
                myCon.Close();
            }
            return new JsonResult("Updated Successfully");
        }
    }
}

