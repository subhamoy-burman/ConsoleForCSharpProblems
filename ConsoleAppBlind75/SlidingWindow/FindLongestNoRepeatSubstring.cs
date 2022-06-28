using System;
using System.Collections.Generic;

namespace ConsoleAppBlind75
{
    public class FindLongestNoRepeatSubstring
    {
        public int Execute(char[] arr)
        {
            int startIndex = 0;
            int indexSoFar = 0;
            int maxLength = 0;

            Dictionary<int, List<char>> listOfElementsSoFar = new Dictionary<int, List<char>>();

            while (indexSoFar+1<arr.Length)
            {
                if (!listOfElementsSoFar.ContainsKey(startIndex))
                {
                    listOfElementsSoFar.Add(startIndex, new List<char>() { arr[startIndex]});
                }
                else
                {
                    if (listOfElementsSoFar[startIndex].Contains(arr[++indexSoFar]))
                    {
                        maxLength = Math.Max(maxLength, listOfElementsSoFar[startIndex].Count);
                        startIndex++;
                        indexSoFar = startIndex;
                    }
                    else
                    {
                        listOfElementsSoFar[startIndex].Add(arr[indexSoFar]);
                        //indexSoFar++;
                    }
                }
            }
            return maxLength;
        }

        public int ExecuteAlternate(char[] arr)
        {
            int windowStart = 0;
            int windowEnd = 0;
            int maxLength = 0;

            Dictionary<char, int> listOfWindows = new Dictionary<char, int>();
            for (windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                char leftChar = arr[windowEnd];
                if (listOfWindows.ContainsKey(leftChar))
                {
                    windowStart = Math.Max(windowStart, listOfWindows[leftChar] + 1);
                }
                listOfWindows.Add(leftChar,windowEnd);
                maxLength = Math.Max(windowEnd - windowStart + 1, maxLength);
            }
            return maxLength;
        }
    }
}