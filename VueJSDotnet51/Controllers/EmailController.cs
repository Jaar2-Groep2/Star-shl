using VueJSDotnet51.Models;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace VueJSDotnet51.Controllers
{
    //public class ReservationList
    //{
    //    public List<Reservation> Reservationdatalist { get; set; }
    //}


    [Route("api/[controller]")]
    [ApiController]

    public partial class EmailController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public JsonResult Post(Reservation reservation)
        {
            var emailData = JsonConvert.DeserializeObject<EmailData>(System.IO.File.ReadAllText("../VueJSDotnet51/ClientApp/src/assets/email.json"));

            using var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(emailData.Email, emailData.Password),
                EnableSsl = true
            };
            var body = emailData.Body
                .Replace("[FNAME]", reservation.FirstName)
                .Replace("[INSERTION]", reservation.Insertion)
                .Replace("[LNAME]", reservation.LastName)
                .Replace("[PHONENUMBER]", reservation.Phonenumber.Length == 0 ? reservation.Phonenumber = "Niet gegeven": reservation.Phonenumber)
                .Replace("[AGE]", reservation.Age.Length == 0 ? reservation.Age = "Niet gegeven": reservation.Age)
                .Replace("[GENDER]", reservation.Gender)
                .Replace("[EMAIL]", reservation.Email);

            smtpClient.Send(emailData.Email, reservation.Email, emailData.Subject, body);

            return new JsonResult("email sent");
        }
    }
}


