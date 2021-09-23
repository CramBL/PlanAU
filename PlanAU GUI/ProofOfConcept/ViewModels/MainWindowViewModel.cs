using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProofOfConcept.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        #region Properties
        private ObservableCollection<Models.ICourse> _selectedCourses;
        public ObservableCollection<Models.ICourse> Courses
        {
            get => _courses;
            set { SetProperty(ref _courses, value); }
        }

        #endregion

        #region Method
        public MainWindowViewModel()
        {
            Courses.Add(new Models.Course("PRJ"));
            Courses.Add(new Models.Course("GUI"));
            Courses.Add(new Models.Course("DAB"));
            Courses.Add(new Models.Course(""));
            Courses.Add(new Models.Course());
        }
        #endregion

        #region Commands
        private DelegateCommand<string> select_Course;
        public DelegateCommand<string> Select_Course =>
            select_Course ?? (select_Course = new DelegateCommand<string>(ExecuteSelect_Course));

        void ExecuteSelect_Course(string selectedCourse)
        {
            CurrentCourse = selectedCourse;
        }
        #endregion
    }
}
