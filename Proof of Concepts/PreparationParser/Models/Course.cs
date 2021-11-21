using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Application.Models
{
    public class Course : ICourse
    {
        

        public string Name { get; set; }

        private List<ILecture> _lectures;
        public List<ILecture> Lectures
        {
            get => _lectures;
            set {
                if (_lectures == value) return;
                _lectures = value;
            }
        }
        public Course(string name, List<ILecture> lectures)
        {
            Name = name;
            Lectures = lectures;
        }
    }

    public interface ICourse
    {
        string Name { get; set; }
        List<ILecture> Lectures { get; set; }
    }
}
