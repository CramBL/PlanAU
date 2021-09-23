using Prism.Commands;
using Prism.Mvvm;
using ProofOfConcept.Models;
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
        public ObservableCollection<Models.ICourse> SelectedCourses
        {
            get => _selectedCourses;
            set { SetProperty(ref _selectedCourses, value); }
        }
        #endregion

        #region Method
        public MainWindowViewModel()
        {
            SelectedCourses = new ObservableCollection<ICourse>();
            SelectedCourses.Add(new Course("PRJ"));
            SelectedCourses.Add(new Course("GUI"));
            SelectedCourses.Add(new Course("DAB"));
            SelectedCourses.Add(new Course("SWT"));
            SelectedCourses.Add(new Course("SWD"));
            SelectedCourses.Add(new Course("NGK"));
        }
        #endregion

        #region Commands
        private DelegateCommand<string> _selectOneCourse;
        public DelegateCommand<string> SelectOneCourse =>
            _selectOneCourse ?? (_selectOneCourse = new DelegateCommand<string>(ExecuteSelectOneCourse));

        void ExecuteSelectOneCourse(string selectedCourse)
        {
            SelectedCourses.Clear();
            SelectedCourses.Add(new Course(selectedCourse));
        }

        private DelegateCommand _selectAllCourses;
        public DelegateCommand SelectAllCourses =>
            _selectAllCourses ?? (_selectAllCourses = new DelegateCommand(ExecuteSelectAllCourses));

        void ExecuteSelectAllCourses()
        {
            SelectedCourses.Clear();
            SelectedCourses.Add(new Course("PRJ"));
            SelectedCourses.Add(new Course("GUI"));
            SelectedCourses.Add(new Course("DAB"));
            SelectedCourses.Add(new Course("SWT"));
            SelectedCourses.Add(new Course("SWD"));
            SelectedCourses.Add(new Course("NGK"));
        }
        #endregion
    }
}
