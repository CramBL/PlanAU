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
    public class LectureController : Controller
    {
        private readonly LectureService _lectureService;

        public LectureController(LectureService lectureService)
        {
            _lectureService = lectureService;
        }

        [HttpGet]
        public ActionResult<List<Lecture>> Get() => _lectureService.Get();

        [HttpGet("{id}", Name = "GetStudent")]
        public ActionResult<Lecture> GetStudent(string id)
        {
            var lecture = _lectureService.Get(id);
            if (lecture == null) { NotFound(); }

            return lecture;
        }

        [HttpPost]
        public ActionResult<Lecture> PostStudent(Lecture lecture)
        {
            _lectureService.Create(lecture);
            return CreatedAtRoute("GetStudent", new { id = lecture.Id }, lecture);
        }

        [HttpPut]
        public IActionResult PutStudent(Lecture lecture)
        {
            Lecture s = _lectureService.Get(lecture.Id);
            if (s == null) { return NotFound(); }

            _lectureService.Update(lecture);
            return NoContent();
        }
    }
}
