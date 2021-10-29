using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Desktop_Application.Models
{
    public interface IInputValidator
    {
        bool ValidUsernameSyntax(string username);
    }
    public class InputValidator : IInputValidator
    {

        /// True if username is on form: AUxxxxxx (x is number 0-9)
        public bool ValidUsernameSyntax(string username)
        {
            Match match = Regex.Match(username, "^AU[0-9]{6}$", RegexOptions.IgnoreCase);
            return match.Success;
        }

    }
}
