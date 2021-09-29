using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProofOfConcept.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        

        public LoginWindow()
        {

            InitializeComponent();

        }
        private void LoginWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void TestButton_OnClick(object sender, RoutedEventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source = .\..."); -> ServerExplorer
            //SqlAdapter sda = new SqlAdapter("SELECT Count(*) From Login where Username)'' + UserBox.Text + and Password = '' + passwordBox.Text + '', con")
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //if (dt.Row[0][0].ToString()=="1"){ -> to this what is to test
            this.Hide();
            MainWindow ss = new MainWindow();
            ss.Show();

            //}
            //else 
            //{ MessageBox.Show("Please Check your Username or Password");
        }
    }
    

}
