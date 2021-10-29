using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Desktop_Application.Models;

namespace Test
{
    class TodoItemUnitTest
    {
         DateTime date = new DateTime(2021, 10, 29);
        [SetUp]
        public void Setup()
        {
            
        }

        [TestCase("Unit test", "lave unit test")]
        public void ToDoItem_CreateNewInstanceWith3Parameters_ObjectCreated(string title, string description)
        {
            ToDoItem task_1 = new ToDoItem(title,description,new DateTime(2021,10,28));
            Assert.AreEqual(title, task_1.ToDoTitle);
            Assert.AreEqual(description, task_1.ToDoDescription);
            Assert.AreEqual(date, task_1.Date);

            // TodoItem der bliver lavet med contructoren med 3 parametre har altid status false på done
            Assert.AreEqual(false, task_1.Done);
        }


        [TestCase("Unit test","lave unit test")]
        public void CToDoItem_CreateNewInstanceWith4Parameters_ObjectCreated(string title, string description)
        {
            ToDoItem task_1 = new ToDoItem(title, description, new DateTime(2021,10,29), true);
            Assert.AreEqual(title, task_1.ToDoTitle);
            Assert.AreEqual(description, task_1.ToDoDescription);
            Assert.AreEqual(date, task_1.Date);
            Assert.AreEqual(true, task_1.Done);
        }
  
    }
}
