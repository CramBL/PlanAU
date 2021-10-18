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

        #region Method
        public HomeViewModel(IDialogService dialogService)
        {
            Student = ((App) App.Current).Student;
            _dialogService = dialogService;

            setFakeCourses();

            SelectedCourses = new ObservableCollection<ICourse>();
            SelectedCourses.Add(PRJ);
            SelectedCourses.Add(GUI);
            SelectedCourses.Add(DAB);
            SelectedCourses.Add(SWT);
            SelectedCourses.Add(SWD);
            SelectedCourses.Add(NGK);

            UnpackedLectures = new ObservableCollection<ILecture>();
            unpackLecturesForPrep();

        }

        private void setFakeCourses()
        {
            lectures = new List<ILecture>
            {
                new Lecture("0", "Læs s. 45-55 i bogen"),
                new Lecture("1.1", "Se to videoer"),
                new Lecture("1.2", "Læs de to links")
            };

            PRJ = new Course("PRJ", lectures);
            GUI = new Course("GUI", lectures);
            DAB = new Course("DAB", lectures);
            SWT = new Course("SWT", lectures);
            SWD = new Course("SWD", lectures);
            NGK = new Course("NGK", lectures);

        }

        private void unpackLecturesForPrep()
        {
            UnpackedLectures.Clear();
            foreach (var varcourse in SelectedCourses)
            {
                foreach (var lecture in course.Lectures)
                {
                    varlecture.CourseName = varcourse.Name;
                    varlecture.DateString = varlecture.Date.ToShortDateString();
                    UnpackedLectures.Add(varlecture);
                }
            }
        }
        #endregion

        #region Commands
        private DelegateCommand _toggleDarkmode;
        public DelegateCommand ToggleDarkmode =>
            _toggleDarkmode ?? (_toggleDarkmode = new DelegateCommand(ExecuteToggleDarkmode));

        void ExecuteToggleDarkmode()
        {
            if (Application.Current.Resources["BackgroundBrush"] == Brushes.White)
            {
                Application.Current.Resources["BackgroundBrush"] = Brushes.DarkGray;
            }
            else
            {
                Application.Current.Resources["BackgroundBrush"] = Brushes.White;
            }
            Application.Current.Resources["BackgroundBrush"] = Brushes.DarkGray;
            //does not work
        }

        private DelegateCommand _logout;
        public DelegateCommand Logout =>
            _logout ?? (_logout = new DelegateCommand(ExecuteLogout));

        void ExecuteLogout()
        {
            LoginView LoginViewInstance = new LoginView();
            LoginViewInstance.Show();
            App.Current.Windows[0].Close();
        }

        private DelegateCommand<ToDoItem> _removeToDoItem;
        public DelegateCommand<ToDoItem> RemoveToDoItem =>
            _removeToDoItem ??= new DelegateCommand<ToDoItem>(ExecuteRemoveToDoItem);

        private void ExecuteRemoveToDoItem(ToDoItem currentToDoItem)
        {
            Student.ToDoItems.Remove(currentToDoItem);
            Student.DoneToDoItems.Add(new ToDoItem(currentToDoItem.ToDoTitle, currentToDoItem.ToDoDescription, currentToDoItem.Date, currentToDoItem.Done));
        }

        private DelegateCommand<string> _selectOneCourse;
        public DelegateCommand<string> SelectOneCourse =>
            _selectOneCourse ?? (_selectOneCourse = new DelegateCommand<string>(ExecuteSelectOneCourse));

        private void ExecuteSelectOneCourse(string selectedCourse)
        {
            SelectedCourses.Clear();
            SelectedCourses.Add(new Course(selectedCourse, lectures));
            //PreparationItems.Clear();
            //makePreparationItemStrings();
            unpackLecturesForPrep();
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
            unpackLecturesForPrep();
        }

        private DelegateCommand _openAddToDoItemDialog;
        public DelegateCommand OpenAddToDoItemDialog =>
            _openAddToDoItemDialog ??= new DelegateCommand(ExecuteOpenAddToDoItemDialog);


        private void ExecuteOpenAddToDoItemDialog()
        {
            
            
            var tempToDoItem = new ToDoItem("", "", DateTime.Now.ToString("MM-dd-yyyy"));
            ((App)Application.Current).ToDoItem = tempToDoItem;
            _dialogService.ShowDialog("AddToDoItemWindow", null, r =>
            {
                if (r.Result == ButtonResult.None)
                    Title = "Result is None";
                else if (r.Result == ButtonResult.OK)
                {
                    Title = "Result is OK";
                    ToDoItem = ((App)Application.Current).ToDoItem;
                    Student.ToDoItems.Add(ToDoItem);
                }
                else if (r.Result == ButtonResult.Cancel)
                    Title = "Result is Cancel";
                else
                    Title = "I Don't know what you did!?";
            });
        }
        #endregion
    }
}
