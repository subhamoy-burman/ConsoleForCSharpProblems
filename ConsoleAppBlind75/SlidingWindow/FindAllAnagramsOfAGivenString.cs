using System.Collections.Generic;

namespace ConsoleAppBlind75
{
    public class FindAllAnagramsOfAGivenString
    {
        public int Execute(string sourceString, string patternString)
        {
            Dictionary<char, int> sourceMap = new Dictionary<char, int>();
            Dictionary<char, int> patternMap = new Dictionary<char, int>();

            if(patternString.Length>sourceString.Length)
            {
                return 0;
            }
            int matchCount = 0;
            
            foreach (var item in patternString.ToCharArray())
            {
                if (!patternMap.ContainsKey(item))
                {
                    patternMap.Add(item,1);
                }
                else
                {
                    patternMap[item] += 1;
                }
            }

            for (int i = 0; i < patternString.Length; i++)
            {
                if (!sourceMap.ContainsKey(sourceString[i]))
                {
                    sourceMap.Add(sourceString[i],1);
                }
                else
                {
                    sourceMap[sourceString[i]] += 1;
                }
            }

            if (AreDictionariesHavingSameElementMap(sourceMap, patternMap))
            {
                matchCount++;
            }
            int windowStart = 1;
            while (windowStart + patternString.Length - 1 < sourceString.Length)
            {
                int windowEnd = windowStart + patternString.Length - 1;
                if (sourceMap.ContainsKey(sourceString[windowEnd]))
                {
                    sourceMap[sourceString[windowEnd]]++;
                }
                else
                {
                    sourceMap.Add(sourceString[windowEnd],1);
                }
                
                if (sourceMap.ContainsKey(sourceString[windowStart - 1]))
                {
                    sourceMap[sourceString[windowStart - 1]]--;
                    if (sourceMap[sourceString[windowStart - 1]] <= 0)
                    {
                        sourceMap.Remove(sourceString[windowStart - 1]);
                    }
                }

                if (AreDictionariesHavingSameElementMap(sourceMap, patternMap))
                {
                    matchCount++;
                }

                windowStart++;
            }   
            
            return matchCount;
        }

        private bool AreDictionariesHavingSameElementMap(Dictionary<char, int> sourceDict,
            Dictionary<char, int> refDict)
        {
            if (sourceDict.Count != refDict.Count)
            {
                return false;
            }

            foreach (var item in sourceDict)
            {
                if(refDict.ContainsKey(item.Key))
                {
                    if (refDict[item.Key].Equals(sourceDict[item.Key]))
                    {
                        continue;
                    }
                    return false;
                }
                return false;
            }

            return true;
        }
    }
}