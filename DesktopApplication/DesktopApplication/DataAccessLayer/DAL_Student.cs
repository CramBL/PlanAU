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
        private readonly HttpClient Client;

        private readonly string localHost;
        private readonly string AuthorizeUri;
        private readonly string StudentUri;
        private readonly string MediaType;

        public DAL_Student()
        {
            Client = new HttpClient();
            localHost = "https://localhost:44323";
            AuthorizeUri = localHost + "/authorize";
            StudentUri = localHost + "/Student";
            MediaType = "application/json";
        }

        public async Task<Student> LoginAttemptAuthorize(Student student)
        {

            var postContent = GetSerializedEncodedStudent(student);

            var response = await PostContentToPlanAUapi<HttpContent>(AuthorizeUri, postContent);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return GetDeserializedEncodedStudent(await response.Content.ReadAsStringAsync());
            else
                return null;
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            var putContent = GetSerializedEncodedStudent(student);

            var response = await Client.PutAsync(StudentUri, putContent);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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

        public async Task<string> PostStudent(Student student)
        {
            var postContent = GetSerializedEncodedStudent(student);
            
            var resp = await PostContentToPlanAUapi<HttpContent>(StudentUri, postContent);

            return resp.StatusCode.ToString();
        }

        private Student GetDeserializedEncodedStudent(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<Student>(json);
        }

        private HttpContent GetSerializedEncodedStudent(Student s)
        {
            var json = System.Text.Json.JsonSerializer.Serialize<Student>(s);
            return new StringContent(json, Encoding.UTF8, MediaType) as HttpContent;
        }

        private async Task<HttpResponseMessage> PostContentToPlanAUapi<T>(string endpoint, HttpContent content)
        {
            return await Client.PostAsync(endpoint, content);
        }
    }
}
