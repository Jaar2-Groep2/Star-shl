using VueJSDotnet51.Models;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;

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
            var emailData = JsonConvert.DeserializeObject<EmailData>(System.IO.File.ReadAllText("ClientApp/Assets/src/email.json"));

            using var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(emailData.Email, emailData.Password),
                EnableSsl = true
            };
            var body = emailData.Body

                .Replace("[NAME]", reservation.firstName)
                .Replace("[CODE]", reservation.lastName)
                .Replace("[EMAIL]", reservation.email);

            smtpClient.Send(emailData.Email, reservation.email, emailData.Subject, body);

            return new JsonResult("Done sending email");
        }
    }
}


