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
        private List<ILecture> lectures;
        private List<ILecture> lectures2;



        #region Properties
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

        public IDAL_Student DalStudent { get; set; }
        public IMessageBox MessageBox { get; set; }

        #endregion

        #region Method
        public HomeViewModel(IDialogService dialogService)
        {
            //Null check to support unit tests:
            if (Application.Current != null)
                Application.Current.Resources["BackgroundBrush"] = Brushes.White;
            Student = ((App) App.Current)?.Student;

            _dialogService = dialogService;
            DalStudent = new DAL_Student();
            MessageBox = new DesktopApplication.Models.MessageBox();

            SetFakeCourses();

            SelectedCourses = new ObservableCollection<ICourse>();
            SelectedCourses.Add(PRJ);
            SelectedCourses.Add(GUI);
            SelectedCourses.Add(DAB);
            SelectedCourses.Add(SWT);
            SelectedCourses.Add(SWD);
            SelectedCourses.Add(NGK);

            UnpackedLectures = new ObservableCollection<ILecture>();
            UnpackLecturesForPrep();

        }

        private void SetFakeCourses()
        {
            lectures = new List<ILecture>
            {
                new Lecture("0", "Læs s. 45-55 i bogen"),
                new Lecture("1.1", "Se to videoer"),
                new Lecture("1.2", "Læs de to links")
            };
            lectures2 = new List<ILecture>
            {
                new Lecture("0", "Læs s. 45-55 i bogen"),
                new Lecture("1.1", "Se to videoer"),
                new Lecture("1.2", "Læs de to links")
            };

            PRJ = new Course("PRJ", lectures);
            GUI = new Course("GUI", lectures2);
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
