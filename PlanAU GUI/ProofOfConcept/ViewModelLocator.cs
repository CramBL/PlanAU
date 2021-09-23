using ProofOfConcept.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel
        {
            get => new MainWindowViewModel();
        }
    }
}
