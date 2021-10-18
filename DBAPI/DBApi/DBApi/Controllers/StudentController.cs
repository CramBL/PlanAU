﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DBApi.Models;

namespace DBApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private StudentContext studentContext;

        public StudentController(StudentContext context)
        {
            studentContext = context;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return studentContext.STUDENTS;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent (Student student)
        {
            studentContext.STUDENTS.Add(student);
            await studentContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.AU_ID }, student);
        }

        [HttpPost("/authorize")]
        public async Task<ActionResult<Boolean>> AutherizeStudent(Student student)
        {
            Student s = await studentContext.STUDENTS.FindAsync(student.AU_ID);
            if (s != null)
            {
                if (s.PASSWORD == student.PASSWORD)
                    return student.PASSWORD == s.PASSWORD;
                else
                    return Unauthorized();
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(string id)
        {
            var student = await studentContext.STUDENTS.FindAsync(id);

            if (student == null) { return NotFound(); }

            return student;
        }
    }
}
