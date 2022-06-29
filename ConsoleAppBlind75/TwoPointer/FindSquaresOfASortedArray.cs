using System;
using System.Text.RegularExpressions;

namespace ConsoleAppBlind75.TwoPointer
{
    public class FindSquaresOfASortedArray
    {
        public int[] Execute(int[] arr)
        {
            int len = arr.Length;
            int[] resultArray = new int[len];

            int rightPointer = arr.Length - 1;
            int leftPointer = 0;

            while (leftPointer<=rightPointer)
            {
                int leftSquare = arr[leftPointer] * arr[leftPointer];
                int rightSquare = arr[rightPointer] * arr[rightPointer];

                if (leftSquare > rightSquare)
                {
                    resultArray[len-1] = leftSquare;
                    leftPointer++;
                }
                else
                {
                    resultArray[len-1] = rightSquare;
                    rightPointer--;
                }

                len--;
            }
            

            return resultArray;
        }
    }
}