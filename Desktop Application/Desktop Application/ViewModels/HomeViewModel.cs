﻿using Prism.Commands;
using Prism.Mvvm;
using Desktop_Application.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Services.Dialogs;
using System.Windows;

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

        ICourse PRJ;
        ICourse GUI;
        ICourse DAB;
        ICourse SWT;
        ICourse SWD;
        ICourse NGK;
        private List<ILecture> lectures;

        #region Properties
        private IDialogService _dialogService;

        private ObservableCollection<Models.ICourse> _selectedCourses;
        public ObservableCollection<Models.ICourse> SelectedCourses
        {
            get => _selectedCourses;
            set { SetProperty(ref _selectedCourses, value); }
        }

        private ObservableCollection<string> _preparationItems;
        public ObservableCollection<string> PreparationItems
        {
            get { return _preparationItems; }
            set { SetProperty(ref _preparationItems, value); }
        }

        private ToDoItem _toDoItem;
        public ToDoItem ToDoItem
        {
            get { return _toDoItem; }
            set { SetProperty(ref _toDoItem, value); }
        }

        private Student _student;
        public Student Student
        {
            get { return _student; }
            set { SetProperty(ref _student, value); }
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

            PreparationItems = new ObservableCollection<string>();
            makePreparationItemStrings();
        }

        private void setFakeCourses()
        {
            lectures = new List<ILecture>();
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
        #endregion

        #region Commands
        private DelegateCommand<ToDoItem> _removeToDoItem;
        public DelegateCommand<ToDoItem> RemoveToDoItem =>
            _removeToDoItem ?? (_removeToDoItem = new DelegateCommand<ToDoItem>(ExecuteRemoveToDoItem));

        void ExecuteRemoveToDoItem(ToDoItem currentToDoItem)
        {
            Student.ToDoItems.Remove(currentToDoItem);
            Student.DoneToDoItems.Add(new ToDoItem(currentToDoItem.ToDoTitle, currentToDoItem.ToDoDescription, currentToDoItem.Date, currentToDoItem.Done));
        }

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

        private DelegateCommand _openAddToDoItemDialog;
        public DelegateCommand OpenAddToDoItemDialog =>
            _openAddToDoItemDialog ?? (_openAddToDoItemDialog = new DelegateCommand(ExecuteOpenAddToDoItemDialog));

        

        void ExecuteOpenAddToDoItemDialog()
        {
            var tempToDoItem = new ToDoItem("","","");
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
