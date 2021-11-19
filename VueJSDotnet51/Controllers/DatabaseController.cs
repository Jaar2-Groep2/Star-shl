using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

namespace VueJSDotnet51.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
        //not implemented yet
        private readonly ILogger<DatabaseController> _logger;
        //not implemented yet
        public DatabaseController(ILogger<DatabaseController> logger)
        {
            _logger = logger;
        }
        //Please place the used query in commentary here and call in Database_Handling.Database
        //Like this:
        //"select username, h_pword from Admins"
        [HttpGet]
        public IEnumerable<Sqltest> Get()
        {
            return Database_Handling.Database.ExampleQuery();
        }
    }
}