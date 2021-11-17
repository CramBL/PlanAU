using System;
using System.Net.Http.Headers;
using PreparationParser;

namespace DataAccessBrightspace
{
    class Program
    {
        static void Main(string[] args)
        {
            var DataAccess = new DataAccessBrightspace();

            var cookies = DataAccess.GetSessionCookies();
            
            foreach (var cookie in cookies.Result)
            {
                Console.WriteLine($"{cookie.Value}");
            }

            var responseString = DataAccess.GetModuleTableOfContent();

            Console.WriteLine(responseString.Result);

            var prepParser = new PreparationTextParser();

            

            var prepItems = prepParser.ParseModuleTableOfContents(responseString.Result);

            foreach (var prepItem in prepItems)
            {
                Console.WriteLine("=======================================================");
                Console.WriteLine(prepItem);
            }

        }
    }
}
