using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

namespace PreparationParser
{
    class PreparationTextParser
    {
        private string _keywordPatternPrefix = "(?=";
        private const string _keywordPatternSuffix = ").*";
        public string RegExPattern { get; set; }

        //standard keywords indicating an act of preparation expected of the student e.g. watch/read
        public List<string> PreparationKeywordsList { get; set; } = new List<string>()
        {
            "watch ", "read ", "look at"
        };

        //standard keywords indicating content to be watched/read/etc.
        public List<string> ReferencedContentList { get; set; } = new List<string>()
        {
            "link", "video"
        };


        public PreparationTextParser()
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


    }
}
