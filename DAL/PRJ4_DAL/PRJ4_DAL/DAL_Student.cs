using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRJ4_DAL
{
    public class DAL_Student
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<Student>> GetStudents()
        {
            var response = client.GetStreamAsync("https://localhost:44323/Student/");
            List<Student> students = await JsonSerializer.DeserializeAsync<List<Student>>(await response);
            return students;
        }

        public static async Task<Student> GetStudent(string au_id)
        {
            var response = client.GetStreamAsync("https://localhost:44323/Student/" + au_id);
            Student student = await JsonSerializer.DeserializeAsync<Student>(await response);
            return student;
        }

        public static async Task<string> PostStudent(Student _student)
        {
            string student = JsonSerializer.Serialize<Student>(_student);
            var postContent = new StringContent(student, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44323/Student/", postContent);
            return response.StatusCode.ToString();
        }
    }
}
