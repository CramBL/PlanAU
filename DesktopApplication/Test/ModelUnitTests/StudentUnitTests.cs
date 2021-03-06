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

        [SetUp]
        public void Setup()
        {

        }

         [TestCase("au656565","marsbarlover")]
         public void Student_useConstructor_objectcreated(string auid, string password)
         {
            Student s1 = new Student(auid, password);
            Assert.AreEqual(auid,s1.AU_ID);
            Assert.AreEqual(password, s1.Password);
          
         }

        [TestCase("au656565", "marsbarlover")]
        public void Student_DBgetAndSet_FirstNullAfterSetEqualtoString(string auid, string password)
        {
            Student s1 = new Student(auid, password);
            Assert.AreEqual(null, s1.DBId);
            s1.DBId = "fakestring";
            Assert.AreEqual("fakestring", s1.DBId);
        }


         [TestCase("au656565", "marsbarlover")]
        public void Student_AddMail_mailStringAdded(string auid, string password)
        {
            Student s1 = new Student(auid, password);
            Assert.AreEqual(auid, s1.AU_ID);
            Assert.AreEqual(password, s1.Password);
            s1.Email = "mail@mail.com";
            Assert.AreEqual("mail@mail.com", s1.Email);
        }

        [TestCase("au656565", "marsbarlover")]
        public void Student_ChangeMail_mailChanged(string auid, string password)
        {
            Student s1 = new Student(auid, password);
            Assert.AreEqual(auid, s1.AU_ID);
            Assert.AreEqual(password, s1.Password);
            s1.Email = "mail@mail.com";
            s1.Email = "new@mail.com";

            Assert.AreEqual("new@mail.com", s1.Email);
        }

        
        [TestCase("au656565", "marsbarlover")]
        public void Todoitems_addtodoitems_itemIsAdded(string auid, string password)
        {
            Student s1 = new Student(auid, password);
            Assert.AreEqual(auid, s1.AU_ID);
            ObservableCollection<ToDoItem> tasks = new ObservableCollection<ToDoItem>();
            tasks.Add(new ToDoItem("Unit test", "lave unit test", new DateTime(2021,10,29)));
            s1.ToDoItems = tasks;

            ToDoItem[] aCopy = new ToDoItem[s1.ToDoItems.Count];
            s1.ToDoItems.CopyTo(aCopy, 0);
            Assert.AreEqual("Unit test",aCopy[0].ToDoTitle);
            Assert.AreEqual("lave unit test", aCopy[0].ToDoDescription);
            Assert.AreEqual(false, aCopy[0].Done);
            Assert.AreEqual(new DateTime(2021, 10, 29), aCopy[0].Date);
            Assert.AreEqual("1",s1.ToDoItems.Count.ToString());
        }

        [TestCase("au656565", "marsbarlover")]
        public void TodoItems_addedToDoItems4Parameter_itemsadded(string auid, string password)
        {
            Student s1 = new Student(auid, password);
            Assert.AreEqual(auid, s1.AU_ID);
            ObservableCollection<ToDoItem> tasks = new ObservableCollection<ToDoItem>();
            tasks.Add(new ToDoItem("Unit test", "lave unit test", new DateTime(2021,10,29),true));
            s1.DoneToDoItems = tasks;

            ToDoItem[] aCopy = new ToDoItem[s1.DoneToDoItems.Count];
            s1.DoneToDoItems.CopyTo(aCopy, 0);
            Assert.AreEqual("Unit test", aCopy[0].ToDoTitle);
            Assert.AreEqual("lave unit test", aCopy[0].ToDoDescription);
            Assert.AreEqual(true, aCopy[0].Done);
            Assert.AreEqual(new DateTime(2021,10,29), aCopy[0].Date);
            Assert.AreEqual("1", s1.DoneToDoItems.Count.ToString());
        }
    }
}
