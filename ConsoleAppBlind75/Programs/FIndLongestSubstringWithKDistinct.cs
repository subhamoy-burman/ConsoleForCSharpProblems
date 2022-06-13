using System;
using System.Collections.Generic;

namespace ConsoleAppBlind75
{
    public class FindLongestSubstringWithKDistinct
    {
        public int Execute(char[] arr, int k)
        {
            int windowStart = 0;
            int windowEnd = 0;

            int globalMaxLength = 0;
            Dictionary<char, int> characterMap = new Dictionary<char, int>();

            for (windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                if (characterMap.ContainsKey(arr[windowEnd]))
                {
                    characterMap[arr[windowEnd]] += 1;
                }
                else
                {
                    characterMap.Add(arr[windowEnd], 1);
                }

                while (characterMap.Count>k)
                {

                    char leftChar = arr[windowStart];
                    if (characterMap.ContainsKey(leftChar))
                    {
                        characterMap[leftChar] -= 1;
                    }
                    if(characterMap[leftChar] == 0)
                    {
                        characterMap.Remove(arr[windowStart]);
                    }

                    windowStart++;
                }
                globalMaxLength = Math.Max(globalMaxLength, windowEnd - windowStart + 1);

            }

            return globalMaxLength;
        }
    }
}