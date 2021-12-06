using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop_Application.Models
{
   
    class CourseUnitTests
    {
        private List<Lecture> Lectures;
        private List<string> prepList;
        [SetUp]
        public void Setup()
        {
        
        }

        [TestCase("prj4", "drikke kaffe")]
        public void CourseConstructor_NewInstanceOfCoursewithLectures_CoúrseHasListOfLectures(string name, string prep) 
        {
            Lectures = new List<Lecture>();
            prepList = new List<string>();
            prepList.Add(prep);
            Lectures.Add(new Lecture("0", prepList));

            Course c1 = new Course(name,Lectures);

            Assert.AreEqual(c1.Lectures.ToString(), Lectures.ToString());
            Assert.AreEqual(name, c1.Name);

        }



    }
}
