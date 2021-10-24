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
    public class LoginViewModel : BindableBase
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
            _moveWindow ??= new DelegateCommand(ExecuteMoveWindow);

        void ExecuteMoveWindow()
        {
            App.Current.MainWindow.DragMove(); //throws exception when closing loginView
        }


        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand =>
            _loginCommand ??= new DelegateCommand(ExecuteLoginCommand);

        async void ExecuteLoginCommand()
        {
            
            string ParsedUserName = ParseUsernameInput();

            if (ParsedUserName == "")
            {
                System.Windows.MessageBox.Show("Invalid Username - Try again!");
                return;
            }

            //TODO: Flyt alt der kan testes ud af denne funktion (når MongoDB er oppe og køre så det kan verificeres at det stadig fungerer)
            //1. Fjern brugen af App.Current - i stedet giv HomeView et Student object i constructor
            //2. Flyt verificering af password til en anden funktion
            //Der skal så kun være kald til disse funktioner og simple Show(), Close() og lignende i denne funktion

            ((App)App.Current).Student = new Student(ParsedUserName, PasswordBox);

            Task<bool> authorizeTask = DAL_Student.LoginAttemptAuthorize(((App)App.Current).Student);

            if (await authorizeTask)
            {
                HomeView homeViewInstance = new HomeView();
                homeViewInstance.Show();
                App.Current.MainWindow.Close();
            }
            else
                System.Windows.MessageBox.Show("Wrong Password or UserID, try again");
        }

        private DelegateCommand<string> _registerCommand;
        public DelegateCommand<string> RegisterCommand =>
            _registerCommand ??= new DelegateCommand<string>(ExecuteRegisterCommand);

        void ExecuteRegisterCommand(string userName)
        {

            RegisterView RegisterViewInstance = new RegisterView();
            RegisterViewInstance.Show();
            App.Current.MainWindow.Close();
        }

        private DelegateCommand _closeWindow;
        public DelegateCommand CloseWindow =>
            _closeWindow ??= new DelegateCommand(ExecuteCloseWindow);

        void ExecuteCloseWindow()
        {
            //App.Current.MainWindow.Close();
            App.Current.Shutdown();

        }

        private DelegateCommand _bypass;
        public DelegateCommand Bypass =>
            _bypass ??= new DelegateCommand(ExecuteBypass);

        void ExecuteBypass()
        {
            ((App)App.Current).Student = new Student("AU999999", "");

            HomeView HomeViewInstance = new HomeView();
            HomeViewInstance.Show();
            App.Current.MainWindow.Close();
        }

        #endregion

        #region helpMethods
        private string ParseUsernameInput()
        {
            string userName = UserNameBox;

            Match match = Regex.Match(userName, "^AU[0-9]{6}", RegexOptions.IgnoreCase);
            if (match.Success)
                return match.Value;
            else
                return "";
        }
        #endregion

    }
}
