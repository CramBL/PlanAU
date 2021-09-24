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
        ICourse PRJ;
        ICourse GUI;
        ICourse DAB;
        ICourse SWT;
        ICourse SWD;
        ICourse NGK;
        private List<ILecture> lectures;

        #region Properties
        private ObservableCollection<Models.ICourse> _selectedCourses;
        public ObservableCollection<Models.ICourse> SelectedCourses
        {
            get => _selectedCourses;
            set { SetProperty(ref _selectedCourses, value); }
        }
        #endregion

        private ObservableCollection<string> _preparationItems;
        public ObservableCollection<string> PreparationItems
        {
            get { return _preparationItems; }
            set { SetProperty(ref _preparationItems, value); }
        }

        #region Method
        public MainWindowViewModel()
        {
            setFakeCourses();

            SelectedCourses = new ObservableCollection<ICourse>();
            SelectedCourses.Add(PRJ);
            SelectedCourses.Add(GUI);
            SelectedCourses.Add(DAB);
            SelectedCourses.Add(SWT);
            SelectedCourses.Add(SWD);
            SelectedCourses.Add(NGK);

            PreparationItems = new ObservableCollection<string>();
            makePreparationItemStrings();
        }

        private void makePreparationItemStrings()
        {
            foreach (var varcourse in SelectedCourses)
            {
                foreach (var varlecture in varcourse.Lectures)
                {
                    PreparationItems.Add(varcourse.Name + "  " + varlecture.Number + "  " + varlecture.PreparationDescription + "  " + varlecture.Date.ToShortDateString());
                }
            }
        }


        private void setFakeCourses()
        {
            lectures = new();
            lectures.Add(new Lecture("0", "Læs s. 45-55 i bogen"));
            lectures.Add(new Lecture("1.1", "Se to videoer"));
            lectures.Add(new Lecture("1.2", "Læs de to links"));

            PRJ = new Course("PRJ", lectures);
            GUI = new Course("GUI", lectures);
            DAB = new Course("DAB", lectures);
            SWT = new Course("SWT", lectures);
            SWD = new Course("SWD", lectures);
            NGK = new Course("NGK", lectures);
        }
        #endregion

        #region Commands
        private DelegateCommand<string> _selectOneCourse;
        public DelegateCommand<string> SelectOneCourse =>
            _selectOneCourse ?? (_selectOneCourse = new DelegateCommand<string>(ExecuteSelectOneCourse));

        void ExecuteSelectOneCourse(string selectedCourse)
        {
            PreparationItems.Clear();
            SelectedCourses.Clear();
            SelectedCourses.Add(new Course(selectedCourse, lectures));
            makePreparationItemStrings();
        }

        private DelegateCommand _selectAllCourses;
        public DelegateCommand SelectAllCourses =>
            _selectAllCourses ?? (_selectAllCourses = new DelegateCommand(ExecuteSelectAllCourses));

        void ExecuteSelectAllCourses()
        {
            PreparationItems.Clear();
            SelectedCourses.Clear();
            SelectedCourses.Add(PRJ);
            SelectedCourses.Add(GUI);
            SelectedCourses.Add(DAB);
            SelectedCourses.Add(SWT);
            SelectedCourses.Add(SWD);
            SelectedCourses.Add(NGK);
            makePreparationItemStrings();
        }
        #endregion
    }
}
