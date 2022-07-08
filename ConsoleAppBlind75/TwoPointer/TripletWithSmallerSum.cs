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
                int localRight = rightPointer;
                while (localLeft<localRight)
                {
                    if (arr[i] + arr[localLeft] + arr[localRight] < target)
                    {
                        tripletCount += (localRight - localLeft);
                        localLeft++;
                    }
                    else
                    {
                        localRight--;
                    }
                }
            }

            return tripletCount;
        }
    }
}