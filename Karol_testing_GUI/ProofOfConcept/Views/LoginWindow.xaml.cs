using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

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
            this.Hide();
            MainWindow ss = new MainWindow();
            ss.Show();

           
        }

        private void LoginButton_OnClickButton_OnClick(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PlanAU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); //if it is red need to be installed in nugets sqlclient
            string query = "SELECT* from STUDENTS WHERE AU_ID = '" + userBox.Text.Trim()+ "'and PASSWORD = '"+ passwordBox.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if(dtbl.Rows.Count == 1) //checking if there is a row for a user and his password
            {
                MainWindow ss = new MainWindow(); //if user name and password is correct then we create main window
                this.Hide();                       //hide a login window
                ss.Show();                          //and open main window
            }
            else
            {
                MessageBox.Show("Wrong Password or UserID, try again");
            }


        }
       
    }
    

}
