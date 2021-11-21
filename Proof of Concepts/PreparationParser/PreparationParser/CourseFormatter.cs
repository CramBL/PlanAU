using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessBrightspace.Models;

namespace DataAccessBrightspace
{
    class CourseFormatter
    {
        public ICourse DictionaryToCourseObject(string courseName, Dictionary<int, List<string>> parsedContentDictionary)
        {
            var course = new Course(courseName, new List<ILecture>());

            foreach (var keyValuePair in parsedContentDictionary)
            {
                var lecturePrepItemList = new List<string>();
                course.Lectures.Add(new Lecture(keyValuePair.Key.ToString(), lecturePrepItemList));
                foreach (var value in keyValuePair.Value)
                {
                    course.Lectures[keyValuePair.Key].PreparationDescription.Add(value);
                }
            }

            return course;
        }
    }
}
