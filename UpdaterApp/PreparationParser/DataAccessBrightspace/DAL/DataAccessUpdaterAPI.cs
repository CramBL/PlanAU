using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DataAccessBrightspace.Models;

namespace DataAccessBrightspace.DAL
{
    class DataAccessUpdaterAPI
    {
        private readonly HttpClient Client;

        private readonly string localHost;
        private readonly Uri PutCourseUri;
        private readonly string MediaType;

        public DataAccessUpdaterAPI()
        {
            Client = new HttpClient();
            localHost = "https://localhost:44372";
            PutCourseUri = new Uri(localHost + "/Course");
            MediaType = "application/json";
        }

        public async Task<HttpResponseMessage> PutCourse(ICourse course)
        {
            var json = System.Text.Json.JsonSerializer.Serialize<Course>((Course)course);
            using var postContent = new StringContent(json, Encoding.UTF8, MediaType);

            var resp = await Client.PutAsync(PutCourseUri, postContent);

            return resp;
        }
    }
}
