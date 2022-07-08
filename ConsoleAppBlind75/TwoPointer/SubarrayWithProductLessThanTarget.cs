using System.Collections.Generic;

namespace ConsoleAppBlind75.TwoPointer
{
    public class SubarrayWithProductLessThanTarget
    {
        public List<List<int>> Execute(int[] arr, int target)
        {
            int windowStart = 0, windowEnd = 0;
            int multiplicationFactor = 1;
            List<List<int>> listOfInts = new List<List<int>>();

            while (windowStart < arr.Length)
            {
                if (windowEnd > arr.Length - 1)
                {
                    windowStart++;
                    windowEnd = windowStart;
                    multiplicationFactor = 1;
                    continue;
                }
                multiplicationFactor = arr[windowEnd] * multiplicationFactor;
                if (multiplicationFactor < target)
                {
                    var listSpan = new List<int>();
                    for (int i = windowStart; i <= windowEnd; i++)
                    {
                        listSpan.Add(arr[i]);
                    }

                    listOfInts.Add(listSpan);
                    windowEnd++;
                }
                else
                {
                    windowStart++;
                    windowEnd = windowStart;
                    multiplicationFactor = 1;
                }
            }

            return listOfInts;
        }
    }
}