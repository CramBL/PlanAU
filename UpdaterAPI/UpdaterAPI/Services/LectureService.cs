using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpdaterAPI.Models;

namespace UpdaterAPI.Services
{
    public class LectureService
    {
        private readonly IMongoCollection<Lecture> _lectures;

        public LectureService(ILectureDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _lectures = database.GetCollection<Lecture>(settings.LectureCollectionName);
        }

        public List<Lecture> Get() => _lectures.Find(Lecture => true).ToList();

        public Lecture Get(string id) => _lectures.Find<Lecture>(book => book.Id == id).FirstOrDefault();

        public Lecture Create(Lecture lecture)
        {
            _lectures.InsertOne(lecture);
            return lecture;
        }

        public void Update(Lecture updatedLecture) => _lectures.ReplaceOne(lecture => lecture.Id == updatedLecture.Id, updatedLecture); 
    }
}
