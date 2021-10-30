using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Navigation;
using DryIoc;

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

        [JsonPropertyName("title")]
        public string ToDoTitle { get; set; }

        
        [JsonPropertyName("description")]
        public string ToDoDescription { get; set; }
        
        [JsonPropertyName("lastDate")]
        public DateTime Date { get; set; }
        
        [JsonIgnore]
        public bool Done { get; set; }
        #endregion
    }
}
