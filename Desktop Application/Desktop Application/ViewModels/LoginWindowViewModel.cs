using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop_Application.ViewModels
{
    class LoginWindowViewModel
    {
        #region Command

        private DelegateCommand<string> _usernameBox;
        public DelegateCommand<string> UsernameBox =>
            _usernameBox ?? (_usernameBox = new DelegateCommand<string>(ExecuteUserNameBox));

        void ExecuteUserNameBox(string userName)
        {

        }

        private DelegateCommand<string> _passwordBox;
        public DelegateCommand<string> PasswordBox =>
            _passwordBox ?? (_passwordBox = new DelegateCommand<string>(ExecutePasswordBox));

        void ExecutePasswordBox(string userName)
        {


        }


        private DelegateCommand<string> _loginCommand;
        public DelegateCommand<string> LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand<string>(ExecuteLoginCommand));

        void ExecuteLoginCommand(string userName)
        {

        }

        private DelegateCommand<string> _registerCommand;
        public DelegateCommand<string> RegisterCommand =>
            _registerCommand ?? (_registerCommand = new DelegateCommand<string>(ExecuteRegisterCommand));

        void ExecuteRegisterCommand(string userName)
        {

        }

        #endregion

    }
}
