using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UpdaterApp
{
    class PreparationTextParser
    {
        
        public Dictionary<int, List<string>> ParseModuleTableOfContents(string RawTableOfContents)
        {

            var moduleDescriptionList = SplitToCintoModules(RawTableOfContents);


            return ExtractLecturePreparationItems(moduleDescriptionList);
        }

        public List<string> SplitToCintoModules(string RawTableOfContents)
        {
            var ListOfModules =
                Regex.Split(RawTableOfContents, @"(?=(ModuleId))")
                    .Where(i =>
                        !string.IsNullOrEmpty(i)
                        && i.Contains("ModuleId\"")).ToList();// "ModuleId\"" identifies the individual module JSON-objects

            List<string> moduleDescriptionList = 
                ListOfModules.Select(module => 
                    Regex.Matches(
                        module, 
                        @"(Description\"":).+?}", 
                        RegexOptions.IgnoreCase)
                        .FirstOrDefault()?
                        .ToString())
                    .ToList();

            return moduleDescriptionList;
        }

        private Dictionary<int, List<string>> ExtractLecturePreparationItems(List<string> moduleDescriptionList)
        {

            Dictionary<int, List<string>> moduleDictionary = new();

            int moduleNo = 0;
            foreach (var moduleDescription in moduleDescriptionList)
            {
                moduleDictionary.Add(moduleNo++, CollectDescriptionItems(moduleDescription));
            }

            return moduleDictionary;
        }

        private List<string> CollectDescriptionItems(string moduleDescription)
        {


            var contentMatchesList = CollectContentMatches(moduleDescription);

            var activityMatchesList = CollectActivityMatches(moduleDescription);

            activityMatchesList = ReplaceEmbeddedWithRealLinks(activityMatchesList, contentMatchesList);

            activityMatchesList = CleanUpSymbolsAndHtml(activityMatchesList);


            return activityMatchesList;
        }

        private List<string> CleanUpSymbolsAndHtml(List<string> activityMatchesList)
        {
            for (int i = 0; i < activityMatchesList.Count; i++)
            {
                activityMatchesList[i] = Regex.Replace(activityMatchesList[i], "(\\\\)|(\\\"\\>).+?(<\\/a>)", string.Empty);
            }

            return activityMatchesList;
        }

        private List<string> ReplaceEmbeddedWithRealLinks(List<string> activityMatchesList, List<string> contentMatchesList)
        {
            for (int i = 0; i < activityMatchesList.Count; i++)
            {
                int index = contentMatchesList.FindIndex(c => c.Contains(activityMatchesList[i]));
                if (index != -1)
                    activityMatchesList[i] = contentMatchesList[index];
            }

            return activityMatchesList;
        }

        private List<string> CollectActivityMatches(string moduleDescription)
        {
            string moduleTextPart = Regex.Split(moduleDescription, @"(?=(Html\"":))")
                .Where(i =>
                    !string.IsNullOrEmpty(i)
                    && i.Contains(@"""Text"":"))
                .ToList()
                .FirstOrDefault();

            if (moduleTextPart != null)
            {
                var activityMatchesList = Regex.Matches(moduleTextPart, @"(optional|watch |read |link).+?(?=(link|\\n))", RegexOptions.IgnoreCase)
                    .Select(m=>m.Value)
                    .Where(s => 
                        !s.Contains("optional", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                return activityMatchesList;
            }
            return null;
            
        }

        private List<string> CollectContentMatches(string moduleDescription)
        {
            string moduleHtmlPart = Regex.Split(moduleDescription, @"(?=(Html\"":))")
                .Where(i =>
                    !string.IsNullOrEmpty(i)
                    && i.Contains(@"Html"":"))
                .ToList()[^1];
            
            var contentMatchesList  = Regex.Matches(moduleHtmlPart, @"(http:|https:).+?(<\/a>)", RegexOptions.IgnoreCase)
                .Select(m=>m.Value)
                .ToList();
            
            return contentMatchesList;
        }
    }
}
