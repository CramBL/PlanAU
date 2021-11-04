using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Desktop_Application.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HomeView : Window
    {
        public HomeView()
        {
            InitializeComponent();

            //tester med kalender, hvis man implementerer den selv
            string day = System.DateTime.Now.ToString("dddd");
            switch (day)
            {
                case "mandag":
                {
                    MondayDate.Text = DateTime.Now.ToString("dd-MM");
                    TuesdayDate.Text = DateTime.Now.AddDays(+1).ToString("dd-MM");
                    WedensdayDate.Text = DateTime.Now.AddDays(+2).ToString("dd-MM");
                    ThursdayDate.Text = DateTime.Now.AddDays(+3).ToString("dd-MM");
                    FridayDate.Text = DateTime.Now.AddDays(+4).ToString("dd-MM");
                    SaturdayDate.Text = DateTime.Now.AddDays(+5).ToString("dd-MM");
                    SundayDate.Text = DateTime.Now.AddDays(+6).ToString("dd-MM");
                    break;
                }
                case "tirsdag":
                {
                    MondayDate.Text = DateTime.Now.AddDays(-1).ToString("dd-MM");
                    TuesdayDate.Text = DateTime.Now.ToString("dd-MM");
                    WedensdayDate.Text = DateTime.Now.AddDays(+1).ToString("dd-MM");
                    ThursdayDate.Text = DateTime.Now.AddDays(+2).ToString("dd-MM");
                    FridayDate.Text = DateTime.Now.AddDays(+3).ToString("dd-MM");
                    SaturdayDate.Text = DateTime.Now.AddDays(+4).ToString("dd-MM");
                    SundayDate.Text = DateTime.Now.AddDays(+5).ToString("dd-MM");
                    break;
                }
                case "onsdag":
                {
                    MondayDate.Text = DateTime.Now.AddDays(-2).ToString("dd-MM");
                    TuesdayDate.Text = DateTime.Now.AddDays(-1).ToString("dd-MM");
                    WedensdayDate.Text = DateTime.Now.ToString("dd-MM");
                    ThursdayDate.Text = DateTime.Now.AddDays(+1).ToString("dd-MM");
                    FridayDate.Text = DateTime.Now.AddDays(+2).ToString("dd-MM");
                    SaturdayDate.Text = DateTime.Now.AddDays(+3).ToString("dd-MM");
                    SundayDate.Text = DateTime.Now.AddDays(+4).ToString("dd-MM");
                    break;
                }
                case "torsdag":
                {

                    MondayDate.Text = DateTime.Now.AddDays(-3).ToString("dd-MM");
                    TuesdayDate.Text = DateTime.Now.AddDays(-2).ToString("dd-MM");
                    WedensdayDate.Text = DateTime.Now.AddDays(-1).ToString("dd-MM");
                    ThursdayDate.Text = DateTime.Now.ToString("dd-MM");
                    FridayDate.Text = DateTime.Now.AddDays(+1).ToString("dd-MM");
                    SaturdayDate.Text = DateTime.Now.AddDays(+2).ToString("dd-MM");
                    SundayDate.Text = DateTime.Now.AddDays(+3).ToString("dd-MM");
                    break;
                }
                case "fredag":
                {
                    MondayDate.Text = DateTime.Now.AddDays(-4).ToString("dd-MM");
                    TuesdayDate.Text = DateTime.Now.AddDays(-3).ToString("dd-MM");
                    WedensdayDate.Text = DateTime.Now.AddDays(-2).ToString("dd-MM");
                    ThursdayDate.Text = DateTime.Now.AddDays(-1).ToString("dd-MM");
                    FridayDate.Text = DateTime.Now.ToString("dd-MM");
                    SaturdayDate.Text = DateTime.Now.AddDays(+1).ToString("dd-MM");
                    SundayDate.Text = DateTime.Now.AddDays(+2).ToString("dd-MM");
                    break;
                    }
                case "lørdag":
                {
                    MondayDate.Text = DateTime.Now.AddDays(-5).ToString("dd-MM");
                    TuesdayDate.Text = DateTime.Now.AddDays(-4).ToString("dd-MM");
                    WedensdayDate.Text = DateTime.Now.AddDays(-3).ToString("dd-MM");
                    ThursdayDate.Text = DateTime.Now.AddDays(-2).ToString("dd-MM");
                    FridayDate.Text = DateTime.Now.AddDays(-1).ToString("dd-MM");
                    SaturdayDate.Text = DateTime.Now.ToString("dd-MM");
                    SundayDate.Text = DateTime.Now.AddDays(+1).ToString("dd-MM");
                    break;
                    }
                case "søndag":
                {
                    MondayDate.Text = DateTime.Now.AddDays(-6).ToString("dd-MM");
                    TuesdayDate.Text = DateTime.Now.AddDays(-5).ToString("dd-MM");
                    WedensdayDate.Text = DateTime.Now.AddDays(-4).ToString("dd-MM");
                    ThursdayDate.Text = DateTime.Now.AddDays(-3).ToString("dd-MM");
                    FridayDate.Text = DateTime.Now.AddDays(-2).ToString("dd-MM");
                    SaturdayDate.Text = DateTime.Now.AddDays(-1).ToString("dd-MM");
                    SundayDate.Text = DateTime.Now.ToString("dd-MM");
                    break;
                    }

            }

        }
        //slut
        

    }
}
