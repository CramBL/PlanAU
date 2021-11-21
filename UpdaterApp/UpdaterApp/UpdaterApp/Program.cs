using System;
using UpdaterApp.DAL;

namespace UpdaterApp
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var DataAccess = new DAL.DataAccessBrightspace();
            
            var cookies = DataAccess.GetSessionCookies();

            cookies.Wait();

            var responseString = DataAccess.GetModuleTableOfContent();

            responseString.Wait();
            

            var Parser = new PreparationTextParser();
            
            var preparationDictionary = Parser.ParseModuleTableOfContents(responseString.Result);
            
            
            foreach (var Item in preparationDictionary)
            {
                foreach (var value in Item.Value)
                {
                    Console.WriteLine("=======================================================");
                    Console.WriteLine(value);
                }
                
            }

            var courseFormatter = new CourseFormatter();

            var SoftwareDesignCourse = courseFormatter.DictionaryToCourseObject("SWD", preparationDictionary);

            var updaterApi = new DataAccessUpdaterAPI();

            var response = await updaterApi.PutCourse(SoftwareDesignCourse);

            Console.WriteLine(response.Content.ToString());


        }
    }
}
