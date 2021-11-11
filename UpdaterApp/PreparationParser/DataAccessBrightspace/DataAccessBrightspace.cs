using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessBrightspace
{
    public interface IDataAccessBrightspace
    {

    }
    class DataAccessBrightspace : IDataAccessBrightspace
    {
        private readonly HttpClient Client;
        private HttpClientHandler ClientHandler = new();

        private readonly string Host;
        private readonly Uri loginUri;
        private readonly Uri ModuleToCUri;
        private readonly string MediaType;

        public FormUrlEncodedContent Requestbody { get; private set; } = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string?, string?>("d2lreferrer", ""),
            new KeyValuePair<string?, string?>("noredirect", "1"),
            new KeyValuePair<string?, string?>("loginPath", "/d2l/login"),
            new KeyValuePair<string?, string?>("userName", "apiuser.jrt"),
            new KeyValuePair<string?, string?>("password", "Jesper12345!")
        });

        public DataAccessBrightspace()
        {
            ClientHandler.CookieContainer = new();
            Client = new HttpClient(ClientHandler);
            Host = "https://testaarhus.brightspace.com/d2l/";
            loginUri = new Uri(Host + "lp/auth/login/login.d2l");
            ModuleToCUri = new Uri(Host + "api/le/1.23/11056/content/toc");
            //MediaType = "application/json";
        }

        public async Task<IEnumerable<Cookie>> GetSessionCookies()
        {
            var response = await Client.PostAsync(Host + "lp/auth/login/login.d2l",  Requestbody);
            
            var cookies = ClientHandler.CookieContainer.GetCookies(loginUri).Cast<Cookie>();
            
            return cookies;
        }

        public async Task<string> GetModuleTableOfContent()
        {
            string ModuleJsonString = null;

            var response = await Client.GetAsync(ModuleToCUri);

            if (response.StatusCode == HttpStatusCode.OK)
                ModuleJsonString = await response.Content.ReadAsStringAsync();

            return ModuleJsonString;
        }


        //public async Task<Student> LoginAttemptAuthorize(Student student)
        //{

        //    using var postContent = GetSerializedEncodedStudent(student);

        //    var response = await PostContentToPlanAUapi<HttpContent>(AuthorizeUri, postContent);

        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //        return GetDeserializedEncodedStudent(await response.Content.ReadAsStringAsync());
        //    else
        //        return null;
        //}
        

        //private HttpContent GetSerializedEncodedStudent(Student s)
        //{
        //    var json = System.Text.Json.JsonSerializer.Serialize<Student>(s);
        //    return new StringContent(json, Encoding.UTF8, MediaType) as HttpContent;
        //}

        private async Task<HttpResponseMessage> PostContent<T>(Uri endpoint, HttpContent content)
        {
            return await Client.PostAsync(endpoint, content);
        }
    }
}
