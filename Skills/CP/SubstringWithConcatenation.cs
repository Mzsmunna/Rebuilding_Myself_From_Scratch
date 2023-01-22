using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    public static class SubstringWithConcatenation
    {
        public static List<int> FindSubstring(string s, string[] words)
        {
            //string s = "barfoothefoobarman";
            //string[] words = new string[] { "foo", "bar" };

            //string s = "foobarfoobar";
            //string[] words = new string[] { "foo", "bar" };

            //string s = "barfoofoobarthefoobarman";
            //string[] words = new string[] { "bar", "foo", "the" };

            //string s = "lingmindraboofooowingdingbarrwingmonkeypoundcake";
            //string[] words = new string[] { "fooo", "barr", "wing", "ding", "wing" };

            //string s = "wordgoodgoodgoodbestword";
            //string[] words = new string[] { "word", "good", "best", "word" };

            //string s = "wordgoodgoodbestwordgood"; //"wordgoodgoodgoodbestword";
            //string[] words = new string[] { "word", "good", "best", "good" };

            //string s = "wordgoodgoodgoodbestwordgoodgoodgoodbest";
            //string[] words = new string[] { "good", "word", "good", "best", "good" };

            //string s = "aaa";
            //string[] words = new string[] { "a", "a" };

            //string s = "aaaaaaaaaaaaaa";
            //string[] words = new string[] { "aa", "aa" };

            //string s = "ababababababab";
            //string[] words = new string[] { "ab", "ab" };

            //string s = "cccbcacaa";
            //string[] words = new string[] { "cc", "bc" };

            var tempString = s;
            var tempWord = string.Empty;
            var wordlength = 0;

            List<string> allWords = new List<string>();
            List<string> allDistinctWords = new List<string>();
            List<string> allPossibleWordsWithIndex = new List<string>();
            List<int> allResults = new List<int>();

            allDistinctWords = words.ToList().Distinct().ToList();

            wordlength = words[0].Length;
            tempString = s;
            var takeUntil = 0;
            var wordStartIndex = 0;
            var sIndex = 0;

            while (tempString.Length >= takeUntil && sIndex < s.Length)
            {
                takeUntil = (wordlength * words.Length);

                if (tempString.Length >= takeUntil)
                {
                    tempWord = tempString.Substring(0, takeUntil);
                    wordStartIndex = sIndex;
                    allPossibleWordsWithIndex.Add(tempWord + wordStartIndex);
                }

                sIndex++;
                tempString = tempString.Substring(1);
            }

            foreach (string currentSentence in allPossibleWordsWithIndex)
            {
                var isWordMatching = false;
                var mergedWord = string.Empty;

                allWords = words.ToList();

                var index = currentSentence.Substring(wordlength * words.Length);
                tempString = currentSentence.Substring(0, wordlength * words.Length);

                var result = Convert.ToInt32(index);

                for (int i = 0; i < words.Length; i++)
                {
                    var currentWord = tempString.Substring(0, words[i].Length);

                    if (allWords.Contains(currentWord))
                    {
                        mergedWord += currentWord;
                        isWordMatching = true;
                        allWords.Remove(currentWord);
                    }
                    else
                    {
                        isWordMatching = false;
                        break;
                    }

                    tempString = tempString.Substring(tempString.IndexOf(currentWord) + currentWord.Length);
                }

                if (isWordMatching && result >= 0)
                {
                    if (!allResults.Contains(result))
                        allResults.Add(result);
                }
            }

            allResults = allResults.OrderBy(x => x).ToList();

            return allResults;
        }
    }
}
