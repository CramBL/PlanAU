using System;
using System.Security.Cryptography;

namespace WebAPIDesktop.Models
{
    public interface IPasswordHasher
    {
        bool IsValid(string testPassword, string origDelimHash);

    }

    //Adapted from https://www.cidean.com/blog/2019/password-hashing-using-rfc2898derivebytes/
    public class PasswordHasher : IPasswordHasher
    {

        /// Returns true of hash of test password matches hashed password within origDelimHash
        public bool IsValid(string testPassword, string origDelimHash)
        {
            //extract original values from delimited hash text
            try
            {
                var origHashedParts = origDelimHash?.Split('|');
                var origSalt = Convert.FromBase64String(origHashedParts[0]);
                var origHash = origHashedParts[1];
                //generate hash from test password and original salt and iterations
                using var pbkdf2 = new Rfc2898DeriveBytes(testPassword, origSalt, 100000);
                byte[] testHash = pbkdf2.GetBytes(24);
                //if hash values match
                if (Convert.ToBase64String(testHash) == origHash)
                    return true;
                else
                    return false;
            }
            catch (FormatException e)
            {
                return false;
            }

        
        }
    }
}
