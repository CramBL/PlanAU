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

        [Test]

        public void creatingInstanceOfLecture()
        {
            Lecture lecture = new Lecture("1","lave unit test");
            Assert.AreEqual("1", lecture.Number);
            Assert.AreEqual("lave unit test", lecture.PreparationDescription);
        }



    }
}
