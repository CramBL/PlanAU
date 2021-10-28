using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Desktop_Application.Models
{
    public class ToDoItem
    {
        public ToDoItem() { }
        public ToDoItem(string title, string description, DateTime date)
        {
            ToDoTitle = title;
            ToDoDescription = description;
            Date = date;
            Done = false;
        }
        public ToDoItem(string title, string description, DateTime date, bool done)
        {
            ToDoTitle = title;
            ToDoDescription = description;
            Date = date;
            Done = done;
        }
        #region Fields
        private string _toDoTitle;
        [JsonPropertyName("title")]
        public string ToDoTitle { get; set; }
        private string _toDoDescription;
        [JsonPropertyName("description")]
        public string ToDoDescription { get; set; }
        private DateTime _date;
        [JsonPropertyName("lastDate")]
        public DateTime Date { get; set; }
        private bool _done;
        [JsonIgnore]
        public bool Done { get; set; }
        #endregion
    }
}
