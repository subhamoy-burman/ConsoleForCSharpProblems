using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleAppBlind75.RecursionPractice
{
    public static class RecursionPractice
    {
        private static int k;
        public static void Print1ToN()
        {
            k = 5;
            //PrintNumbers(1);
            PrintNumbersAlternate(k);
        }

        public static void PrintNumbersAlternate(int n)
        {
            if (n == 0)
            {
                return;
            }
            PrintNumbersAlternate(n-1);
            Debug.WriteLine(n);
        }

        private static void PrintNumbers(int n)
        {
            Debug.WriteLine(n);
            if (n == k)
            {
                return;
            }
            
            PrintNumbers(n+1);
        }

        public static int SumOfDigits(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            return SumOfDigits(n / 10) + n % 10;
        }

        private static int sum = 0;
        public static void ReverseOfANumber(int n)
        {
            if (n == 0)
            {
                return;
            }

            sum +=  (n % 10) * (int)Math.Pow(10, GetNumberOfDigits(n/10));
            ReverseOfANumber(n/10);
        }

        private static int GetNumberOfDigits(int n)
        {
            int digitCount = 0;
            while (n>0)
            {
                digitCount++;
                n = n / 10;
            }

            return digitCount;
        }

        private static int count = 0;
        public static void CountNoOfZeros(int n)
        {
            if (n == 0)
            {
                return;
            }

            int numberOfZero = n % 10 != 0 ? 0 : 1;
            count += numberOfZero;
            CountNoOfZeros(n / 10);
        }

        public static int CountNoOfZeroWithCounter(int n, int counter)
        {
            if (n == 0)
                return counter;

            if (n % 10 == 0)
            {
                return  CountNoOfZeroWithCounter(n / 10, counter + 1);
            }
            else
            {
                return CountNoOfZeroWithCounter(n / 10, counter);
            }
        }

        public static bool IsArraySorted(int[] arr, int startIndex = 0)
        {
            if (startIndex + 1 == arr.Length)
            {
                return true;
            }

            return arr[startIndex] <= arr[startIndex + 1] && IsArraySorted(arr, startIndex + 1);
        }

        public static int FindElementInArray(int[] arr, int target, int index=0)
        {
            if (index == arr.Length)
            {
                return -1;
            }
            return arr[index] == target ? index : FindElementInArray(arr,  target,index + 1);
        }

        public static int TargetOccuranceCount = 0;
        public static int CountMultipleOccurances(int[] arr, int target, int occurences,  int index=0)
        {
            if (index == arr.Length)
            {
                return occurences;
            }

            if (arr[index] == target)
            {
                occurences += 1;
            }

            return CountMultipleOccurances(arr, target, occurences,index + 1);
        }

        public static List<int> GetMultipleOccurancesIndex(int[] arr, int target, int index= 0)
        {
            if (index == arr.Length)
            {
                return new List<int>();
            }
            List<int> currentList = new List<int>();
            if (arr[index] == target)
            {
                currentList.Add(index);
            }

            currentList.AddRange(GetMultipleOccurancesIndex(arr, target, index + 1));
            return currentList;
        }

        public static void PrintPattern1Iteratively(int numberOfStarts)
        {
            for (int i = numberOfStarts; i > 0; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
        }
    }
}