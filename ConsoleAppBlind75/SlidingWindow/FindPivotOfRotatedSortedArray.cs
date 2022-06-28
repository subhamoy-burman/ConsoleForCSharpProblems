using System;

namespace ConsoleAppBlind75
{
    public class FindPivotOfRotatedSortedArray
    {
        public void Execute(int[] arr)
        {
            var low = 0;
            var high = arr.Length-1;

            while (low <= high)
            {
                var mid = (low + high) / 2;
                if (arr[mid] > arr[mid + 1])
                {
                    Console.WriteLine("Pivot is {0}", arr[mid]);
                    break;
                }

                if (arr[low] <= arr[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }

            }
        }
    }
}