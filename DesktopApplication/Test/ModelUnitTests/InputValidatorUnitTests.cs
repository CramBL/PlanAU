using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Desktop_Application.Models;

namespace Test
{
    class InputValidatorUnitTests
    {
        private InputValidator _uut;

        [SetUp] 
        public void Setup()
        {
            _uut = new InputValidator();
        }

        [TestCase("AU656565")]
        [TestCase("au656566")]
        [TestCase("aU656565")]
        [TestCase("Au656565")]
        [TestCase("AU000000")]
        [TestCase("AU999999")]

        public void ValidUsernameSyntax_InputsUsername_ValidUsernames(String auid)
        {
            bool InputResult = _uut.ValidUsernameSyntax(auid);
            Assert.AreEqual(true, InputResult);
        }


        [TestCase("kb656565")]
        [TestCase("!!656565")]
        [TestCase("AU!!!!!!")]
        [TestCase("au0000000")]

        public void ValidUsernameSyntax_InputsUsername_InvalidUsernames(string auid)
        {
            bool InputResult = _uut.ValidUsernameSyntax(auid);
            Assert.AreEqual(false, InputResult);
        }

        [Test]

        public void InValidNumbersButValidLetters()
        {
            bool InputResult = _uut.ValidUsernameSyntax("AU2020202");
            Assert.AreEqual(false, InputResult);
        }

        [Test]

        public void InValidNumbersAndInValidLetters()
        {
            bool InputResult = _uut.ValidUsernameSyntax("HR2323232");
            Assert.AreEqual(false, InputResult);
        }

        [Test]

        public void IgnoreCase()
        {
            bool InputResult = _uut.ValidUsernameSyntax("au454545");
            Assert.AreEqual(true, InputResult);
        }

        [TestCase("sT3!xyz1")]
        [TestCase("!!656565@sE")]
        [TestCase("123Password!")]
        [TestCase("1337P4$$w£Rd...!!")]
        [TestCase("1337(æøå]P4$$w..!!")]
        public void ValidPasswordSyntax_ValidPassword(string password)
        {
            var isValid = _uut.ValidPasswordSyntax(password);

            Assert.IsTrue(isValid);
        }

        [TestCase("passWORD123")]//no special character
        [TestCase("!!/()@sE")]//no number
        [TestCase("123password!")]//no capital letter
        [TestCase("1337P4$$£R")]//no lowercase letter
        [TestCase("1p4$$£R")]//Too short
        [TestCase("21337P4$$£R234fds11AS")]//Too long
        public void ValidPasswordSyntax_InvalidPassword(string password)
        {
            var isValid = _uut.ValidPasswordSyntax(password);

            Assert.IsFalse(isValid);
        }


    }
}
