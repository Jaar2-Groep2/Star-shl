using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using VueJSDotnet51.Models;


namespace VueJSDotnet51.Controllers
{
    public class LoginList
    {
        public List<Location> locations { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public partial class LoginController : ControllerBase
    {
        private readonly LocationsContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            HashSalt hashsalt = EncryptPassword(user.Password);
            user.Password = hashsalt.Hash;
            user.StoredSalt = hashsalt.Salt;
            return null;
        }

        //generates a new user with username admin and password admin
        private void ExampleAccountGen()
        {
            // Prepare the command to be executed on the db
            //the following code registers a user, as an example I used admin as username and as password though ofc this shouldn't be done with the proper implementation
            HashSalt example = LoginController.EncryptPassword("admin");
            string insertXmlQuery = @"insert into users (name,password,storedsalt) Values(@Username,@Password,@StoredSalt)";
            string sqlDataSource = _configuration.GetConnectionString("LocationAppCon");

            using NpgsqlConnection myCon = new(sqlDataSource);
            myCon.Open();

            using NpgsqlCommand myCommand = new(insertXmlQuery, myCon);
            myCommand.Parameters.AddWithValue("@Username", NpgsqlTypes.NpgsqlDbType.Varchar, "admin");
            myCommand.Parameters.AddWithValue("@Password", NpgsqlTypes.NpgsqlDbType.Varchar, example.Hash);
            myCommand.Parameters.AddWithValue("@StoredSalt", NpgsqlTypes.NpgsqlDbType.Bytea, example.Salt);
            myCommand.ExecuteNonQuery();

            myCon.Close();
        }
        //NEVER DO THIS IN A REAL SCENARIO! I couldn't get hhtps to work properly, hence this madness
        [HttpGet("{username}/{password}")]
        public bool Login(string username, string password)
        {
            bool result = false;
            string selectQuery = string.Format(@"Select Password,StoredSalt From Users Where Name=@Username limit 1");
            string sqlDataSource = _configuration.GetConnectionString("LocationAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new(sqlDataSource))
            {
                myCon.Open();
                using NpgsqlCommand myCommand = new(selectQuery, myCon);
                myCommand.Parameters.AddWithValue("@Username", username);
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //get hash and salt
                    string dbHash = (string)myReader[0];
                    byte[] dbSalt = (byte[])myReader[1];
                    //hash given password with user salt
                    //compare the result with the actual hash
                    result = VerifyPassword(password, dbSalt, dbHash);
                }

                myReader.Close();
                myCon.Close();
            }

            return result;
        }
        public static HashSalt EncryptPassword(string password)
        {
            byte[] salt = new byte[128 / 8]; // Generate a 128-bit salt using a secure PRNG
            using (System.Security.Cryptography.RandomNumberGenerator rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string encryptedPassw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));
            return new HashSalt { Hash = encryptedPassw, Salt = salt };
        }


        public static bool VerifyPassword(string enteredPassword, byte[] salt, string storedPassword)
        {
            string encryptedPassw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));
            return encryptedPassw == storedPassword;
        }
    }
}