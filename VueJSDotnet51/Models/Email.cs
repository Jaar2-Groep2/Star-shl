using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJSDotnet51.Models
{
    public class EmailData
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class Reservation
    {
        public string firstName { get; set; }
        public string insertion { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int phonenumber { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
    }
}
