using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Desktop_Application.Models;

namespace Test
{
    class TodoItemUnitTest
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [TestCase("Unit test", "lave unit test", "23/10-2021")]
        public void ToDoItem_CreateNewInstanceWith3Parameters_ObjectCreated(string title, string description, string date)
        {
            ToDoItem task_1 = new ToDoItem(title,description,date);
            Assert.AreEqual(title, task_1.ToDoTitle);
            Assert.AreEqual(description, task_1.ToDoDescription);
            Assert.AreEqual(date, task_1.Date);
            // TodoItem der bliver lavet med contructoren med 3 parametre har altid status false på done
            Assert.AreEqual(false, task_1.Done);
        }


        [TestCase("Unit test","lave unit test","28-10-2021")]
        public void CToDoItem_CreateNewInstanceWith4Parameters_ObjectCreated(string title, string description, string date)
        {
            ToDoItem task_1 = new ToDoItem(title, description, date, true);
            Assert.AreEqual(title, task_1.ToDoTitle);
            Assert.AreEqual(description, task_1.ToDoDescription);
            Assert.AreEqual(date, task_1.Date);
            Assert.AreEqual(true, task_1.Done);
        }
  
    }
}
