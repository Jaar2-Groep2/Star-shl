﻿using VueJSDotnet51.Models;
using System.Net;
using System.Net.Mail;
using System.Configuration;
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
            var emailData = JsonConvert.DeserializeObject<EmailData>(System.IO.File.ReadAllText("../VueJSDotnet51/ClientApp/src/assets/email.json"));

            string body = string.Empty;
            //using streamreader for reading my htmltemplate   

            using (StreamReader reader = new StreamReader("../VueJSDotnet51/ClientApp/src/components/EmailTemplate.html"))
            {

                body = reader.ReadToEnd();

            }
            body = body
                .Replace("[FNAME]", reservation.FirstName)
                .Replace("[INSERTION]", reservation.Insertion)
                .Replace("[LNAME]", reservation.LastName)
                .Replace("[FULLNAME]", reservation.FirstName + reservation.Insertion == "" ? $" {reservation.Insertion}" : "" + $" {reservation.LastName}")
                .Replace("[PHONENUMBER]", reservation.Phonenumber.Length == 0 ? reservation.Phonenumber = "Niet gegeven" : reservation.Phonenumber)
                .Replace("[AGE]", reservation.Age.Length == 0 ? reservation.Age = "Niet gegeven" : reservation.Age)
                .Replace("[GENDER]", reservation.Gender)
                .Replace("[EMAIL]", reservation.Email);

            var mail = new MailMessage
            {
                From = new MailAddress(emailData.Email),
                Subject = emailData.Subject,
                Body = body,
                IsBodyHtml = true
            };

            mail.To.Add(reservation.Email);

            using var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(emailData.Email, emailData.Password),
                EnableSsl = true
            };
            

            smtpClient.Send(mail);

            return new JsonResult("email sent");
        }
    }
}


