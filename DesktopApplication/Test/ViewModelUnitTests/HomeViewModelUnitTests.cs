using System;
using System.Collections.Generic;
using System.Text;
using Desktop_Application.DataAccessLayer;
using Desktop_Application.Models;
using Desktop_Application.ViewModels;
using DesktopApplication.Models;
using NSubstitute;
using NUnit.Framework;
using Prism.Services.Dialogs;

namespace DesktopApplication.Test.Unit.ViewModelUnitTests
{
    class HomeViewModelUnitTests
    {
        private HomeViewModel _uut;

        string validUserName = "AU999999";
        string validPassword = "123456";
        ToDoItem TestToDoItem;

        private List<ILecture> lectures;
        private ICourse course;


        private IStudentDataAccess _dalStudent;
        private IMessageBox _messageBox;
        private IDialogService _dialogService;

        [SetUp]
        public void Setup()
        {

            _dialogService = Substitute.For<IDialogService>();

            _uut = new HomeViewModel(_dialogService);


            //substitute dependencies
            
            _uut.DalStudent = (_dalStudent = Substitute.For<IStudentDataAccess>());
            _uut.MessageBox = (_messageBox = Substitute.For<IMessageBox>());

            //set test data
            _uut.Student = new Student(validUserName, validPassword);
            TestToDoItem = new ToDoItem(
                "fake ToDo Item", "fake beskrivelse", DateTime.Today);
            _uut.Student.ToDoItems.Add(TestToDoItem);
        }

        [Test]
        public void ExecuteRemoveToDoItem_RemoveToDoItem_ToDoItemMovedToDone()
        {
            
            //act
            _uut.RemoveToDoItem.Execute(TestToDoItem);

            Assert.That(_uut.Student.ToDoItems.Count.Equals(0));
            Assert.That(_uut.Student.DoneToDoItems.Count.Equals(1));
        }

        [Test]
        public void ExecuteRemoveToDoItem_RemoveToDoItem_UpdateStudent()
        {
            //arrange
            _dalStudent.UpdateStudent(_uut.Student).Returns(true);
            //act
            _uut.RemoveToDoItem.Execute(TestToDoItem);
            //assert
            _dalStudent.Received(1).UpdateStudent(_uut.Student);
        }

        [Test]
        public void ExecuteRemoveToDoItem_UpdateFails_ShowErrorMessageBox()
        {
            //arrange
            _dalStudent.UpdateStudent(_uut.Student).Returns(false);
            //act
            _uut.RemoveToDoItem.Execute(TestToDoItem);
            //assert
            _messageBox.ReceivedWithAnyArgs(1).Show("");//AnyArgs so test still works if error message changes
        }

        //[Test] //Rigtig kode er ikke implementeret
        //public void ExecuteSelectOneCourse_SelectOneCourse_CourseSelected()
        //{
        //    //arrange
        //    lectures = new List<ILecture>();
        //    lectures.Add(new Lecture("1", "lecture beskrivelse"));
        //    course = new Course("TestKursus", lectures);
        //    //act
        //    _uut.SelectOneCourse.Execute(course.Name);
            
        //    //assert
        //    Assert.IsTrue(_uut.SelectedCourses.Contains(course));
        //    //Ikke kodet færdigt
        //}

        

    }
}
