using System;
using System.Collections.Generic;

namespace WebAPIDesktop.Models
{
    public class Lecture : ILecture
    {

        public string CourseName { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public List<string> PreparationDescription { get; set; }

        public Lecture() { }
    }

    public interface ILecture
    {
        string CourseName { get; set; }
        string Number { get; set; }
        DateTime Date { get; set; }
        List<string> PreparationDescription { get; set; }
    }
}
