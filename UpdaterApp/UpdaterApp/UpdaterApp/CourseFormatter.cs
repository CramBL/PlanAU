using System.Collections.Generic;
using UpdaterApp.Models;

namespace UpdaterApp
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
                    course.Lectures[keyValuePair.Key].PreparationItems.Add(value);
                }
            }

            return course;
        }
    }
}
