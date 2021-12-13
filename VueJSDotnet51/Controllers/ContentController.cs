using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
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
        //private readonly ProjectNameOptions _projectNameOptions;
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
                FROM ""Content"";
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

        //public void SendContent(string contentstring)
        //{

        //}
    }
}

