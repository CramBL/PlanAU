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

        [Test]
        public void CreateATodoItemWith3ParametreConstr()
        {
            ToDoItem task_1 = new ToDoItem("Unit test", "lave unit test", "23/10-2021");
            Assert.AreEqual("Unit test", task_1.ToDoTitle);
            Assert.AreEqual("lave unit test", task_1.ToDoDescription);
            Assert.AreEqual("23/10-2021", task_1.Date);
            // TodoItem der bliver lavet med contructoren med 3 parametre har altid status false på done
            Assert.AreEqual(false, task_1.Done);
        }


        [Test]
        public void CreateATodoItemWith4ParametreConstr()
        {
            ToDoItem task_1 = new ToDoItem("Unit test", "lave unit test", "23/10-2021", true);
            Assert.AreEqual("Unit test", task_1.ToDoTitle);
            Assert.AreEqual("lave unit test", task_1.ToDoDescription);
            Assert.AreEqual("23/10-2021", task_1.Date);
            Assert.AreEqual(true, task_1.Done);
        }
  
    }
}
