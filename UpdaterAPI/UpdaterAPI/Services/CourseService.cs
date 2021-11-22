using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpdaterAPI.Models;

namespace UpdaterAPI.Services
{
    public class CourseService
    {
        private readonly IMongoCollection<Course> _courses;

        public CourseService(ICourseDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _courses = database.GetCollection<Course>(settings.CourseCollectionName);
        }

        public List<Course> Get() => _courses.Find(Course => true).ToList();

        public Course Get(string courseName) => _courses.Find<Course>(course => course.Name == courseName).FirstOrDefault();

        public Course Create(Course course)
        {
            _courses.InsertOne(course);
            return course;
        }

        public void Update(Course updatedCourse) => _courses.ReplaceOne(course => course.Id == updatedCourse.Id, updatedCourse); 
    }
}
