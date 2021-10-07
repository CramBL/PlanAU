using Desktop_Application.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Prism.Services.Dialogs;
using Prism.Commands;

namespace Desktop_Application.ViewModels
{
    class AddToDoItemWindowViewModel : BindableBase, IDialogAware
    {
        public AddToDoItemWindowViewModel()
        {

        }

        private ToDoItem _toDoItem;
        public ToDoItem TodDoItem
        {
            get { return _toDoItem; }
            set { SetProperty(ref _toDoItem, value); }
        }

        public bool CanCloseDialog()
        {
            throw new NotImplementedException();
        }

        public void OnDialogClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            throw new NotImplementedException();
        }

        public string Title { get; }
        public event Action<IDialogResult> RequestClose;



        private DelegateCommand _cancelButton;
        public DelegateCommand CancelButton =>
            _cancelButton ?? (_cancelButton = new DelegateCommand(ExecuteCancelButton));

        void ExecuteCancelButton()
        {
            //closing window
        }

        private DelegateCommand _okCommand;
        public DelegateCommand OKCommand =>
            _okCommand ?? (_okCommand = new DelegateCommand(ExecuteOKCommand));

        void ExecuteOKCommand()
        {
            //adding new ToDo iteam

        }


    }





    


}
