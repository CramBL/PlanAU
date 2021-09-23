using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.Models
{
    public class Lecture : ILecture
    {
        private DateTime _date;
        private string _preperation;
        public string Number { get; set; }
        public DateTime Date { get => _date; set => _date = new DateTime(2021, 09, 24); }
        public string PreperationDescription { get; set; } //set is no implemented
        
        public Lecture(string number, string prepDiscription)
        {
            Number = number;
            Date = new DateTime(2021, 09, 23);
            PreperationDescription = prepDiscription;
        }
    }

    public interface ILecture
    {
        string Number { get; set; }
        DateTime Date { get; set; }
        string PreperationDescription { get; set; }

    }
}
