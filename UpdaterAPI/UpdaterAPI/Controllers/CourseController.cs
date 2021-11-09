using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpdaterAPI.Models;
using UpdaterAPI.Services;

namespace UpdaterAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult<List<Course>> Get() => _courseService.Get();

        [HttpGet("{id}", Name = "GetStudent")]
        public ActionResult<Course> GetStudent(string id)
        {
            var course = _courseService.Get(id);
            if (course == null) { NotFound(); }

            return course;
        }

        [HttpPost]
        public ActionResult<Course> PostStudent(Course course)
        {
            _courseService.Create(course);
            return CreatedAtRoute("GetStudent", new { id = course.Id }, course);
        }

        [HttpPut]
        public IActionResult PutStudent(Course course)
        {
            Course s = _courseService.Get(course.Id);
            if (s == null) { return NotFound(); }

            _courseService.Update(course);
            return NoContent();
        }
    }
}
