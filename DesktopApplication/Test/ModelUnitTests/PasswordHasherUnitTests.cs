using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Desktop_Application.Models;
namespace Test
{
    class PasswordHasherUnitTests
    {
        PasswordHasher hash;
        [SetUp]
        public void Setup()
        {
            hash = new PasswordHasher();
        }

        [TestCase("hello")]
        [TestCase("Marc!!!??@#")]
        [TestCase("1231546defhjf")]
        public void GenerateAndIsValid_PasswordHashing_PasswordIshashed(string password)
        {
            var PasswordWithSalt = hash.Generate(password);
            var result = hash.IsValid(password, PasswordWithSalt);
            Assert.AreEqual(true, result);
        }

        [TestCase("hello")]
        [TestCase("Marc!!!??@#")]
        [TestCase("1231546defhjf")]
        public void GenerateAndIsValid_PasswordHashing_WrongPassword(string password)
        {
            string wrongPassword = "wrong";
            var PasswordWithSalt = hash.Generate(password);
            var result = hash.IsValid(wrongPassword, PasswordWithSalt);
            Assert.AreEqual(false, result);
        }


    }
}
