using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Desktop_Application.Models;

namespace Test
{
    class JsonSerializerUnitTests
    {
        private JsonSerializer serializer = new JsonSerializer();
        private JsonDeserializer deserializer = new JsonDeserializer();
        private Student s1 = new Student("AU454545", "HelloWorld");
        private List<Lecture> l1;
        private Course c1;
        [SetUp] 

        public void Setup()
        {
            s1.Email = "netflixlover@mail.com";
        }

        [Test]

        public void SerializeStudentObject()
        {
            serializer.ToJSONstring(s1);
            var JsonSerResult = serializer.ToDo_JsonString;

            Assert.AreEqual("{\"email\":\"netflixlover@mail.com\",\"aU_ID\":\"AU454545\",\"password\":\"HelloWorld\"}", JsonSerResult);
        }

        //[Test]
        //public void DeserializeCourse()
        //{
           
        //}


    }





}
