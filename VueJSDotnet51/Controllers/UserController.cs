using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueJSDotnet51.UserHandling;

namespace VueJSDotnet51.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        //disabled atm
        [HttpPost]
        public IActionResult Register(User user)
        {
            var hashsalt = EncryptPassword(user.Password);
            user.Password = hashsalt.Hash;
            user.StoredSalt = hashsalt.Salt;
            //store info in database
            //_context.Users.Add(user);
            //_context.SaveChanges();
            return View();
        }
        /*
        [HttpPost]
        public IActionResult Login(User loginUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == loginUser.Name);
            var isPasswordMatched = VerifyPassword(loginUser.Password, user.StoredSalt, user.Password);
            if (isPasswordMatched)
            {
                //Login Successfull
            }
            else
            {
                //Login Failed
            }

            return View();
        }
        
         */

        [HttpPost]
        public bool Login(string username, string password)
        {
            return Database_Handling.Database.Login(username,password);
        }
        public static HashSalt EncryptPassword(string password)
        {
            byte[] salt = new byte[128 / 8]; // Generate a 128-bit salt using a secure PRNG
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
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
