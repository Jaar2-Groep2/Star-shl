using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJSDotnet51.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public byte[] StoredSalt { get; set; }
    }
    public class HashSalt
    {
        public string Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}
