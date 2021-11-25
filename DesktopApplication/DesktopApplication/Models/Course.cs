using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desktop_Application.Models
{
    public class Course : ICourse
    {


        [JsonPropertyName("name")]
        public string Name { get; set; }

        private List<Lecture> _lectures;
        [JsonPropertyName("lectures")]
        public List<Lecture> Lectures
        {
            get => _lectures;
            set {
                if (_lectures == value) return;
                _lectures = value;
            }
        }

        public Course() {}
        public Course(string name, List<Lecture> lectures)
        {
            Name = name;
            Lectures = lectures;
        }
    }

    public interface ICourse
    {
        string Name { get; set; }
        List<Lecture> Lectures { get; set; }
    }
}
