using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIDesktop.Models;
using WebAPIDesktop.Services;

namespace WebAPIDesktop.Controllers
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

        [HttpGet("{courseName}", Name = "GetCourse")]
        public ActionResult<Course> GetCourse(string courseName)
        {
            var course = _courseService.Get(courseName);
            if (course == null) { return NotFound(); }

            return course;
        }

        [HttpPost]
        public ActionResult<Course> PostCourse(Course course)
        {
            _courseService.Create(course);
            return CreatedAtRoute("GetCourse", new { courseName = course.Name }, course);
        }

        [HttpPut]
        public IActionResult PutCourse(Course course)
        {
            Course s = _courseService.Get(course.Name);
            if (s == null) { return NotFound(); }

            _courseService.Update(course);
            return NoContent();
        }
    }
}
