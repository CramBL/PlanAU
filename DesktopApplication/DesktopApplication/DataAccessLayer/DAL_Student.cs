﻿using System;
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
    public interface IDAL_Student
    {
        Task<Student> LoginAttemptAuthorize(Student student);
        Task<bool> UpdateStudent(Student student);

    }
    public class DAL_Student : IDAL_Student
    {
        private readonly HttpClient Client;

        private readonly Uri localHost;
        private readonly Uri AuthorizeUri;
        private readonly Uri StudentUri;
        private readonly string MediaType;

        public DAL_Student()
        {
            Client = new HttpClient();
            localHost = new Uri("https://localhost:44323");
            AuthorizeUri = new Uri (localHost + "/authorize");
            StudentUri = new Uri(localHost + "/Student");
            MediaType = "application/json";
        }

        public async Task<Student> LoginAttemptAuthorize(Student student)
        {

            using var postContent = GetSerializedEncodedStudent(student);

            var response = await PostContentToPlanAUapi<HttpContent>(AuthorizeUri, postContent);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return GetDeserializedEncodedStudent(await response.Content.ReadAsStringAsync());
            else
                return null;
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            using var putContent = GetSerializedEncodedStudent(student);

#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
            var response = await Client.PutAsync(StudentUri, putContent);
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
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
            using var postContent = GetSerializedEncodedStudent(student);

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

        private async Task<HttpResponseMessage> PostContentToPlanAUapi<T>(Uri endpoint, HttpContent content)
        {
            return await Client.PostAsync(endpoint, content);
        }
    }
}
