using Desktop_Application.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net;
using System.Net.Security;
using System.Text;
using Desktop_Application.Models;
using Desktop_Application.DataAccessLayer;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;
using Desktop_Application.DataAccessLayer;

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

        private DelegateCommand _moveWindow;
        public DelegateCommand MoveWindow =>
            _moveWindow ??= new DelegateCommand(ExecuteMoveWindow);

        void ExecuteMoveWindow()
        {
            App.Current.Windows[0].DragMove();
        }

        private DelegateCommand _createNewCommand;
        public DelegateCommand CreateNewCommand =>
            _createNewCommand ??= new DelegateCommand(ExecuteCreateNewCommandAsync);

         async void ExecuteCreateNewCommandAsync()
        {
            //valider at indtastede username er på rigtig form:

            if (new InputValidator().ValidUsernameSyntax(NewUserNameBox)&& new InputValidator().ValidPasswordSyntax(NewPasswordBox))
            {
                ((App)App.Current).Student = new Student(NewUserNameBox, NewPasswordBox);
                ((App)App.Current).Student.Email = MailBox;

                StudentDataAccess s1 = new StudentDataAccess();
                var result =await s1.PostStudent(((App) App.Current).Student);

                if (result == HttpStatusCode.Created.ToString())
                {
                    HomeView HomeViewInstance = new HomeView();
                    App.Current.Windows[0].Close();
                    HomeViewInstance.Show();
                }
                else
                {
                    MessageBox.Show("Something went wrong HTTP Status code is: " + result);
                }
               

            }
            else
                System.Windows.MessageBox.Show("Invalid Username or Password(password needs between 8-20 characters 1 lower, 1 upper and one special characters) - Try again!");
        }

        private DelegateCommand _closeWindow;
        public DelegateCommand CloseWindow =>
            _closeWindow ??= new DelegateCommand(ExecuteCloseWindow);

        void ExecuteCloseWindow()
        {
            App.Current.Shutdown();

        }

        private DelegateCommand _minimalizeWindow;
        public DelegateCommand MinimalizeWindow =>
            _minimalizeWindow ??= new DelegateCommand(ExecuteMinimalizeWindow);

        void ExecuteMinimalizeWindow()
        {
            //App.Current.MainWindow.Close();
            App.Current.Windows[0].WindowState = WindowState.Minimized;


        }


        #endregion

    }
}
