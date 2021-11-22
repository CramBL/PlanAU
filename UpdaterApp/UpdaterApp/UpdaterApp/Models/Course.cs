using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpdaterApp.Models
{
    public class Course : ICourse
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("id")]
        public string Id { get; set; }
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

        public Course() { }

        public Course(string name, List<Lecture> lectures)
        {
            Name = name;
            Lectures = lectures;
        }
    }

    public interface ICourse
    {
        string Id { get; set; }
        string Name { get; set; }
        List<Lecture> Lectures { get; set; }
    }
}
