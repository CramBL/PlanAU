using System;
using System.Net;
using UpdaterApp.DAL;
using UpdaterApp.Models;

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

            Console.WriteLine("Prep 1: " + SoftwareDesignCourse.Lectures[0].PreparationItems[0].ToString());

            Course doesCourseExist = updaterApi.GetCourse(SoftwareDesignCourse.Name).Result;

            if (doesCourseExist != null)
            {
                SoftwareDesignCourse.Id = doesCourseExist.Id;
                var response = await updaterApi.PutCourse(SoftwareDesignCourse);
                Console.WriteLine("SWD was put with status code: " + response.StatusCode.ToString());
            }
            else
            {
                var response = await updaterApi.PostCourse(SoftwareDesignCourse);
                Console.WriteLine("SWD was posted with status code: " + response.StatusCode.ToString());
            }

        }
    }
}
