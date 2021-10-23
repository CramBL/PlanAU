using NUnit.Framework;
using Desktop_Application.DataAccessLayer;
using Desktop_Application.Models;
using System;
using System.Threading.Tasks;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLoginAttemptAuthorizeValidAuIdAndPassword()
        {
            Student S1 = new Student("AU123456", "1234Password");
            var uut = DAL_Student.LoginAttemptAuthorize(S1).Result;
            bool expectedResult = true;
            Assert.AreEqual(expectedResult, uut);
        }


        [Test]
        public void TestLoginAttemptAuthorizeInvalidAuId()
        {
            Student S1 = new Student("AU000000", "1234Password");
            var uut = DAL_Student.LoginAttemptAuthorize(S1).Result;
            bool expectedResult = false;
            Assert.AreEqual(expectedResult, uut);
        }

        [Test]
        public void TestLoginAttemptAuthorizeInvalidPassword()
        {
            Student S1 = new Student("AU123456", "wrongpassword");
            var uut = DAL_Student.LoginAttemptAuthorize(S1).Result;
            bool expectedResult = false;
            Assert.AreEqual(expectedResult, uut);
        }

        [Test]
        public void TestLoginAttemptAuthorizeInvalidPasswordAndAuId()
        {
            Student S1 = new Student("AU000000", "wrongpassword");
            var uut = DAL_Student.LoginAttemptAuthorize(S1).Result;
            bool expectedResult = false;
            Assert.AreEqual(expectedResult, uut);
        }


    }
}