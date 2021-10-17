using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Desktop_Application.Models;

namespace Desktop_Application.DataAccessLayer
{
    public class DAL_Student
    {
        private static readonly HttpClient Client = new HttpClient();

        private static readonly string RequestUri = "https://localhost:44323/authorize";
        private static readonly string MediaType = "application/json";

        public static async Task<bool> LoginAttemptAuthorize(Student student)
        {

            var postContent = GetSerializedEncodedStudent(student);

            var response = await PostContentToPlanAUapi<HttpContent>(postContent);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        //public static async Task<List<Student>> GetStudents()
        //{
        //    var response = client.GetStreamAsync("https://localhost:44323/Student/");
        //    List<Student> students = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Student>>(await response);
        //    return students;
        //}

        //public static async Task<Student> GetStudent(string au_id)
        //{
        //    var response = client.GetStreamAsync("https://localhost:44323/Student/" + au_id);
        //    Student student = await System.Text.Json.JsonSerializer.DeserializeAsync<Student>(await response);
        //    return student;
        //}

        public static async Task<string> PostStudent(Student student)
        {
            var postContent = GetSerializedEncodedStudent(student);
            
            var resp = await PostContentToPlanAUapi<HttpContent>(postContent);

            return resp.StatusCode.ToString();
        }

        private static HttpContent GetSerializedEncodedStudent(Student s)
        {
            var json = System.Text.Json.JsonSerializer.Serialize<Student>(s);
            return new StringContent(json, Encoding.UTF8, MediaType) as HttpContent;
        }

        private static async Task<HttpResponseMessage> PostContentToPlanAUapi<T>(HttpContent content)
        {
            return await Client.PostAsync(RequestUri, content);
        }
    }
}
