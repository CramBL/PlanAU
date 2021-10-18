﻿using Desktop_Application.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;
using Desktop_Application.Models;
using Desktop_Application.DataAccessLayer;

namespace Desktop_Application.ViewModels
{
    class LoginViewModel : BindableBase
    {

        #region Properties
        private string _userNameBox;
        public string UserNameBox
        {
            get { return _userNameBox; }
            set { SetProperty(ref _userNameBox, value); }
        }

        private string _passwordBox;
        public string PasswordBox
        {
            get { return _passwordBox; }
            set { SetProperty(ref _passwordBox, value); }
        }
        #endregion

        #region Command
        private DelegateCommand _moveWindow;
        public DelegateCommand MoveWindow =>
            _moveWindow ?? (_moveWindow = new DelegateCommand(ExecuteMoveWindow));

        void ExecuteMoveWindow()
        {
            App.Current.MainWindow.DragMove(); //throws exception when closing loginView
        }


        private DelegateCommand<string> _loginCommand;
        public DelegateCommand<string> LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand<string>(ExecuteLoginCommand));

        void ExecuteLoginCommand(string userName)
        {
            if (DAL_Student.LoginAttemptAuthorize(UserNameBox, PasswordBox).Result)
            {
                ((App)App.Current).Student = new Student(UserNameBox, PasswordBox);
                HomeView homeViewInstance = new HomeView();
                homeViewInstance.Show();
                App.Current.MainWindow.Close();
            }
            else
                System.Windows.MessageBox.Show("Wrong Password or UserID, try again");
        }

        private DelegateCommand<string> _registerCommand;
        public DelegateCommand<string> RegisterCommand =>
            _registerCommand ?? (_registerCommand = new DelegateCommand<string>(ExecuteRegisterCommand));

        void ExecuteRegisterCommand(string userName)
        {
            System.Windows.MessageBox.Show("Register is not available / not implemented ");
        }

        private DelegateCommand _closeWindow;
        public DelegateCommand CloseWindow =>
            _closeWindow ?? (_closeWindow = new DelegateCommand(ExecuteCloseWindow));

        void ExecuteCloseWindow()
        {
            App.Current.MainWindow.Close();
        }

        private DelegateCommand _bypass;
        public DelegateCommand Bypass =>
            _bypass ?? (_bypass = new DelegateCommand(ExecuteBypass));

        void ExecuteBypass()
        {
            ((App)App.Current).Student = new Student("AU999999", "");

            HomeView HomeViewInstance = new HomeView();
            HomeViewInstance.Show();
            App.Current.MainWindow.Close();
        }

        #endregion

    }
}
