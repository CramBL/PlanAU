using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Desktop_Application.Models
{
    public interface IInputValidator
    {
        bool ValidUsernameSyntax(string username);

        bool ValidPasswordSyntax(string password);
    }
    public class InputValidator : IInputValidator
    {

        private string _usernamePattern = "^AU[0-9]{6}$"; //AUxxxxxx (x is number 0-9)

        //developed with https://regex101.com/
        private string _passwordPattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,20}$";
        //mellem 8 og 20 characters
        //skal indeholde 1 af: tal, stort bogstav, småt bogstav, og special character
        //Ingen mellemrum
                               


        /// True if username is on form: AUxxxxxx (x is number 0-9)
        public bool ValidUsernameSyntax(string username)
        {
            Match match = Regex.Match(username, _usernamePattern, RegexOptions.IgnoreCase);
            return match.Success;
        }

        public bool ValidPasswordSyntax(string password)
        {
            Match match = Regex.Match(password, _passwordPattern);
            return match.Success;
        }
    }
}
