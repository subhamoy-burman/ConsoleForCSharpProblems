using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace ConsoleNeetCode.RevisionOne.Arrays;

public static class Arrays
{
    public static int LongestSubArraySum(int[] arr, int k)
    {
        Dictionary<int, int> prefixSumDict = new Dictionary<int, int>();

        int sum = 0;
        int maxLen = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
            if(!prefixSumDict.ContainsKey(sum))
                prefixSumDict.Add(sum, i);
            else
            {
                prefixSumDict[sum] = i;
            }

            if (sum == k)
            {
                maxLen = Math.Max(maxLen, i + 1);
                continue;
            }
            
            if (prefixSumDict.ContainsKey(sum - k))
            {
                maxLen = Math.Max(maxLen, prefixSumDict[sum - k]);
            }
        }

        return maxLen;
    }
}