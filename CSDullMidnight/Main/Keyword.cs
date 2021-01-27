using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace CSDullMidnight.Main
{
    class Keyword
    {
        static string wordPattern = "[^\\W\\d](\\w|[-']{1,2}(?=\\w))*";
        Regex wordRx = new Regex(wordPattern);
        List<string> keywords = new List<string> {"start","end", "var", "void"};
        public List<string> RegexIt(string code)
        {
            List<string> words = new List<string>();
            MatchCollection wordMatches = wordRx.Matches(code);
            for (int i = 0; i < wordMatches.Count; i++)
            {
                words.Add(wordMatches[i].ToString());
            }
            return words;
        }
        public List<string> CollectKeywords(List<string> words)
        {
            List<string> kwd = new List<string>();
            for(int i = 0; i<words.Count; i++)
            {
                if (keywords.Contains(words[i]))
                {
                    kwd.Add(words[i]);
                }
            }
            return kwd;
        }
    }
}
