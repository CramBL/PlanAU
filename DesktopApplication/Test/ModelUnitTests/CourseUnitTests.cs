using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop_Application.Models
{
    class CourseUnitTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ConstructorAndLectureList_CreateInstance_newInstanceCreates()
        {
            List<ILecture> lectures = new List<ILecture>();
            lectures = new List<ILecture>
                {
                    new Lecture("0", "Læs s. 45-55 i bogen"),
                };

            ICourse Subject;
            Subject = new Course("Subject", lectures);
            Lecture[] aCopy = new Lecture[lectures.Count];
            Subject.Lectures.CopyTo(aCopy, 0);
            Assert.AreEqual(1, Subject.Lectures.Count);
            Assert.AreEqual("0",aCopy[0].Number);
            Assert.AreEqual("Læs s. 45-55 i bogen", aCopy[0].PreparationDescription);
        }



    }
}
