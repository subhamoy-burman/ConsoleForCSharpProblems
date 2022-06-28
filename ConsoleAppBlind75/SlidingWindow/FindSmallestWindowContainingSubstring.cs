using System;
using System.Collections.Generic;

namespace ConsoleAppBlind75
{
    public static class FindSmallestWindowContainingSubstring
    {
        public static string Execute(string sourceString, string patternString)
        {
            Dictionary<char, int> sourceMap = new Dictionary<char, int>();
            Dictionary<char, int> patternMap = new Dictionary<char, int>();
            int desiredMatchCount = patternString.Length;
            int matchCount = 0;
            int i = -1;
            int j = -1;
            string ans = "";

            if (patternString.Length > sourceString.Length)
            {
                return "";
            }

            foreach (var item in patternString.ToCharArray())
            {
                if (!patternMap.ContainsKey(item))
                {
                    patternMap.Add(item, 1);
                }
                else
                {
                    patternMap[item] += 1;
                }
            }

            while (true)
            {
                bool flag1 = false;
                bool flag2 = false;
                if (i < sourceString.Length - 1 && matchCount < desiredMatchCount)
                {
                    i++;
                    char ch = sourceString[i];

                    if (sourceMap.ContainsKey(ch))
                    {
                        sourceMap[ch]++;
                    }
                    else
                    {
                        sourceMap.Add(ch, 1);
                    }

                    if (patternMap.ContainsKey(ch))
                    {
                        if (sourceMap[ch] <= patternMap[ch])
                        {
                            matchCount++;
                        }
                    }

                    flag1 = true;
                }

                // Collect answers and release
                while (j < i && matchCount == desiredMatchCount)
                {
                    string potentialAnswer = sourceString.Substring(j + 1, i + 1);

                    if (ans.Length == 0 || potentialAnswer.Length < ans.Length)
                    {
                        ans = potentialAnswer;
                    }

                    j++;
                    // Release and decrease frequency
                    char ch = sourceString[j];
                    if (sourceMap.ContainsKey(ch))
                    {
                        if (sourceMap[ch] == 1)
                        {
                            sourceMap.Remove(ch);
                        }
                        else
                        {
                            sourceMap[ch]--;
                        }
                    }

                    if (sourceMap.GetValueOrDefault(ch,0) < patternMap.GetValueOrDefault(ch,0))
                    {
                        matchCount--;
                    }

                    flag2 = true;
                }

                if (flag1 == false && flag2 == false)
                {
                    break;
                }

            }
            return ans;
        }
        
        public static TValue GetValueOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue defaultValue)
        {
            return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
        }
    }
    
    
}