using System;

namespace ConsoleAppBlind75
{
    public class FindMaximumSubArraySumOfSizeK
    {
        public int Execute(int[] arr, int k)
        {
            var maxSoFar = 0;

            for (var i = 0; i < k; i++)
            {
                maxSoFar += arr[i];
            }

            int currentSum = maxSoFar;
            for (int i = 1; i <= arr.Length-k; i++)
            {
                currentSum = currentSum - arr[i - 1] + arr[i + k - 1];

                if (currentSum > maxSoFar)
                {
                    maxSoFar = currentSum;
                }
            }
            Console.WriteLine(maxSoFar);
            return maxSoFar;
        }
    }
}