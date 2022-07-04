using System;

namespace ConsoleAppBlind75.TwoPointer
{
    public class TripletSumCloseToTarget
    {
        public int Execute(int[] arr, int targetSum)
        {
            int leftPointer = 0;
            int rightPointer = arr.Length - 1;
            int smallestDifference = Int32.MaxValue;
            
            Array.Sort(arr);
            for (int i = leftPointer; i <= rightPointer-3; i++)
            {
                int localLeft = i+1;
                int localRight = rightPointer - 1;

                while (localLeft<localRight)
                {
                    int targetDiff = targetSum - (arr[i] + arr[localLeft] + arr[localRight]);
                    if (targetDiff == 0)
                    {
                        return targetSum;
                    }
                    
                    //TODO: If targetDiff > 0 : localRight -- , if targetDiff < 0 : localLeft++ 
                }
            }

            return smallestDifference;
        }
    }
}