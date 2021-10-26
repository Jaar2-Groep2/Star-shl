using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJSDotnet51
{
    public class Sqltest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Sqltest(String username, String password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
