using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Desktop_Application.Models
{
    public class Student
    {
        public Student(string name, string auid)
        {
            Name = name;
            AuId = auid;
            ToDoList = new ObservableCollection<ToDoItem>();
            DoneToDos = new ObservableCollection<ToDoItem>();
        }
        private string _name;
        public string Name { get; set; }
        private string _auId;
        public string AuId { get; set; }
        private ObservableCollection<ToDoItem> _toDoList;
        public ObservableCollection<ToDoItem> ToDoList {get;set; }
        private ObservableCollection<ToDoItem> _doneToDos;
        public ObservableCollection<ToDoItem> DoneToDos { get; set; }

    }
}
