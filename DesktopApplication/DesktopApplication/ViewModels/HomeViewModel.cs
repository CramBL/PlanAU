using Prism.Commands;
using Prism.Mvvm;
using Desktop_Application.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Services.Dialogs;
using System.Windows;
using Desktop_Application.Views;
using System.Windows.Media;
using Desktop_Application.DataAccessLayer;
using DesktopApplication.Models;
using MessageBox = System.Windows.MessageBox;
using Syncfusion.UI.Xaml.Scheduler;
using Ical.Net;
using System.IO;
using System.Threading.Tasks;
using DesktopApplication.DAL;
using Ical.Net.CalendarComponents;
using Microsoft.Win32;

namespace Desktop_Application.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ICourse PRJ;
        private ICourse GUI;
        private ICourse DAB;
        private ICourse SWT;
        private ICourse SWD;
        private ICourse NGK;
        private List<Lecture> lectures;
        private List<Lecture> lectures2;
        private ISchedulerInserter schedulerInserter;
        private DataAccessUpdaterAPI dataAccessUpdater;
        private Schedular schedular;

        #region Properties
        private ScheduleAppointmentCollection _appointmentCollection;
        public ScheduleAppointmentCollection AppointmentCollection
        {
            get { return _appointmentCollection; }
            set { SetProperty(ref _appointmentCollection, value); }
        }

        private IDialogService _dialogService;

        private ObservableCollection<Models.ICourse> _selectedCourses;
        public ObservableCollection<Models.ICourse> SelectedCourses
        {
            get => _selectedCourses;
            set => SetProperty(ref _selectedCourses, value);
        }

        private ObservableCollection<ILecture> _unpackedLectures;
        public ObservableCollection<ILecture> UnpackedLectures
        {
            get { return _unpackedLectures; }
            set { SetProperty(ref _unpackedLectures, value); }
        }

        private ToDoItem _toDoItem;
        public ToDoItem ToDoItem
        {
            get => _toDoItem;
            set => SetProperty(ref _toDoItem, value);
        }

        private Student _student;
        public Student Student
        {
            get => _student;
            set => SetProperty(ref _student, value);
        }
        #endregion

        #region Class Dependencies

        public IStudentDataAccess DalStudent { get; set; }
        public IMessageBox MessageBox { get; set; }

        #endregion

        #region Method
        public void ConvertICALToSFFormat(Calendar calendar)
        {

            foreach (var itemEvent in calendar?.Events)
            {
                ScheduleAppointment appointment1 = new ScheduleAppointment();
                string starttime = itemEvent.DtStart.ToString();

                starttime = starttime.Remove(20);
                DateTime datetimestart = DateTime.Parse(starttime);
                appointment1.StartTime = datetimestart;

                string endtime = itemEvent.DtEnd.ToString();

                endtime = endtime.Remove(20);
                DateTime datetimeend = DateTime.Parse(endtime);
                appointment1.EndTime = datetimeend;

                appointment1.Subject = itemEvent.Summary;
                AppointmentCollection.Add(appointment1);
            }

        }

        public HomeViewModel(IDialogService dialogService)
        {
            AppointmentCollection = new ScheduleAppointmentCollection();
            schedulerInserter = new SchedulerInserter(); 
            dataAccessUpdater = new DataAccessUpdaterAPI();
            schedular = new Schedular();
            //Creating new event   
            //ScheduleAppointment clientMeeting = new ScheduleAppointment();
            //DateTime currentDate = DateTime.Now;
            //DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0);
            //DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0);
            //clientMeeting.StartTime = startTime;
            //clientMeeting.EndTime = endTime;
            //clientMeeting.Subject = "ClientMeeting";
            //AppointmentCollection.Add(clientMeeting);

            //Null check to support unit tests:
            if (Application.Current != null)
                Application.Current.Resources["BackgroundBrush"] = Brushes.White;
            Student = ((App)App.Current)?.Student;
            Student.Courses.Add("PRJ"); //test

            _dialogService = dialogService;
            DalStudent = new StudentDataAccess();
            MessageBox = new DesktopApplication.Models.MessageBox();

            //SetFakeCourses();

            SelectedCourses = new ObservableCollection<ICourse>();
            //SelectedCourses.Add(PRJ);
            //SelectedCourses.Add(GUI);
            //SelectedCourses.Add(DAB);
            //SelectedCourses.Add(SWT);
            //SelectedCourses.Add(SWD);
            //SelectedCourses.Add(NGK);
            setCourses();
            UnpackedLectures = new ObservableCollection<ILecture>();
            UnpackLecturesForPrep();

        }

        private async void setCourses()
        {
            foreach (string varCourse in Student.Courses)
            {
                var course = await dataAccessUpdater.GetCourse(varCourse);
                SelectedCourses.Add(course);
            }
        }
        private void SetFakeCourses()
        {
            List<string> prepStrings1 = new List<string>();
            List<string> prepStrings2 = new List<string>();
            List<string> prepStrings3 = new List<string>();

            prepStrings1.Add("Læs:");
            prepStrings1.Add(" s. 45-55 i bogen");
            prepStrings1.Add("Links:");
            prepStrings1.Add("google.com");
            prepStrings2.Add("this is prep");
            prepStrings3.Add("Learn the lyrics to Barbie girl");

            lectures = new List<Lecture>
            {
                new Lecture("0", prepStrings1),
                new Lecture("1.1", prepStrings2),
                new Lecture("1.2", prepStrings3)
            };

            PRJ = new Course("PRJ", lectures);
            GUI = new Course("GUI", lectures);
            DAB = new Course("DAB", lectures);
            SWT = new Course("SWT", lectures);
            SWD = new Course("SWD", lectures);
            NGK = new Course("NGK", lectures);

        }

        private void UnpackLecturesForPrep()
        {
            UnpackedLectures.Clear();
            foreach (var course in SelectedCourses)
            {
                foreach (var lecture in course.Lectures)
                {
                    lecture.CourseName = course.Name;
                    lecture.DateString = lecture.Date.ToShortDateString();
                    UnpackedLectures.Add(lecture);
                }
            }
        }
        #endregion

        #region Commands

        private DelegateCommand _importICalFile;
        public DelegateCommand ImportICalFile =>
            _importICalFile ?? (_importICalFile = new DelegateCommand(ExecuteImportICalFile));

        async void  ExecuteImportICalFile()
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "iCalendar files (*.ics)|*.ics",
                //DefaultExt = "ics"
            };
            if (openDialog.ShowDialog(Application.Current.Windows[0]) == true)
            {
                FileStream fs = new FileStream(openDialog.FileName, FileMode.Open, FileAccess.Read);

                var calendar = Calendar.Load(fs);
                ConvertICALToSFFormat(calendar);
                fs.Close();
            }

            foreach (string varCourse in Student.Courses)
            {
                var course = await dataAccessUpdater.GetCourse(varCourse);
                schedular.insertPrep(_appointmentCollection, course);
            }
            
        }

        private DelegateCommand _moveWindow;
        public DelegateCommand MoveWindow =>
            _moveWindow ??= new DelegateCommand(ExecuteMoveWindow);

        void ExecuteMoveWindow()
        {
             App.Current.Windows[0].DragMove();
        }


        private DelegateCommand _toggleDarkmode;
        public DelegateCommand ToggleDarkmode =>
            _toggleDarkmode ??= new DelegateCommand(ExecuteToggleDarkmode);

        void ExecuteToggleDarkmode()
        {
            //udkommenteret pga. VS warnings, alt virker stadig og koden ser ud til at være redundant 
            //SolidColorBrush darkBrush = System.Windows.SystemColors.WindowBrush;
            SolidColorBrush darkBrush = new SolidColorBrush(
                    (Color)ColorConverter.ConvertFromString("#343434"));
            //SolidColorBrush PlanAUColourBrush = System.Windows.SystemColors.WindowBrush;
            SolidColorBrush PlanAUColourBrush = new SolidColorBrush(
                    (Color)ColorConverter.ConvertFromString("#FF00BE9C"));

            if (Application.Current.Resources["BackgroundBrush"] != Brushes.White)
            {
                Application.Current.Resources["BackgroundBrush"] = Brushes.White;
                Application.Current.Resources["MenuBrush"] = Brushes.White;
                Application.Current.Resources["TextBrush"] = Brushes.Black;
                Application.Current.Resources["BorderBrush"] = Brushes.Black;
                //Application.Current.Resources["MarkedItemBackgroundBrush"] = PlanAUColourBrush;
            }
            else
            {
                Application.Current.Resources["BackgroundBrush"] = darkBrush;
                Application.Current.Resources["MenuBrush"] = new SolidColorBrush(
                    (Color)ColorConverter.ConvertFromString("#404040"));
                Application.Current.Resources["TextBrush"] = Brushes.White;
                Application.Current.Resources["BorderBrush"] = PlanAUColourBrush;
                /*Application.Current.Resources["MarkedItemBackgroundBrush"] = new SolidColorBrush(
                    (Color)ColorConverter.ConvertFromString("#404040")); ;*/
            }



        }

        private DelegateCommand _logout;
        public DelegateCommand Logout =>
            _logout ??= new DelegateCommand(ExecuteLogout);

        void ExecuteLogout()
        {
            LoginView LoginViewInstance = new LoginView();
            LoginViewInstance.Show();
            App.Current.Windows[0].Close();
        }

        private DelegateCommand<ToDoItem> _removeToDoItem;
        public DelegateCommand<ToDoItem> RemoveToDoItem =>
            _removeToDoItem ??= new DelegateCommand<ToDoItem>(ExecuteRemoveToDoItem);

        private async void ExecuteRemoveToDoItem(ToDoItem currentToDoItem)
        {
            Student.ToDoItems.Remove(currentToDoItem);
            Student.DoneToDoItems.Add(new ToDoItem(currentToDoItem.ToDoTitle, currentToDoItem.ToDoDescription, currentToDoItem.Date, currentToDoItem.Done));
            bool didUpdate = await DalStudent.UpdateStudent(Student);
            if (!didUpdate)
            {
                MessageBox.Show("Todo was not added to DB!");
            }

        }

        private DelegateCommand<string> _selectOneCourse;
        public DelegateCommand<string> SelectOneCourse =>
            _selectOneCourse ??= new DelegateCommand<string>(ExecuteSelectOneCourse);

        private void ExecuteSelectOneCourse(string selectedCourse)
        {
            SelectedCourses.Clear();
            SelectedCourses.Add(new Course(selectedCourse, lectures));
            //PreparationItems.Clear();
            //makePreparationItemStrings();
            UnpackLecturesForPrep();
        }

        private DelegateCommand _selectAllCourses;
        public DelegateCommand SelectAllCourses =>
            _selectAllCourses ??= new DelegateCommand(ExecuteSelectAllCourses);

        private void ExecuteSelectAllCourses()
        {
            SelectedCourses.Clear();
            SelectedCourses.Add(PRJ);
            SelectedCourses.Add(GUI);
            SelectedCourses.Add(DAB);
            SelectedCourses.Add(SWT);
            SelectedCourses.Add(SWD);
            SelectedCourses.Add(NGK);
            //PreparationItems.Clear();
            //makePreparationItemStrings();
            UnpackLecturesForPrep();
        }

        private DelegateCommand _openAddToDoItemDialog;
        public DelegateCommand OpenAddToDoItemDialog =>
            _openAddToDoItemDialog ??= new DelegateCommand(ExecuteOpenAddToDoItemDialog);


        private void ExecuteOpenAddToDoItemDialog()
        {
            var tempToDoItem = new ToDoItem("", "", DateTime.Now);
            ((App)Application.Current).ToDoItem = tempToDoItem;
            _dialogService.ShowDialog("AddToDoItemWindow", null, async r =>
            {
                if (r.Result == ButtonResult.None)
                    Title = "Result is None";
                else if (r.Result == ButtonResult.OK)
                {
                    Title = "Result is OK";
                    ToDoItem = ((App)Application.Current).ToDoItem;
                    Student.ToDoItems.Add(ToDoItem);
                    bool didUpdate = await DalStudent.UpdateStudent(Student);
                    if (!didUpdate)
                    {
                        MessageBox.Show("Todo was not added to DB!");
                    }
                }
                else if (r.Result == ButtonResult.Cancel)
                    Title = "Result is Cancel";
                else
                    Title = "I Don't know what you did!?";
            });
        }

        private DelegateCommand _closeWindow;
        public DelegateCommand CloseWindow =>
            _closeWindow ??= new DelegateCommand(ExecuteCloseWindow);

        void ExecuteCloseWindow()
        {
            //App.Current.MainWindow.Close();
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
