using System;
using System.Collections.Generic;
using System.Text;
using Desktop_Application.Models;
using NUnit.Framework;

namespace Test
{
    class JsonDeserializerUnitTests
    {

        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void CourseStringToJSONObject_GetsACourseObject_DeserializeIt()
        {
            List<ILecture> lectures = new List<ILecture>();
            lectures = new List<ILecture>
            {
                new Lecture("0", "Læs s. 45-55 i bogen"),
            };

            
            Course subject = new Course("subject", lectures);
            string uut = System.Text.Json.JsonSerializer.Serialize(subject);

            JsonDeserializer jsonDeserializer = new JsonDeserializer();
            jsonDeserializer.CourseStringToJSONObject(uut);
            Course[] aCopy = new Course[jsonDeserializer.Courses.Count];
            jsonDeserializer.Courses.CopyTo(aCopy, 0);
            Assert.AreEqual("", aCopy[0].Name);
        }

    }
}
