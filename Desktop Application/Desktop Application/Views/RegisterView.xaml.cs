using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop_Application.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        //Jeg har problemer med de funtioner, de virker ikke, hvis jeg laver dem til Commands
        private void RegisterWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginView LoginViewInstance = new LoginView();
            this.Close();
            //App.Current.MainWindow.Close();
            LoginViewInstance.Show();
        }

        private void RegisterButton_OnClick(object sender, RoutedEventArgs e)
        {
            
            HomeView HomeViewInstance = new HomeView();
            this.Close();
            HomeViewInstance.Show();


        }
    }
}
