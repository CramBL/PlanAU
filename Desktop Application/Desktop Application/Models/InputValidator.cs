using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Desktop_Application.Models
{
    public class InputValidator
    {

        /// Restricts usernames to the form: AUxxxxxx
        /// x is a number 0-9
        /// takes username as string
        /// returns username as string if it follows form, else returns empty string
        public string ParseUsernameInput(string username)
        {
            Match match = Regex.Match(username, "^AU[0-9]{6}", RegexOptions.IgnoreCase);
            if (match.Success)
                return match.Value;
            else
                return "";
        }
    }
}
