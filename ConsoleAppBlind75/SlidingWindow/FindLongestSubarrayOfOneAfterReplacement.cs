using System;
using System.Collections.Generic;

namespace ConsoleAppBlind75
{
    public class FindLongestSubarrayOfOneAfterReplacement
    {
        public int Execute(int[] arr, int k)
        {
             int windowStart = 0;
             int windowEnd = 0;
             int substitutionSoFar = 0;
             int maxLength = 0;

             Dictionary<int, int> subArrayDictionary = new Dictionary<int, int> {{windowStart, windowEnd}};
             if (arr[windowStart] == 0)
             {
                 substitutionSoFar = 1;
             }
             windowEnd += 1;
             
             while (windowEnd <= arr.Length)
             {
                 if (substitutionSoFar <= k)
                 {
                     if (windowEnd<arr.Length && arr[windowEnd] == 1)
                     {
                         subArrayDictionary[windowStart] = windowEnd++;
                     }
                     else
                     {
                         substitutionSoFar++;
                         subArrayDictionary[windowStart] = windowEnd++;
                     }
                 }
                 else
                 {
                     maxLength = Math.Max(maxLength, windowEnd - windowStart - 1);
                     windowStart += 1;
                     windowEnd = windowStart;
                     substitutionSoFar = 0;
                     subArrayDictionary = new Dictionary<int, int> {{ windowStart, windowEnd }};
                 }
             }

             return Math.Max(maxLength, windowEnd - windowStart - 1);
        }
    }
}