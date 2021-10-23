using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Desktop_Application.Models;
using System.Collections.ObjectModel;

namespace Test
{
    class StudentUnitTests
    {
        Student s1 = new Student();
        [SetUp]
        public void Setup()
        {
            s1.Password = "hornslet";
            s1.AU_ID = "au700400";
        }

        [Test]
        public void StudentHasCorrectData()
        {
            Assert.AreEqual("au700400",s1.AU_ID);
            Assert.AreEqual("hornslet", s1.Password);
        }

        [Test]
        public void StudentAddMail()
        {
            s1.Email = "mail@mail.com";
            Assert.AreEqual("mail@mail.com", s1.Email);
        }

        [Test]
        public void StudentChangeMail()
        {
            s1.Email = "mail@mail.com";
            s1.Email = "new@mail.com";

            Assert.AreEqual("new@mail.com", s1.Email);
        }

        [Test]
        public void StudentChangeAuID()
        {
            s1.AU_ID = "au600600";
            Assert.AreEqual("au600600", s1.AU_ID);
        }

        [Test]
        public void StudentChangePassword()
        {
            s1.Password = "8543";
            Assert.AreEqual("8543", s1.Password);
        }

        [Test]
        public void InsertTodoItemWith3parameterconstructor()
        {
            ObservableCollection<ToDoItem> tasks = new ObservableCollection<ToDoItem>();
            tasks.Add(new ToDoItem("Unit test", "lave unit test", "23-10-2021"));
            ToDoItem replicaObject = new ToDoItem("Unit test", "lave unit test", "23-10-2021");
            s1.ToDoItems = tasks;

            ToDoItem[] aCopy = new ToDoItem[s1.ToDoItems.Count];
            s1.ToDoItems.CopyTo(aCopy, 0);
            Assert.AreEqual("Unit test",aCopy[0].ToDoTitle);
            Assert.AreEqual("lave unit test", aCopy[0].ToDoDescription);
            Assert.AreEqual(false, aCopy[0].Done);
            Assert.AreEqual("23-10-2021", aCopy[0].Date);
            Assert.AreEqual("1",s1.ToDoItems.Count.ToString());
        }

        [Test]
        public void InsertTodoItemWith4parameterconstructor()
        {
            ObservableCollection<ToDoItem> tasks = new ObservableCollection<ToDoItem>();
            tasks.Add(new ToDoItem("Unit test", "lave unit test", "23-10-2021",true));
            ToDoItem replicaObject = new ToDoItem("Unit test", "lave unit test", "23-10-2021");
            s1.ToDoItems = tasks;

            ToDoItem[] aCopy = new ToDoItem[s1.ToDoItems.Count];
            s1.ToDoItems.CopyTo(aCopy, 0);
            Assert.AreEqual("Unit test", aCopy[0].ToDoTitle);
            Assert.AreEqual("lave unit test", aCopy[0].ToDoDescription);
            Assert.AreEqual(true, aCopy[0].Done);
            Assert.AreEqual("23-10-2021", aCopy[0].Date);
            Assert.AreEqual("1", s1.ToDoItems.Count.ToString());
        }


    }
}
