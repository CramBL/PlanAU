using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading;
using Desktop_Application.Models;
using PreparationParser;

namespace DataAccessBrightspace
{
    class Program
    {
        static void Main(string[] args)
        {
            var DataAccess = new DataAccessBrightspace();

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            var cookies = DataAccess.GetSessionCookies();

            cookies.Wait();

            var responseString = DataAccess.GetModuleTableOfContent();

            responseString.Wait();

            watch.Stop();
            Console.WriteLine($"Execution time for http response: {watch.ElapsedMilliseconds}");

            //foreach (var cookie in cookies.Result)
            //{
            //    Console.WriteLine($"{cookie.Value}");
            //}
            //Console.WriteLine(responseString.Result);

            var Parser = new PreparationTextParser();

            watch.Reset();
            watch.Start();

            var prepItems = Parser.ParseModuleTableOfContents(responseString.Result);
            
            watch.Stop();
            
            Console.WriteLine($"Execution time for parsing: {watch.ElapsedMilliseconds}");

            foreach (var Item in prepItems)
            {
                foreach (var value in Item.Value)
                {
                    Console.WriteLine("=======================================================");
                    Console.WriteLine(value);
                }
                
            }

            var SoftwareDesignCourse = new Course("SWD", new List<ILecture>());


            foreach (var item in prepItems)
            {
                var lecturePrepItemsList = new List<string>();
                SoftwareDesignCourse.Lectures.Add(new Lecture(item.Key.ToString(), lecturePrepItemsList));
                foreach (var value in item.Value)
                {
                    SoftwareDesignCourse.Lectures[item.Key].PreparationDescription.Add(value);
                }
            }

            //int lol =SoftwareDesignCourse.Lectures.Count;
            
        }
    }
}
