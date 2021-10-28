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
using System.Windows;

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
            _createNewCommand ??= new DelegateCommand(ExecuteCreateNewCommand);

        public void ExecuteCreateNewCommand()
        {
            //valider at indtastede username er på rigtig form:

            if (new InputValidator().ValidUsernameSyntax(NewUserNameBox))
            {
                ((App)App.Current).Student = new Student("AU999999", "");
                HomeView HomeViewInstance = new HomeView();
                App.Current.Windows[0].Close();
                HomeViewInstance.Show();

            }
            else
                System.Windows.MessageBox.Show("Invalid Username - Try again!");
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
