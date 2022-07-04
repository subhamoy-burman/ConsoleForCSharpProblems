using System;

namespace ConsoleAppBlind75.TwoPointer
{
    public class TripletWithSmallerSum
    {
        public int Execute(int[] arr, int target)
        {
            Array.Sort(arr);

            int leftPointer = 0;
            int rightPointer = arr.Length - 1;
            int tripletCount = 0;

            for (int i = leftPointer; i <= rightPointer-2; i++)
            {
                int localLeft = i + 1;
                int localright = rightPointer;
                while (localLeft<localright)
                {
                    if (arr[i] + arr[localLeft] + arr[localright] < target)
                    {
                        tripletCount += (localright - localLeft);
                        localLeft++;
                    }
                    else
                    {
                        localright--;
                    }
                }
            }

            return tripletCount;
        }
    }
}