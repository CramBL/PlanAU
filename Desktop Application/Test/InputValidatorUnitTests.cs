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

        [Test]

        public void ValidInput()
        {
            bool InputResult = inputValidator.ValidUsernameSyntax("AU656565");
            Assert.AreEqual(true, InputResult);
        }


        [Test]

        public void ValidNumbersButInvalidLetters()
        {
            bool InputResult = inputValidator.ValidUsernameSyntax("kb656565");
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
