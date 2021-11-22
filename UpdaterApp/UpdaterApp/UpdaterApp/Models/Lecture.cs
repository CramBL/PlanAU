using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpdaterApp.Models
{
    public class Lecture : ILecture
    {
        [JsonPropertyName("courseName")]
        public string CourseName { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

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
        
        public Lecture() { }

        public Lecture(string number, List<string> prepItems)
        {
            Number = number;
            Date = new DateTime(2021, 09, 23);
            PreparationItems = prepItems;
        }
    }

    public interface ILecture
    {
        string CourseName { get; set; }
        string Number { get; set; }
        DateTime Date { get; set; }
        List<string> PreparationItems { get; set; }
    }
}
