using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Desktop_Application.Models
{
    public class JsonSerializer
    {
        //TODO:
        //change to student ToDo list specific object
        public string ToDo_JsonString { get; set; }

        public void ToJSONstring(Object o)
        {
            //List<string> jsonStrings = new List<string>();
            //Foreach hvis der bruges en liste af todo items
            //brug denne i foreach loopet:
            //jsonStrings.Add(JsonSerializer.Serialize(o));

            ToDo_JsonString = System.Text.Json.JsonSerializer.Serialize(o);   
        }
    }

    public class JsonDeserializer
    {
        public List<ICourse> Courses { get; set; }

        public void CourseStringToJSONObject(string courseString)
        {
            Courses.Add(System.Text.Json.JsonSerializer.Deserialize<ICourse>(courseString));
        }
        
        //Add method:
        //public void "ToDoToJSONObject(string ToDostring)"

    }
}
    