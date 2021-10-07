using Desktop_Application.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop_Application.ViewModels
{
    class AddToDoItemWindowViewModel : BindableBase
    {
        private ToDoItem _toDoItem;
        public ToDoItem TodDoItem
        {
            get { return _toDoItem; }
            set { SetProperty(ref _toDoItem, value); }
        }
    }
}
