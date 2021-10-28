using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DBApi.Models;
using MongoDB.Driver;

namespace DBApi.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IStudentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _students = database.GetCollection<Student>(settings.StudentCollectionName);
        }

        public List<Student> Get()
        {
            return _students.Find(student => true).ToList();
        }

        public Student Get(string id)
        {
            return _students.Find(student => student.auId == id).FirstOrDefault();
        }

        public Student Post(Student student)
        {
            _students.InsertOne(student);
            return student;
        }

        public void Update(Student updatedStudent)
        {
            _students.ReplaceOne(student => student.auId == updatedStudent.auId, updatedStudent);
        }
    }
}
