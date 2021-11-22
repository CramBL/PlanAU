﻿using DBApi.Models;
using DBApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Controllers
{
    [ApiController]
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;
        private IPasswordHasher _passwordHasher;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
            _passwordHasher = new PasswordHasher();
        }

        [HttpGet("/")]
        public ActionResult<List<Student>> GetStudents()
        {
            return _studentService.Get();
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public ActionResult<Student> GetStudent(string id)
        {
            var student = _studentService.Get(id);
            if (student == null) { NotFound(); }

            return student;
        }

        [HttpPost("/")]
        public ActionResult<Student> PostStudent(Student student)
        {
            _studentService.Post(student);
            return CreatedAtRoute("GetStudent", new { id = student.auId }, student);
        }

        [HttpPost("/authorize")]
        public ActionResult<Student> AuthorizeStudent(Student student)
        {
            Student s = _studentService.Get(student.auId);
            if (s != null)
            {
                if (_passwordHasher.IsValid(student.password, s.password)) 
                    return s;
                else
                    return Unauthorized();
            }
            return NotFound();
        }

        [HttpPut("/")]
        public IActionResult PutStudent(Student student)
        {
            Student s = _studentService.Get(student.auId);
            if (s == null) { return NotFound(); }

            _studentService.Update(student);
            return NoContent();
        }
    }
}
