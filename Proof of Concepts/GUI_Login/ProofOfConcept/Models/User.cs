using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.Models
{
   

    public class User : IUser
    {
        private string _password;
        public string UserID{ get; set; }
        public string Password
        {
            get => _password;
            set => new string("1234") ;
        }
        public User(string userId, string password)
        {
            UserID = userId;
            _password = password;
        }
    }

    public interface IUser
    {
        string UserID { get; set; }
        string Password{ get; set; }

    }
}

