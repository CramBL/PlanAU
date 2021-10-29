using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopApplication.Models
{
    public interface IMessageBox
    {
        void Show(string message);
    }

    public class MessageBox : IMessageBox
    {
        public void Show(string message)
        {
            System.Windows.MessageBox.Show(message);
        }
    }

    public class FakeMessageBox : IMessageBox
    {
        public string Result { get; set; }
        public void Show(string message)
        {
            Result = message;
        }
    }
}
