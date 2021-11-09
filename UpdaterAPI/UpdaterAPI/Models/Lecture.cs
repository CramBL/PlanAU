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
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string CourseName { get; set; }
        private DateTime _date;
        public string Number { get; set; }
        public DateTime Date { get => _date; set => _date = new DateTime(2021, 09, 24); }
        public string PreparationDescription { get; set; }
        public string DateString { get; set; }

        public Lecture() { }
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
