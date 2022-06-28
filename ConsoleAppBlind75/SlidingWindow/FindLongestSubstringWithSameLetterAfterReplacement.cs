using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppBlind75
{
    public class FindLongestSubstringWithSameLetterAfterReplacement
    {
        public int Execute(char[] arr, int k)
        {
            int windowStart = 0;
            int maxLength = 0;
            int substitutionSoFar = 0;

            Dictionary<char, int> subStringSofar = new Dictionary<char, int> {{arr[windowStart], windowStart}};
            for (int windowEnd = 1; windowEnd <= arr.Length; windowEnd++)
            {
                if (windowEnd<arr.Length && subStringSofar.ContainsKey(arr[windowEnd]))
                {
                    subStringSofar[arr[windowStart]] += 1;
                }
                else
                {
                    if (substitutionSoFar >= k)
                    {
                        subStringSofar.Clear();
                        maxLength = Math.Max(maxLength, windowEnd - windowStart);
                        substitutionSoFar = 0;
                        windowStart++;
                        windowEnd = windowStart;
                        subStringSofar.Add(arr[windowStart],windowEnd);
                        continue;
                    }
                    subStringSofar[arr[windowStart]] = windowEnd;
                    substitutionSoFar++;
                }
            }

            return maxLength;
        }
    }
}