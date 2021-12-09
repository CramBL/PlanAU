using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Desktop_Application.Models;

namespace Test
{
    class LectureUnitTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase("1", "lave unit tets")]

        public void creatingInstanceOfLecture(string number, string description)
        {
            List<string> list = new List<string>();
            list.Add(description);
            Lecture lecture = new Lecture(number, list);
            Assert.AreEqual(number, lecture.Number);
            Assert.AreEqual(description, lecture.PreparationItems[0]);
            Assert.AreEqual(null, lecture.CourseName);
            Assert.AreEqual(null, lecture.DateString);

        }



    }
}
