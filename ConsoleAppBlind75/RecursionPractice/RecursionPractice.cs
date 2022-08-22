using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
// ReSharper disable SwapViaDeconstruction

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

        public static string PrintPattern1Iteratively(int numberOfStarts)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = numberOfStarts; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    sb.Append("*");
                }

                sb.AppendLine();
            }
            
            return sb.ToString();
        }

        public static void PrintPattern1Recursively(int row, int column, StringBuilder sb)
        {
            if (row == 0)
            {
                return;
            }

            if (row > column)
            {
                sb.Append('*');
                PrintPattern1Recursively(row, column + 1, sb);
            }
            else
            {
                sb.AppendLine();
                PrintPattern1Recursively(row - 1, 0, sb);
            }
        }

        private static int _rowLimit = 4;
        public static void PrintPattern2Recursively(int row, int column, StringBuilder sb)
        {
            if (row > _rowLimit)
            {
                return;
            }

            if (row > column)
            {
                sb.Append('*');
                PrintPattern2Recursively(row, column+1, sb);
            }
            else
            {
                sb.AppendLine();
                PrintPattern2Recursively(row+1,0,sb );
            }
        }

        public static int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length-i-1; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        // ReSharper disable once SwapViaDeconstruction
                        var temp = arr[j+1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            return arr;
        }

        public static void BubbleSortRecursion(int[] arr, int n)
        {
            if(n==1)
                return;

            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    var temp = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = temp;
                }
            }
            
            BubbleSortRecursion(arr,n-1);
        }

        private static char charToSkip = 'a';

        public static string SkipACharacter(string charArray, string ans)
        {
            if (charArray.Length == 0)
            {
                return ans;
            }

            if (charArray[0].Equals(charToSkip))
            {
                return SkipACharacter(charArray.Substring(1), ans);
            }

            var firstChar = charArray.Substring(0, 1).ToCharArray()[0];
            ans += firstChar;
            return SkipACharacter(charArray.Substring(1), ans);
        }

        private static string word = "apple";
        public static string SkipAWord(string inputString, StringBuilder ans)
        {
            if (inputString.Length == 0)
            {
                return ans.ToString();
            }

            if (inputString.StartsWith(word))
            {
                return SkipAWord(inputString.Substring(word.Length), ans);
            }

            return SkipAWord(inputString.Substring(1), ans.Append(inputString[0]));
        }

        public static void PrintSubsets(string inputString, string setSofar)
        {
            if (inputString.Length == 0)
            {
                Debug.WriteLine(setSofar);
                return;
            }
            
            PrintSubsets(inputString.Substring(1), setSofar + inputString[0]);
            PrintSubsets(inputString.Substring(1), setSofar);

        }

        public static void PrintPermutations(string processed, string unprocessed)
        {
            if (unprocessed.Length == 0)
            {
                Debug.WriteLine(processed);
                return;
            }

            char charToBeIncluded = unprocessed[0];

            for (int i = 0; i <= processed.Length; i++)
            {
                string rightPart = processed.Substring(0, i);
                string leftPart = processed.Substring(i);
                PrintPermutations(rightPart + charToBeIncluded + leftPart, unprocessed.Substring(1));
            }
        }
        
        public static int CountPermutations(string processed, string unprocessed)
        {
            if (unprocessed.Length == 0)
            {
                Debug.WriteLine(processed);
                return 1;
            }

            int count = 0;
            char charToBeIncluded = unprocessed[0];

            for (int i = 0; i <= processed.Length; i++)
            {
                string rightPart = processed.Substring(0, i);
                string leftPart = processed.Substring(i);
                count =  count + CountPermutations(rightPart + charToBeIncluded + leftPart, unprocessed.Substring(1));
            }

            return count;
        }

        public static List<List<int>> GetSubsets(int[] inputNums)
        {
            List<List<int>> subsets = new List<List<int>>();
            
            subsets.Add(new List<int>());

            foreach (var num in inputNums)
            {
                int n = subsets.Count;
                for (int i = 0; i < n; i++)
                {
                    List<int> set = new List<int>(subsets[i]);
                    set.Add(num);
                    subsets.Add(set);
                }
            }

            return subsets;
        }

        public static List<List<int>> PrintPermutations(int[] arr)
        {
            List<List<int>> result = new List<List<int>>();
            List<List<int>> permutations = new List<List<int>>();
            
            permutations.Add(new List<int>());
            
            foreach(var num in arr)
            {
                int n = permutations.Count;
                for (int i = 0; i < n; i++)
                {
                    var oldPermutations = permutations.LastOrDefault();
                    permutations.RemoveAt(permutations.Count-1);

                    for (int j = 0; j <= oldPermutations.Count; j++)
                    {
                        var newPermutations = new List<int>(oldPermutations);
                        newPermutations.Insert(j,num);

                        if (newPermutations.Count == arr.Length)
                        {
                            result.Add(newPermutations);
                        }
                        else
                        {
                            permutations.Add(newPermutations);
                        }
                    }
                }
            }

            return result;
        }
    }
}