using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppBlind75
{
    public static class SlidingWindow
    {
        public static int MinSubArrayLen(int target, int[] nums) {
        
            int resultLength = Int32.MaxValue;

            for(int i = 0;i<nums.Length;i++)
            {
                int localSum = nums[i];
                int k = i+1;

                while(k<=nums.Length)
                {
                    if(localSum>=target)
                    {
                        resultLength = Math.Min(resultLength,k-i);
                        break;
                    }
                    
                    if(k == nums.Length) break;
                    localSum += nums[k++];
                }

            }

            return resultLength;
        }

        public static string LongestSubstringWithNoMoreThanKDistinct(string s, int k)
        {
            int windowStart = 0;
            int windowEnd = 0;

            int longestWindowStartIndex = 0;
            int longestWindowEndIndex = 0;
            int longestLength = Int32.MinValue;
            Dictionary<char,int> trackDict = new Dictionary<char,int>();

            while (windowStart <= windowEnd && windowEnd< s.Length)
            {
                // if (trackDict.Count > k)
                // {
                //     if (windowEnd - windowStart > longestLength)
                //     {
                //         longestLength = windowEnd - windowStart;
                //         longestWindowStartIndex = windowStart;
                //         longestWindowEndIndex = windowEnd;
                //     }
                //     if (trackDict[s[windowStart]] == 1)
                //     {
                //         trackDict.Remove(s[windowStart]);
                //     }
                //     else
                //     {
                //         var currVal = trackDict[s[windowStart]];
                //         trackDict[s[windowStart]] = currVal - 1;
                //     }
                //     windowStart++;
                //     continue;
                // }
                
                if(trackDict.ContainsKey(s[windowEnd]))
                {
                    var currVal = trackDict[s[windowEnd]];
                    trackDict[s[windowEnd]] = currVal+1;
                }
                else
                {
                    if (trackDict.Count < 2)
                    {
                        trackDict.Add(s[windowEnd], 1);
                    }
                    else
                    {
                        if (windowEnd - windowStart > longestLength)
                        {
                            longestLength = windowEnd - windowStart;
                            longestWindowStartIndex = windowStart;
                            longestWindowEndIndex = windowEnd-1;
                        }
                        if (trackDict[s[windowStart]] == 1)
                        {
                            trackDict.Remove(s[windowStart]);
                        }
                        else
                        {
                            var currVal = trackDict[s[windowStart]];
                            trackDict[s[windowStart]] = currVal - 1;
                        }
                        windowStart++;
                        continue;
                    }
                }

                windowEnd++;
            }

            return s.Substring(longestWindowStartIndex, longestWindowEndIndex);
        }
        
        public static bool CheckInclusion(string pattern, string inputString) {
        
            Dictionary<char, int> patternDictionary = new Dictionary<char, int>();
            
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
                }
                else
                {
                    patternDictionary.Add(currentChar,1);
                }
            }
            Dictionary<char, int> copyDictionary = new Dictionary<char, int>(patternDictionary);
            int numberOfMatches = 0;
            while (windowEnd<inputCharArray.Length)
            {
                if (patternDictionary.ContainsKey(inputCharArray[windowEnd]))
                {
                    var patternCount = patternDictionary[inputCharArray[windowEnd]];
                    patternDictionary[inputCharArray[windowEnd]] = patternCount - 1;
                    
                    if (patternDictionary[inputCharArray[windowEnd]] == 0)
                    {
                        patternDictionary.Remove(inputCharArray[windowEnd]);
                    }
                    numberOfMatches++;
                    windowEnd++;
                }
                else
                {
                    windowStart++;
                    windowEnd = windowStart;
                    numberOfMatches = 0;
                    patternDictionary = new Dictionary<char, int>(copyDictionary);
                    continue;
                }

                if (numberOfMatches == pattern.Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}