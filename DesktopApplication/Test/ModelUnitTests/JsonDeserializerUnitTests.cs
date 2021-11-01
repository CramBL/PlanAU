using System;
using System.Collections.Generic;
using System.Text;
using Desktop_Application.Models;
using NUnit.Framework;

namespace DesktopApplication.Test.Unit.ModelUnitTests
{
    class JsonDeserializerUnitTests
    {

        [SetUp]
        public void Setup()
        {
        }


        //[TestCase()]
        //public void CourseStringToJSONObject_GetsACourseObject_DeserializeIt()
        //{
        //    List<ILecture> lectures = new List<ILecture>();
        //    lectures = new List<ILecture>
        //    {
        //        new Lecture("0", "Læs s. 45-55 i bogen"),
        //    };

        //    ICourse Subject;
        //    Subject = new Course("Subject", lectures);
        //    string uut = System.Text.Json.JsonSerializer.Serialize(Subject);

        //    JsonDeserializer jsonDeserializer = new JsonDeserializer();
        //    jsonDeserializer.CourseStringToJSONObject(uut);
        //    Course[] aCopy = new Course[jsonDeserializer.Courses.Count];
        //    jsonDeserializer.Courses.CopyTo(aCopy, 0);
        //    Assert.AreEqual("", aCopy[0].Name);
        //}

    }
}
