using System;

namespace ConsoleAppBlind75
{
    public class FindSmallestSubArrayOfGivenSum
    {
        public int Execute(int[] arr, int k)
        {
            int sumSoFar = 0;
            int startIndex = 0;
            
            int arrMover = 0;
            int minWindowSize = Int32.MaxValue;

            while (arrMover<=arr.Length)
            {
                if (sumSoFar >= k)
                {
                    if (arrMover - startIndex < minWindowSize)
                    {
                        minWindowSize = arrMover  - startIndex;
                    }
                    sumSoFar = sumSoFar - arr[startIndex];
                    startIndex++;
                }
                else if(sumSoFar < k)
                {
                    if (arr.Length == arrMover)
                    {
                        break;
                    }
                    sumSoFar = sumSoFar + arr[arrMover];
                    arrMover++;
                }
                // else if(sumSoFar == k)
                // {
                //     break;
                // }
            }
            Console.WriteLine($"Start Index is : {startIndex} and end index is {arrMover -1}");
            return minWindowSize;
        }
    }
}