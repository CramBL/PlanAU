using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdaterAPI.Models
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
