using Desktop_Application.Models;
using Desktop_Application.Views;
using Prism.Ioc;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Desktop_Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public ToDoItem ToDoItem { get; internal set; }
        public Student Student { get; internal set; }

        protected override Window CreateShell()
        {
            return Container.Resolve<LoginView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AddToDoItemWindow, ViewModels.AddToDoItemWindowViewModel>();
        }
    }
}
