using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Microsoft.VisualBasic;

namespace ConsoleNeetCode.RevisionOne.DynamicProgramming
{
    public static class DynamicProgramming
    {
        public static int ClimbingStairsRecursionCount(int noOfStairs)
        {
            if (noOfStairs == 0 || noOfStairs == 1)
            {
                return 1;
            }

            if (noOfStairs == 2)
            {
                return 2;
            }

            return ClimbingStairsRecursionCount(noOfStairs - 1) + ClimbingStairsRecursionCount(noOfStairs - 2);
        }

        public static int ClimbingStairsUsingMemoization(int noOfStairs)
        {
            int[] resultArray = new int[noOfStairs+1];

            resultArray[0] = 0;
            resultArray[1] = 1;

            for (int i = 2; i <= noOfStairs; i++)
            {
                resultArray[i] = resultArray[i - 1] + resultArray[i - 2];
            }

            return resultArray[noOfStairs];
        }

        public static int MinCostInClimbingNoOfStairs(int[] costOfClimbing)
        {
            return 1;
        }

        public static int HouseRobber(int[] houseList)
        {
            var maxRobbed = HouseRobberSolve(houseList, houseList.Length-1);
            return maxRobbed;
        }
        
        public static int HouseRobberDP(int[] houseList)
        {
            int[] dpArray = new int[houseList.Length];
            var maxRobbed = HouseRobberSolveDP(houseList, dpArray);
            return maxRobbed;
        }
        
        public static int HouseRobberMemo(int[] houseList)
        {
            int[] dpArray = new int[houseList.Length];
            Array.Fill(dpArray,-1);
            var maxRobbed = HouseRobberSolveMemo(houseList, houseList.Length - 1, dpArray);
            return maxRobbed;
        }

        private static int HouseRobberSolve(int[] houseList, int houseIndex)
        {
            if (houseIndex < 0)
            {
                return 0;
            }

            if (houseIndex == 0 || houseIndex == 1)
            {
                return houseList[houseIndex];
            }

            return Math.Max(HouseRobberSolve(houseList, houseIndex-1), HouseRobberSolve(houseList, houseIndex-2) + houseList[houseIndex]);
        }

        private static int HouseRobberSolveDP(int[] houseList, int[] dpArray)
        {
            dpArray[0] = houseList[0];
            dpArray[1] = houseList[1];
            for (int i = 2; i < dpArray.Length; i++)
            {
                dpArray[i] = Math.Max(dpArray[i - 1], dpArray[i - 2] + houseList[i]);
            }

            return dpArray[houseList.Length-1];
        }

        private static int HouseRobberSolveMemo(int[] houseList, int index, int[] dpArray)
        {
            if (index == 0 || index == 1)
            {
                return dpArray[index] = houseList[index];
            }
            
            if (dpArray[index] != -1)
            {
                return dpArray[index];
            }

            int result = Math.Max(HouseRobberSolveMemo(houseList, index-1, dpArray),
                HouseRobberSolveMemo(houseList, index - 2 , dpArray)+ houseList[index]);

            dpArray[index] = result;
            return result;
        }

        public static int LongestCommonSubsequence(string s1, string s2)
        {
            int[,] dpArray = new int[s1.Length+1, s2.Length+1];
            
            var value = SolveLCS(s1, s2, s1.Length-1, s2.Length-1, dpArray);
            for (int i = 0; i < dpArray.GetLength(0); i++)
            {
                Debug.WriteLine("");
                for (int j = 0; j < dpArray.GetLength(1); j++)
                {
                    Debug.Write(dpArray[i,j] + " ");
                }
            }

            var printLongestCommonSequence = PrintLongestCommonSequence( s1, s2,dpArray);
            
            
            return value;
        }

        private static string PrintLongestCommonSequence(string s1, string s2, int[,] dpArray)
        {
            int i = s1.Length;
            int j = s2.Length;
            List<char> lcsSequence = new List<char>();

            while (i>0 && j>0)
            {
                if (s1[i-1] == s2[j-1])
                {
                    lcsSequence.Add(s1[i-1]);
                    i--;
                    j--;
                }
                else
                {
                    if (dpArray[i - 1, j] > dpArray[i, j - 1])
                    {
                        i--;
                    }
                    else
                    {
                        j--;
                    }
                }
            }

            lcsSequence.Reverse();
            var str = new string(lcsSequence.ToString());

            return str;
        }

        private static int SolveLCS(string s1, string s2, int index1, int index2, int[,] dpArray)
        {
            if (index1 < 0 || index2 < 0)
            {
                return 0;
            }

            if (index1 == 0 || index2 == 0)
            {
                dpArray[index1, index2] = 0;
            }

            if (dpArray[index1, index2] != 0)
            {
                return dpArray[index1, index2];
            }
            
            if (s1[index1] == s2[index2])
            {
                dpArray[index1, index2] = 1 + SolveLCS(s1, s2, index1 - 1, index2 - 1, dpArray);
            }
            else
            {
                dpArray[index1, index2] = Math.Max(SolveLCS(s1, s2, index1 - 1, index2, dpArray), SolveLCS(s1, s2, index1, index2 - 1, dpArray));
            }


            return dpArray[index1, index2];
        }

        public static int NinjasTraining(int[,] arr)
        {
            return SolveNinjasTraining(arr.GetLength(0)-1, -1, arr);
        }

        private static int SolveNinjasTraining(int day, int lastTaskPerformed, int[,] arr)
        {
            int max = 0;
            if (day == 0)
            {
                for (int i = 0; i <= 2; i++)
                {
                    if (lastTaskPerformed != i)
                    {
                        max = Math.Max(max, arr[day,i]);
                    }
                }

                return max;
            }

            for (int i = 0; i <= 2; i++)
            {
                if (i != lastTaskPerformed)
                {
                    int points = arr[day, i] + SolveNinjasTraining(day - 1, i, arr);
                    max = Math.Max(max, points);
                }
            }

            return max;
        }

        public static int LongestCommonSubstring(string s1, string s2)
        {
            int s1Length = s1.Length;
            int s2Length = s2.Length;

            int[,] dpArray = new int[s1Length + 1, s2Length + 1] ;
            int ans = 0;

            //var longestCommonSubstring = SolveLongestCommonSubstringRec(s1, index1:s1Length, s2, index2:s2Length,0);
            var longestCommonSubstringDp = SolveLongestCommonSubstringDp(s1, s2);
            return longestCommonSubstringDp;
        }

        private static int SolveLongestCommonSubstringDp(string s1, string s2)
        {
            int[,] dpArray = new int[s1.Length + 1, s2.Length + 1];
            int globalMax = 0;

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dpArray[i, j] = 1 + dpArray[i - 1, j - 1];
                        globalMax = Math.Max(dpArray[i, j], globalMax);
                    }
                    else
                    {
                        dpArray[i, j] = 0;
                    }
                }
            }

            return globalMax;

        }

        private static int SolveLongestCommonSubstringRec(string s1, int index1, string s2, int index2, int count)
        {
            if (index1 == 0 || index2 == 0)
            {
                return count;
            }
            if (s1[index1 - 1] == s2[index2 - 1])
            {
                count = SolveLongestCommonSubstringRec(s1, index1 - 1, s2, index2 - 1, count + 1);
            }

            int count1 = SolveLongestCommonSubstringRec(s1, index1 - 1, s2, index2, 0);
            int count2 = SolveLongestCommonSubstringRec(s1, index1, s2, index2-1, 0);

            count = Math.Max(count, Math.Max(count1, count2));

            return count;
        }

        public static int NumberOfPalindromicSubstrings(string s)
        {
            bool[,] dpArray = new bool[s.Length, s.Length];
            int countOfPalindrome = 0;

            for (int diff = 0; diff < s.Length; diff++)
            {
                for (int i = 0, j = diff; j < s.Length; i++,j++)
                {
                    if (diff == 0)
                    {
                        dpArray[i, j] = true;
                    }
                    else
                    {
                        if (diff == 1)
                        {
                            dpArray[i, j] = s[i] == s[j];
                        }
                        else
                        {
                            if (s[i] == s[j] && i+1 < s.Length)
                                dpArray[i, j] = dpArray[i + 1, j - 1];
                        }
                    }
                    

                    if (dpArray[i, j])
                    {
                        countOfPalindrome++;
                    }
                    
                }
            }

            return countOfPalindrome;
        }

        public static bool SubsetSumEqualsK(int[] subset, int target)
        {
            int[,] dpArray = new int[subset.Length, target + 1];
            for (int i = 0; i < dpArray.GetLength(0); i++)
            {
                for (int j = 0; j < dpArray.GetLength(1); j++)
                {
                    dpArray[i, j] = -1;
                }
            }
            return SolveSubsetSumEqualsKRecursion(subset, subset.Length - 1, target, dpArray);
        }

        private static bool SolveSubsetSumEqualsKRecursion(int[] subset, int index, int target, int[,] dpArray)
        {
            if (target == 0)
            {
                return true;
            }

            if (index == 0)
            {
                return subset[0] == target;
            }

            if (dpArray[index, target] != -1)
                return dpArray[index, target] == 1;

            bool notTake = SolveSubsetSumEqualsKRecursion(subset, index - 1, target, dpArray);

            bool take = false;
            if (target >= subset[index])
            {
                take = SolveSubsetSumEqualsKRecursion(subset, index - 1, target - subset[index], dpArray);
            }

            var result = take || notTake;
            dpArray[index, target] = result ? 1:0;
            return dpArray[index, target] == 1;
        }


        public static int KnapsackProblem(int[] weights, int[] values, int targetWeight)
        {
            int n = weights.Length;
            int[,] dpArray = new int[n, targetWeight + 1];
            for (int i = 0; i < dpArray.GetLength(0); i++)
            {
                for (int j = 0; j < dpArray.GetLength(1); j++)
                {
                    dpArray[i, j] = -1;
                }
            }

            return KnapsackProblemSolve(n-1, targetWeight, weights, values, dpArray);

            int KnapsackProblemSolve(int index, int target,int[] weightList, int[] valuesList, int[,] dpArr)
            {
                if (index == 0)
                {
                    if (weightList[index] <= target)
                    {
                        return valuesList[index];
                    }

                    return 0;
                }

                if (dpArr[index, target] != -1)
                {
                    return dpArr[index, target];
                }

                int notTake = KnapsackProblemSolve(index - 1, target, weightList, valuesList, dpArr);
                
                int take = Int32.MinValue;
                if (weightList[index] <= target)
                {
                    take = valuesList[index] + KnapsackProblemSolve(index - 1, target - weightList[index], weightList, valuesList, dpArr);
                }

                dpArr[index, target] =  Math.Max(take, notTake);
                return dpArr[index, target];
            }
        }
    }
    
}