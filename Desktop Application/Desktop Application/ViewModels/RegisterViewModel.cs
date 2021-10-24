using Desktop_Application.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;
using Desktop_Application.Models;
using Desktop_Application.DataAccessLayer;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Desktop_Application.ViewModels
{
    public class RegisterViewModel : BindableBase
    {

        #region Properties

        private string _newUserNameBox;

        public string NewUserNameBox
        {
            get { return _newUserNameBox; }
            set { SetProperty(ref _newUserNameBox, value); }
        }

        private string _newPasswordBox;

        public string NewPasswordBox
        {
            get { return _newPasswordBox; }
            set { SetProperty(ref _newPasswordBox, value); }
        }

        private string _mailBox;

        public string MailBox
        {
            get { return _mailBox; }
            set { SetProperty(ref _mailBox, value); }
        }


        #endregion

        #region Command

        
        //private DelegateCommand _moveWindow;
        //public DelegateCommand MoveWindow =>
        //    _moveWindow ??= new DelegateCommand(ExecuteMoveWindow);

        //void ExecuteMoveWindow()
        //{
        //    App.Current.MainWindow.DragMove();
        //}


        //private DelegateCommand _createCommand;
        //public DelegateCommand CreateCommand =>
        //    _createCommand ??= new DelegateCommand(ExecuteCreateCommand);

        //    public void ExecuteCreateCommand()
        //{

        //    ((App)App.Current).Student = new Student("AU999999", "");

        //    HomeView HomeViewInstance = new HomeView();
        //    HomeViewInstance.Show();
        //    App.Current.MainWindow.Close();
        //}

        //private DelegateCommand _closeWindow;
        //public DelegateCommand CloseWindow =>
        //    _closeWindow ??= new DelegateCommand(ExecuteCloseWindow);

        //void ExecuteCloseWindow()
        //{
        //    LoginView LoginViewInstance = new LoginView();
        //    App.Current.MainWindow.Close();
        //    LoginViewInstance.Show();
        //}
        #endregion

    }
}
