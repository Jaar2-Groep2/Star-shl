using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;
using VueJSDotnet51.Models;

namespace VueJSDotnet51.Controllers
{
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
        public void Post(Reservation reservation)
        {
            RunAsync(reservation).Wait();
        }
        static async Task RunAsync(Reservation reservation)
        {

            string body = string.Empty;

            using (StreamReader reader = new("../VueJSDotnet51/ClientApp/src/assets/EmailTemplate.html"))
            {

                body = reader.ReadToEnd();

            }
            body = body
                .Replace("[FNAME]", reservation.FirstName)
                .Replace("[INSERTION]", reservation.Insertion)
                .Replace("[LNAME]", reservation.LastName)
                .Replace("[PHONENUMBER]", reservation.Phonenumber.Length == 0 ? reservation.Phonenumber = "Niet gegeven" : reservation.Phonenumber)
                .Replace("[AGE]", reservation.Age.Length == 0 ? reservation.Age = "Niet gegeven" : reservation.Age)
                .Replace("[GENDER]", reservation.Gender)
                .Replace("[EMAIL]", reservation.Email);

            MailjetClient client = new("1795ef5cfe11ddbaa735ae32569b3627", "2ea35100ed4a8142341f92560b45313d")
            {
                Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
     new JObject {
      {
       "From",
       new JObject {
        {"Email", "starshlproject@hotmail.com"},
        {"Name", "Star-shl"}
       }
      }, {
       "To",
       new JArray {
        new JObject {
         {
          "Email",
          reservation.Email
         }, {
          "Name",
          reservation.FirstName
         }
        }
       }
      }, {
       "Subject",
       "Star-shl afspraak"
      }, {
       "TextPart",
       "Star-shl"
      }, {
       "HTMLPart",
       body
      }, {
       "CustomID",
       "Afspraak"
      }
     }
             });
            MailjetResponse response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                Console.WriteLine(response.GetData());
            }
            else
            {
                Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
                Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                Console.WriteLine(response.GetData());
                Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            }
        }
    }
}


