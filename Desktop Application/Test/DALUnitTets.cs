using NUnit.Framework;
using Desktop_Application.DataAccessLayer;
using Desktop_Application.Models;
using System;
using System.Threading.Tasks;
using System.Text.Json;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoginAttemptAuthorizeValidAuIdAndPassword()
        {
            Student S1 = new Student("AU123456", "1234Password");
            var uut = DAL_Student.LoginAttemptAuthorize(S1).Result;
            bool expectedResult = true;
            Assert.AreEqual(expectedResult, uut);
        }


        [Test]
        public void LoginAttemptAuthorizeInvalidAuId()
        {
            Student S1 = new Student("AU000000", "1234Password");
            var uut = DAL_Student.LoginAttemptAuthorize(S1).Result;
            bool expectedResult = false;
            Assert.AreEqual(expectedResult, uut);
        }

        [Test]
        public void LoginAttemptAuthorizeInvalidPassword()
        {
            Student S1 = new Student("AU123456", "wrongpassword");
            var uut = DAL_Student.LoginAttemptAuthorize(S1).Result;
            bool expectedResult = false;
            Assert.AreEqual(expectedResult, uut);
        }

        [Test]
        public void LoginAttemptAuthorizeInvalidPasswordAndAuId()
        {
            Student S1 = new Student("AU000000", "wrongpassword");
            var uut = DAL_Student.LoginAttemptAuthorize(S1).Result;
            bool expectedResult = false;
            Assert.AreEqual(expectedResult, uut);
        }

        [Test]
        public void PostStudent()
        {
            Student S1 = new Student("AU900898", "goodpassword");
            S1.Email = "hansolo@luke.com";
            var uut = DAL_Student.PostStudent(S1).Result;
            if(uut == "InternalServerError")
            {
                var LoginResult = DAL_Student.LoginAttemptAuthorize(S1).Result;
                if(LoginResult == true)
                {
                    throw new Exception("data already posted to server");
                }
                else
                {
                    Assert.That(false);
                }
            }
            else
            {
                Assert.AreEqual("Created", uut);
            }
        }
    }
}