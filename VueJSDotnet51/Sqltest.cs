using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJSDotnet51
{
    public class Sqltest
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Locname { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string OpenTimes { get; set; }
        public string Additional { get; set; } 

        public Sqltest(int id, String city, String locname,string address,string postalcode, string opentimes, string additional)
        {
            this.Id = id;
            this.City = city;
            this.Locname = locname;
            this.Address = address;
            this.PostalCode = postalcode;
            this.OpenTimes = opentimes;
            if (additional != null) this.Additional = additional;
        }
    }
}