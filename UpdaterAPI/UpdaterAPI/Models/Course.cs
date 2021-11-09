using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdaterAPI.Models;

namespace UpdaterAPI.Models
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
        string Name { get; set; }
        List<Lecture> Lectures { get; set; }
    }
}
