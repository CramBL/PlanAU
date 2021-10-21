using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Application.Models
{
    public class Lecture : ILecture
    {
        public string CourseName { get; set; }
        private DateTime _date;
        public string Number { get; set; }
        public DateTime Date { get => _date; set => _date = new DateTime(2021, 09, 24); }
        public string PreparationDescription { get; set; }
        public string DateString { get; set; }
        
        public Lecture(string number, string prepDiscription)
        {
            Number = number;
            Date = new DateTime(2021, 09, 23);
            PreparationDescription = prepDiscription;
        }
    }

    public interface ILecture
    {
        string CourseName { get; set; }
        string Number { get; set; }
        DateTime Date { get; set; }
        string PreparationDescription { get; set; }
        string DateString { get; set; }
    }
}
