using System.Collections.Generic;

namespace ConsoleAppBlind75.StringAndArray
{
    public class StringAndArray
    {
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            int[] charCollection = new int[26] ;

            foreach (var item in s)
            {
                charCollection[item - 'a']++;
            }

            foreach (var item in t)
            {
                charCollection[item - 'a']--;
            }

            foreach (var item in charCollection)
            {
                if (item != 0)
                    return false;
            }

            return true;
        }

        public static List<int> TopKFrequentElements(int[] nums, int k)
        {
            int[] indexedArray = new int[nums.Length];
            List<int> result = new List<int>();
            
            Dictionary<int, int> freqCount = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                if (!freqCount.ContainsKey(item))
                {
                    freqCount[item] = 1;
                }
                else
                {
                    int currentCount = freqCount[item];
                    freqCount[item] = currentCount + 1;
                }
            }

            foreach (var item in freqCount)
            {
                indexedArray[item.Value] = item.Key;
            }

            int bucketCount = 0;
            for (int i = indexedArray.Length-1; i >=0; i--)
            {
                if (indexedArray[i] != 0)
                {
                    result.Add(indexedArray[i]);
                    bucketCount++;
                }

                if (bucketCount == k)
                    break;
            }

            return result;
        }
    }
}