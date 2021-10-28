using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Desktop_Application.Models
{
    public class Student : BindableBase
    {
        public Student(string auid, string password)
        {
            AU_ID = auid;
            Password = password;
            ToDoItems = new ObservableCollection<ToDoItem>();
            DoneToDoItems = new ObservableCollection<ToDoItem>();
        }

        public Student() { }

        //public string Au_id { get; set; }
        //[JsonPropertyName("password")]
        //public string Password { get; set; }
        [JsonPropertyName("id")]
        public string DBId { get; set; }
        
        private string _Email;
        [JsonPropertyName("email")]
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }
        
        private string _AU_ID;

        [JsonPropertyName("auId")]

        public string AU_ID
        {
            get { return _AU_ID; }
            set { SetProperty(ref _AU_ID, value); }
        }
        private string _password;
        [JsonPropertyName("password")]
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value);    }
        }

        private ObservableCollection<ToDoItem> _toDoItems;
        [JsonPropertyName("toDos")]
        public ObservableCollection<ToDoItem> ToDoItems
        {
            get { return _toDoItems; }
            set { SetProperty(ref _toDoItems, value); }
        }
        private ObservableCollection<ToDoItem> _doneToDoItems;
        [JsonIgnore]
        public ObservableCollection<ToDoItem> DoneToDoItems
        {
            get { return _doneToDoItems; }
            set { SetProperty(ref _doneToDoItems, value); }
        }
    }
}
