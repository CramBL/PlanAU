using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Desktop_Application.Models;

namespace Test
{
    class InputValidatorUnitTests
    {
        private InputValidator inputValidator = new InputValidator();

        [SetUp] 
        public void Setup()
        {

        }

        [TestCase("AU656565")]
        [TestCase("au656566")]
        [TestCase("aU656565")]
        [TestCase("Au656565")]
        [TestCase("AU000000")]
        [TestCase("AU999999")]

        public void ValidUsernameSyntax_InputsUsername_ValidUsernames(String auid)
        {
            bool InputResult = inputValidator.ValidUsernameSyntax(auid);
            Assert.AreEqual(true, InputResult);
        }


        [TestCase("kb656565")]
        [TestCase("!!656565")]
        [TestCase("AU!!!!!!")]
        [TestCase("au0000000")]

        public void ValidUsernameSyntax_InputsUsername_InvalidUsernames(string auid)
        {
            bool InputResult = inputValidator.ValidUsernameSyntax(auid);
            Assert.AreEqual(false, InputResult);
        }

        [Test]

        public void InValidNumbersButValidLetters()
        {
            bool InputResult = inputValidator.ValidUsernameSyntax("AU2020202");
            Assert.AreEqual(false, InputResult);
        }

        [Test]

        public void InValidNumbersAndInValidLetters()
        {
            bool InputResult = inputValidator.ValidUsernameSyntax("HR2323232");
            Assert.AreEqual(false, InputResult);
        }

        [Test]

        public void IgnoreCase()
        {
            bool InputResult = inputValidator.ValidUsernameSyntax("au454545");
            Assert.AreEqual(true, InputResult);
        }
    }
}
