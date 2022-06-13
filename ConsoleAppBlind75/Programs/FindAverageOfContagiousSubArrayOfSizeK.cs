using System;
using System.Collections.Generic;

namespace ConsoleAppBlind75
{
    public class FindAverageOfContagiousSubArrayOfSizeK
    {
        public void Execute(int[] arr, double size)
        {
            List<double> avgList = new List<double>();

            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum = sum + arr[i];
            }
            
            avgList.Add(sum);

            for (int i = 1; i <= arr.Length - (int)size; i++)
            {
                sum = sum - arr[i - 1] + arr[i + (int)size - 1];
                avgList.Add(sum);
            }

            foreach (var item in avgList)
            {
                Console.WriteLine((double)item/size);
            }
        }
    }
}