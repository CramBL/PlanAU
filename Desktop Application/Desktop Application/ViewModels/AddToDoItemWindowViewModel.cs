using Desktop_Application.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Prism.Services.Dialogs;
using Prism.Commands;
using System.Windows;

namespace Desktop_Application.ViewModels
{
    class AddToDoItemWindowViewModel : BindableBase, IDialogAware
    {
        public AddToDoItemWindowViewModel()
        {

        }

        private ToDoItem _toDoItem;
        public ToDoItem ToDoItem
        {
            get => _toDoItem;
            set => SetProperty(ref _toDoItem, value);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            ToDoItem = ((App)Application.Current).ToDoItem;

        }

        public string Title { get; } = "Add a ToDo Item";
        public event Action<IDialogResult> RequestClose;



        private DelegateCommand _cancelButton;
        public DelegateCommand CancelButton =>
            _cancelButton ??= new DelegateCommand(ExecuteCancelButton);

        void ExecuteCancelButton()
        {
            //closing window
            ButtonResult result = ButtonResult.Cancel;
            RaiseRequestClose(new DialogResult(result));
        }

        private DelegateCommand _okButton;
        public DelegateCommand OKButton =>
            _okButton ??= new DelegateCommand(ExecuteOKButton);

        void ExecuteOKButton()
        {
            //adding new ToDo item
            ButtonResult result = ButtonResult.OK;
            // Use the ToDoItem object to transfer data to the MainWindow
            ((App)Application.Current).ToDoItem = ToDoItem;
            RaiseRequestClose(new DialogResult(result));
        }
        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }


    }





    


}
