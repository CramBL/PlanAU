using DBApi.Models;
using DBApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
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

        [HttpPost]
        public ActionResult<Student> PostStudent(Student student)
        {
            _studentService.Post(student);
            return CreatedAtRoute("GetStudent", new { id = student.auId }, student);
        }

        [HttpPost("/authorize")]
        public ActionResult<Student> AutherizeStudent(Student student)
        {
            Student s = _studentService.Get(student.auId);
            if (s != null)
            {
                if (s.password == student.password)
                    return s;
                else
                    return Unauthorized();
            }
            return NotFound();
        }

        [HttpPut]
        public IActionResult PutStudent(Student student)
        {
            Student s = _studentService.Get(student.auId);
            if (s == null) { return NotFound(); }

            _studentService.Update(student);
            return NoContent();
        }

        //private StudentContext studentContext;

        //public StudentController(StudentContext context)
        //{
        //    studentContext = context;
        //}

        //[HttpGet]
        //public IEnumerable<Student> Get()
        //{
        //    return studentContext.STUDENTS;
        //}

        //[HttpPost]
        //public async Task<ActionResult<Student>> PostStudent (Student student)
        //{
        //    studentContext.STUDENTS.Add(student);
        //    await studentContext.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetStudent), new { id = student.AU_ID }, student);
        //}

        //[HttpPost("/authorize")]
        //public async Task<ActionResult<Boolean>> AutherizeStudent(Student student)
        //{
        //    Student s = await studentContext.STUDENTS.FindAsync(student.AU_ID);
        //    if (s != null)
        //    {
        //        if (s.PASSWORD == student.PASSWORD)
        //            return student.PASSWORD == s.PASSWORD;
        //        else
        //            return Unauthorized();
        //    }
        //    return NotFound();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Student>> GetStudent(string id)
        //{
        //    var student = await studentContext.STUDENTS.FindAsync(id);

        //    if (student == null) { return NotFound(); }

        //    return student;
        //}
    }
}
