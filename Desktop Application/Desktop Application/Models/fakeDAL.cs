using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop_Application.Models
{
    class fakeDAL
    {
        public bool authentication(string user, string password)
        {
            string Password = "123";
            string User = "User";

            if (User == user && Password == password)
            {
                return true;
            }

            return false;
        }
    }
}
