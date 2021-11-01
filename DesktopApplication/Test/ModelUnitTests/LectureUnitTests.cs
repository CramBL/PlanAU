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

        [TestCase("1","lave unit tets")]

        public void creatingInstanceOfLecture(string number, string discription)
        {
            Lecture lecture = new Lecture(number,discription);
            Assert.AreEqual(number, lecture.Number);
            Assert.AreEqual(discription, lecture.PreparationDescription);
            Assert.AreEqual(null, lecture.CourseName);
            Assert.AreEqual(null, lecture.DateString);
            
        }
        // mangler test til date


    }
}
