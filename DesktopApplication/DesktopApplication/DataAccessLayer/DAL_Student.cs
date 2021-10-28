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

        private static readonly string localHost = "https://localhost:44323";
        private static readonly string AuthorizeUri = localHost + "/authorize";
        private static readonly string StudentUri = localHost + "/Student";
        private static readonly string MediaType = "application/json";

        public static async Task<Student> LoginAttemptAuthorize(Student student)
        {

            var postContent = GetSerializedEncodedStudent(student);

            var response = await PostContentToPlanAUapi<HttpContent>(AuthorizeUri, postContent);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return GetDeserializedEncodedStudent(await response.Content.ReadAsStringAsync());
            else
                return null;
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
            
            var resp = await PostContentToPlanAUapi<HttpContent>(StudentUri, postContent);

            return resp.StatusCode.ToString();
        }

        private static Student GetDeserializedEncodedStudent(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<Student>(json);
        }

        private static HttpContent GetSerializedEncodedStudent(Student s)
        {
            var json = System.Text.Json.JsonSerializer.Serialize<Student>(s);
            return new StringContent(json, Encoding.UTF8, MediaType) as HttpContent;
        }

        private static async Task<HttpResponseMessage> PostContentToPlanAUapi<T>(string endpoint, HttpContent content)
        {
            return await Client.PostAsync(endpoint, content);
        }
    }
}
