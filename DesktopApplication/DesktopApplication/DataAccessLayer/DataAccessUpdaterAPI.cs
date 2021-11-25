using Desktop_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesktopApplication.DAL
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
            localHost = "https://localhost:44323";
            CourseUri = new Uri(localHost + "/Course");
            MediaType = "application/json";
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
    }
}
