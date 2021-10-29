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
    }
}
