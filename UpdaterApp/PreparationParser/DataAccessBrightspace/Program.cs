using System;
using System.Collections.Generic;
using DataAccessBrightspace.Models;
using PreparationParser;

namespace DataAccessBrightspace
{
    class Program
    {
        static void Main(string[] args)
        {
            var DataAccess = new DAL.DataAccessBrightspace();

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

            var preparationDictionary = Parser.ParseModuleTableOfContents(responseString.Result);
            
            watch.Stop();
            
            Console.WriteLine($"Execution time for parsing: {watch.ElapsedMilliseconds}");

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


            
            int lol = SoftwareDesignCourse.Lectures.Count;
            
        }
    }
}
