using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop_Application.Models
{
    public class ToDoItem
    {
        public ToDoItem(string title, string description, string date)
        {
            ToDoTitle = title;
            ToDoDescription = description;
            Date = date;
            Done = false;
        }
        public ToDoItem(string title, string description, string date, bool done)
        {
            ToDoTitle = title;
            ToDoDescription = description;
            Date = date;
            Done = done;
        }
        #region Fields
        private string _toDoTitle;
        public string ToDoTitle { get; set; }
        private string _toDoDescription;
        public string ToDoDescription { get; set; }
        private string _date;
        public string Date { get; set; }
        private bool _done;
        public bool Done { get; set; }
        #endregion
    }
}
