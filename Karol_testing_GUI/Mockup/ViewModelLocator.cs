using System;
using System.Collections.Generic;
using System.Text;

namespace Mockup
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel
        {
            get => new MainWindowViewModel();
        }
    }
}
