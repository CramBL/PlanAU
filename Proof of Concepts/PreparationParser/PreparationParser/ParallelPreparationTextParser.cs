using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PreparationParser
{
    class ParallelPreparationTextParser
    {
        
        private string _keywordPatternPrefix = "(?=";//evt optimer med ^ og uden lookahead?
        private const string _keywordPatternSuffix = ").*";
        public string RegExPattern { get; set; }

        private string TableOfContentPattern = @"(?=(ModuleId))";

        //standard keywords indicating an act of preparation expected of the student e.g. watch/read
        public List<string> PreparationKeywordsList { get; set; } = new List<string>()
        {
            "watch ", "read ", "look at"
        };

		//Denne liste kunne matches som en alternativ word group, evt. positive lookahead på "://" eller lignende.
        //standard keywords indicating content to be watched/read/etc.
        public List<string> ReferencedContentList { get; set; } = new List<string>()
        {
            "link", "video"
        };


        public ParallelPreparationTextParser()
        {
            RegExPattern = BuildKeywordPattern(PreparationKeywordsList, ReferencedContentList);
        }

        public string BuildKeywordPattern(List<string> preparationList, List<string> contentList)
        {

            _keywordPatternPrefix += string.Join('|', preparationList) 
                                     + '|' 
                                     + string.Join('|', contentList);

            return _keywordPatternPrefix + _keywordPatternSuffix;
        }

        public List<string> ParseText(string preparationText)
        {
            List<string> preparationItemList = new();

            //find all matches with keywords in preparation text
            var matches = Regex.Matches(preparationText, RegExPattern, RegexOptions.IgnoreCase);

            /*
             [if] Separate all matches that are activities e.g. "read this"/"watch this"
             [else if] Append all links/video descriptions to the activity preceding it     
            */
            foreach (var match in matches)
            {
                if (PreparationKeywordsList.Any(PreparationKeywordsList => match
                        .ToString().Contains(PreparationKeywordsList, StringComparison.OrdinalIgnoreCase)))//Ordinal is faster (culture is irrelevant)
                    preparationItemList.Add(match.ToString());
                else if (ReferencedContentList.Any(ReferencedContentList => match
                    .ToString().Contains(ReferencedContentList, StringComparison.OrdinalIgnoreCase)))
                    preparationItemList[^1] += "\n"+match;
            }

            return preparationItemList;
        }

        
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

            List<string> contentMatchesList  = new List<string>();
            List<string> activityMatchesList  = new();

            Parallel.Invoke(
                () =>
                    {
                        contentMatchesList  = CollectContentMatches(moduleDescription);
                    }, 
                () =>
                    {
                        activityMatchesList = CollectActivityMatches(moduleDescription);
                    }
                        );


            //var contentMatchesList = CollectContentMatches(moduleDescription);

            //var activityMatchesList = CollectActivityMatches(moduleDescription);

            activityMatchesList = ReplaceEmbeddedWithRealLinks(activityMatchesList, contentMatchesList);

            activityMatchesList = CleanUpSymbolsAndHtml(activityMatchesList);


            return activityMatchesList;
        }

        private List<string> CleanUpSymbolsAndHtml(List<string> activityMatchesList)
        {

            Parallel.For(0, activityMatchesList.Count, i =>
            {
                activityMatchesList[i] =
                    Regex.Replace(activityMatchesList[i], "(\\\\)|(\\\"\\>).+?(<\\/a>)", string.Empty);

            });



            //for (int i = 0; i < activityMatchesList.Count; i++)
            //{
            //    activityMatchesList[i] = Regex.Replace(activityMatchesList[i], "(\\\\)|(\\\"\\>).+?(<\\/a>)", string.Empty);
            //}

            return activityMatchesList;
        }

        private List<string> ReplaceEmbeddedWithRealLinks(List<string> activityMatchesList, List<string> contentMatchesList)
        {
            
            Parallel.For(0, activityMatchesList.Count, i =>
            {
                int index = contentMatchesList.FindIndex(c => c.Contains(activityMatchesList[i]));
                if (index != -1)
                    activityMatchesList[i] = contentMatchesList[index];
            });

            //for (int i = 0; i < activityMatchesList.Count; i++)
            //{
            //    int index = contentMatchesList.FindIndex(c => c.Contains(activityMatchesList[i]));
            //    if (index != -1)
            //        activityMatchesList[i] = contentMatchesList[index];
            //}

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
