using System;
using System.Collections.Generic;

namespace DataAccessBrightspace.Models
{
    public class Lecture : ILecture
    {
        public string CourseName { get; set; }
        private DateTime _date;
        public string Number { get; set; }
        public DateTime Date { get => _date; set => _date = new DateTime(2021, 09, 24); }
        public List<string> PreparationDescription { get; set; }
        public string DateString { get; set; }
        
        public Lecture(string number, List<string> prepDescription)
        {
            Number = number;
            Date = new DateTime(2021, 09, 23);
            PreparationDescription = prepDescription;
        }
    }

    public interface ILecture
    {
        string CourseName { get; set; }
        string Number { get; set; }
        DateTime Date { get; set; }
        List<string> PreparationDescription { get; set; }
        string DateString { get; set; }
    }
}
