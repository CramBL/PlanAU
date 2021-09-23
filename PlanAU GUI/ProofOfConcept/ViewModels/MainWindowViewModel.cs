using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.ViewModels
{
    class MainWindowViewModel
    {
        #region Properties
        #endregion

        #region Method
        #endregion

        #region Commands
        #endregion


        private DelegateCommand<string> select_Course;
        public DelegateCommand<string> Select_Course =>
            select_Course ?? (select_Course = new DelegateCommand<string>(ExecuteSelect_Course));

        void ExecuteSelect_Course(string selectedCourse)
        {
            //Do something depending on the course
        }
    }
}
