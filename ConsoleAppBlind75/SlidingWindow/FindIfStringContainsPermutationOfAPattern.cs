using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace ConsoleAppBlind75
{
    public class FindIfStringContainsPermutationOfAPattern
    {
        public bool Execute(string inputString, string pattern)
        {
            Dictionary<char, int> patternDictionary = new Dictionary<char, int>();
            Dictionary<char, int> patternDictionaryCopy = new Dictionary<char, int>();

            var inputCharArray = inputString.ToCharArray();
            var patternCharArray = pattern.ToCharArray();

            var windowStart = 0;
            var windowEnd = 0;
            
            
            
            // Create the window for pattern string
            for (int i = 0; i < pattern.Length; i++)
            {
                var currentChar = patternCharArray[i];
                if (patternDictionary.ContainsKey(currentChar))
                {
                    patternDictionary[currentChar] = patternDictionary[currentChar] + 1;
                    patternDictionaryCopy[currentChar] = patternDictionaryCopy[currentChar] + 1;
                }
                else
                {
                    patternDictionary.Add(currentChar,1);
                    patternDictionaryCopy.Add(currentChar,1);
                }
            }

            // Dictionary<char, int> patternDictionaryCopy = new Dictionary<char, int>();
            // patternDictionaryCopy = patternDictionary;
            //
            int numberOfMatches = 0;
            while (windowEnd<inputCharArray.Length)
            {
                if (patternDictionary.ContainsKey(inputCharArray[windowEnd]) && patternDictionary[inputCharArray[windowEnd]]>0)
                {
                    patternDictionary[inputCharArray[windowEnd]] -= 1;
                    numberOfMatches++;
                    windowEnd++;
                }
                else
                {
                    windowStart++;
                    windowEnd = windowStart;
                    numberOfMatches = 0;
                    patternDictionary.Clear();
                    foreach (var key in patternDictionaryCopy.Keys)
                    {
                        patternDictionary.Add(key, patternDictionaryCopy[key]);
                    }

                    continue;
                }

                if (numberOfMatches == pattern.Length)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Execute2(string pattern, string inputString)
        {
            int len1 = pattern.Length, len2 = inputString.Length;
            if (len1 > len2) return false;
        
            int[] count = new int[26];
            for (int i = 0; i < len1; i++) {
                count[pattern[i] - 'a']++;
                //count[inputString[i] - 'a']--;
            }
            if (allZero(count)) return true;
        
            for (int i = 0; i < len2; i++) {
                count[inputString[i] - 'a']--;
                if (allZero(count)) return true;
            }
        
            return false;
        }
        
        private bool allZero(int[] count) {
            for (int i = 0; i < 26; i++) {
                if (count[i] != 0) return false;
            }
            return true;
        }

        public bool Execute3(string inputString, string pattern)
        {
            int windowStart = 0, matched = 0;
            Dictionary<char, int> charDictionaryMap = new Dictionary<char, int>();

            foreach (var charVar in pattern.ToCharArray())
            {
                if (!charDictionaryMap.ContainsKey(charVar))
                {
                    charDictionaryMap.Add(charVar, 1);
                }
                else
                {
                    charDictionaryMap[charVar] += 1;
                }
            }

            for (int windowEnd = 0; windowEnd < inputString.Length; windowEnd++)
            {
                char rightChar = inputString[windowEnd];
                if (charDictionaryMap.ContainsKey(rightChar))
                {
                    charDictionaryMap[rightChar] -= 1;
                    if (charDictionaryMap[rightChar] == 0)
                    {
                        matched++;
                    }
                }

                if (matched == charDictionaryMap.Count)
                {
                    return true;
                }

                if (windowEnd >= pattern.Length - 1)
                {
                    char leftChar = inputString[windowStart++];

                    if (charDictionaryMap.ContainsKey(leftChar))
                    {
                        if (charDictionaryMap[leftChar] == 0)
                        {
                            matched--;
                        }
                        charDictionaryMap[leftChar] += 1;

                    }
                }
            }
            return false;
        }
        
        
    }
}