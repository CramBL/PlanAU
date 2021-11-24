using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desktop_Application.Models
{
    public class Lecture : ILecture
    {
        [JsonPropertyName("courseName")]
        public string CourseName { get; set; }
        private DateTime _date;
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get => _date; set => _date = new DateTime(2021, 09, 24); }
        private List<string> _preparationItems;
        [JsonPropertyName("preparationDescription")]
        public List<string> PreparationItems
        {
            get => _preparationItems;
            set {
                if (_preparationItems == value) return;
                _preparationItems = value;
            }
        }
        public string DateString { get; set; }
        
        public Lecture(string number, List<string> prepItems)
        {
            Number = number;
            Date = new DateTime(2021, 09, 23);
            PreparationItems = prepItems;
        }

        public Lecture() { }
    }

    public interface ILecture
    {
        string CourseName { get; set; }
        string Number { get; set; }
        DateTime Date { get; set; }
        List<string> PreparationItems { get; set; }
        string DateString { get; set; }
    }
}
