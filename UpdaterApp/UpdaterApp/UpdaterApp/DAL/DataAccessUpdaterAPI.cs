using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UpdaterApp.Models;

namespace UpdaterApp.DAL
{
    class DataAccessUpdaterAPI
    {
        private readonly HttpClient Client;

        private readonly string localHost;
        private readonly Uri CourseUri;
        private readonly string MediaType;

        public DataAccessUpdaterAPI()
        {
            Client = new HttpClient();
            localHost = "https://localhost:44372";
            CourseUri = new Uri(localHost + "/Course");
            MediaType = "application/json";
        }

        public async Task<HttpResponseMessage> PutCourse(ICourse course)
        {
            using var postContent = SerializeCourseToJson(course);

            var resp = await Client.PutAsync(CourseUri, postContent);

            return resp;
        }

        public async Task<HttpResponseMessage> PostCourse(ICourse course)
        {
            using var postContent = SerializeCourseToJson(course);

            var resp = await Client.PostAsync(CourseUri, postContent);

            return resp;
        }

        public async Task<Course> GetCourse(string courseName)
        {
            Uri GetUri = new Uri($"{CourseUri.AbsoluteUri}/" + courseName);
            var response = await Client.GetAsync(GetUri);
            if (response.StatusCode == HttpStatusCode.NotFound) return null;
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            Course course = JsonSerializer.Deserialize<Course>(await response.Content.ReadAsStringAsync());
            return course;
        }

        public StringContent SerializeCourseToJson(ICourse course)
        {
            var json = JsonSerializer.Serialize<Course>((Course)course);
            return new StringContent(json, Encoding.UTF8, MediaType);
        }
    }
}
