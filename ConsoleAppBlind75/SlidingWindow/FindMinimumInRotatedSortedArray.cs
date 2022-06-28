using System;

namespace ConsoleAppBlind75
{
    public class FindMinimumInRotatedSortedArray
    {
        public void Execute(int[] arr)
        {
            int smallestElement = Int32.MinValue;
            if (arr.Length == 1)
            {
                smallestElement = arr[0];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (i + 1 == arr.Length)
                {
                    smallestElement = arr[0];
                    break;
                    
                }
                if (arr[i] > arr[i + 1])
                {
                    smallestElement = arr[i + 1];
                    break;
                }
            }
            Console.WriteLine("Smallest element in given array is:  {0}", smallestElement);
        }
    }
}