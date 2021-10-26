using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Desktop_Application.Models
{
    //Adapted from https://www.cidean.com/blog/2019/password-hashing-using-rfc2898derivebytes/
    public class PasswordHasher
    {
        /// Return a string delimited with random salt and hashed password
        public string Generate(string password, int iterations = 100000)
        {
            //generate a random salt for hashing
            var salt = new byte[24];
            using (var CSP = new RNGCryptoServiceProvider())
            { CSP.GetBytes(salt); }



            //hash password given salt and iterations
            //iterations provide difficulty when cracking (10000 recommended)
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] hash = pbkdf2.GetBytes(24);

                //return delimited string with "salt|hash"
                return Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(hash);
                    
            }
        }

        /// Returns true of hash of test password matches hashed password within origDelimHash
        public bool IsValid(string testPassword, string origDelimHash)
        {
            //extract original values from delimited hash text
            var origHashedParts = origDelimHash?.Split('|');
            var origSalt = Convert.FromBase64String(origHashedParts[0]);
            var origHash = origHashedParts[1];

            //generate hash from test password and original salt and iterations
            using (var pbkdf2 = new Rfc2898DeriveBytes(testPassword, origSalt, 100000))
            {
                byte[] testHash = pbkdf2.GetBytes(24);

                //if hash values match
                if (Convert.ToBase64String(testHash) == origHash)
                    return true;
                else
                    return false;
            }

        }
    }
}
