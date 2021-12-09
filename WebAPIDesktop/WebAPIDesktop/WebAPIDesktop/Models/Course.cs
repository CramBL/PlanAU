using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPIDesktop.Models
{
    public class Course : ICourse
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Lecture> Lectures { get; set; }
        public Course(){ }
    }

    public interface ICourse
    {
        public string Id { get; set; }
        string Name { get; set; }
        List<Lecture> Lectures { get; set; }
    }
}
