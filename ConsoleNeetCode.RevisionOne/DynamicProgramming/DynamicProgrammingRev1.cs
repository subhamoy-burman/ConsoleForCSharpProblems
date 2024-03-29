﻿using System;
using System.Text.RegularExpressions;

namespace ConsoleNeetCode.RevisionOne.DynamicProgramming;

public static class DynamicProgrammingRev1
{
    public static int LcsRecursive(string input1, string input2)
    {
        int index1 = input1.Length - 1;
        int index2 = input2.Length - 1;

        return LcsRecursiveUtil(input1, input2, index1, index2);
    }

    private static int LcsRecursiveUtil(string input1, string input2, int index1, int index2)
    {
        if (index1 < 0 || index2 < 0)
        {
            return 0;
        }

        if (input1[index1] == input2[index2])
        {
            return 1 + LcsRecursiveUtil(input1, input2, index1 - 1, index2 - 1);
        }

        return Math.Max(LcsRecursiveUtil(input1, input2, index1 - 1, index2),
            LcsRecursiveUtil(input1, input2, index1, index2 - 1));
    }

    public static int LcsDpMemoization(string input1, string input2)
    {
        int[,] dpArray = new int[input1.Length, input2.Length];
        int index1 = input1.Length-1;
        int index2 = input2.Length-1;

        for (int i = 0; i < dpArray.GetLength(0); i++)
        {
            for (int j = 0; j < dpArray.GetLength(1); j++)
            {
                dpArray[i, j] = -1;
            }
        }

        return LcsDpUtil(index1, index2, input1, input2, dpArray);

        
    }

    private static int LcsDpUtil(int index1, int index2, string input1, string input2, int[,] dpArray)
    {
        if (index1 < 0 || index2 < 0)
        {
            return  0;
        }

        if (dpArray[index1, index2] != -1)
        {
            return dpArray[index1, index2];
        }

        if (input1[index1] == input2[index2])
        {
            return  dpArray[index1, index2] = 1 + LcsDpUtil(index1 - 1, index2 - 1, input1, input2, dpArray);
        }

        return dpArray[index1, index2] = Math.Max(LcsDpUtil(index1, index2 - 1, input1, input2, dpArray),
            LcsDpUtil(index1 - 1, index2, input1, input2, dpArray));
    }

    public static int MinimumNoOfCoins(int[] coins, int target)
    {
        int n = coins.Length;
        return MinCoinsRecursive(n - 1, target, coins);
    }

    private static int MinCoinsRecursive(int index, int target, int[] coins)
    {
        //Base case
        if (index == 0)
        {
            if (target % coins[0] == 0)
            {
                return target / coins[0];
            }
            else
            {
                return Int32.MaxValue;
            }
        }
        
        
        int notPickingCoin = MinCoinsRecursive(index - 1, target, coins);
        
        int pickingCoin = Int32.MaxValue;

        if (coins[index] <= target)
        {
            pickingCoin = 1 + MinCoinsRecursive(index, target-coins[index], coins);
        }

        return Math.Min(pickingCoin, notPickingCoin);

    }

    public static int CoinChange2(int[] coins, int target)
    {
        int length = coins.Length;
        return CoinChange2Rec(length - 1, coins, target);
    }

    private static int CoinChange2Rec(int index, int[] coins, int target)
    {
        if (target == 0)
        {
            return 1;
        }

        if (index == 0)
        {
            return target % coins[index] == 0 ? 1 : 0;
        }
        
        int pickCoin = 0;
        if (target - coins[index] >= 0)
        {
            pickCoin = CoinChange2Rec(index, coins, target - coins[index]);
        }

        int notPickCoin = CoinChange2Rec(index - 1, coins, target);

        return pickCoin + notPickCoin;
    }

    public static int UnboundedKnapsack(int[] val, int[] weights)
    {
        int capacity = 100;

        int[,] dpArray = new int[val.Length, weights.Length];
        // Initialize all DP array to -1
        return FuncCalculateKnapsack(val.Length - 1, capacity, val, weights, dpArray);
    }

    private static int FuncCalculateKnapsack(int index, int capacity, int[] val, int[] weights, int[,] dpArray)
    {
        if (index == 0)
        {
            return capacity / weights[0] * val[0];
        }

        if (dpArray[index, capacity] != -1)
        {
            return dpArray[index, capacity];
        }
        
        int notPicking = FuncCalculateKnapsack(index - 1, capacity, val, weights, dpArray);

        int picking = 0;

        if (weights[index] <= capacity)
        {
            picking = val[index] + FuncCalculateKnapsack(index, capacity - weights[index], val, weights, dpArray);
        }

        dpArray[index, capacity] = Math.Max(picking, notPicking);
        return dpArray[index, capacity];
    }

    public static int RodCutting(int[] values, int target)
    {
        int N = values.Length;

        return FuncRodCutting(0, N, values);
    }

    private static int FuncRodCutting(int index, int rodLength, int[] values)
    {
        if (index == 0)
        {
            return values[0] * rodLength;
        }
        
        int picking = Int32.MinValue;
        int currentRodLength = index + 1;
        
        if (currentRodLength <= rodLength)
        {
            picking = values[index] + FuncRodCutting(index, rodLength - currentRodLength, values);
        }

        int notPicking = FuncRodCutting(index - 1, rodLength, values);

        return Math.Max(picking, notPicking);
    }

    public static int DistinctSubsequences(string s1, string s2)
    {
        int[,] dpArray = new int[s1.Length + 1, s2.Length + 1];

        for (int i = 0; i < dpArray.GetLength(0); i++)
        {
            for (int j = 0; j < dpArray.GetLength(1); j++)
            {
                dpArray[i, j] = -1;
            }
        }
        return SolveDistinctSubsequences(s1, s2, s1.Length - 1, s2.Length - 1, dpArray);
    }

    private static int SolveDistinctSubsequences(string s1, string s2, int index1, int index2, int[,] dpArray)
    {
        if (index2 < 0)
        {
            return 1;
        }
        
        if (index1 < 0)
        {
            return 0;
        }

        if (dpArray[index1, index2] != -1)
        {
            return dpArray[index1, index2];
        }

        if (s1[index1] == s2[index2])
        {
            return dpArray[index1, index2] = SolveDistinctSubsequences(s1, s2, index1 - 1, index2 - 1, dpArray) +
                   SolveDistinctSubsequences(s1, s2, index1 - 1, index2, dpArray);
        }
        else
        {
            return dpArray[index1, index2] = SolveDistinctSubsequences(s1, s2, index1 - 1, index2, dpArray);
        }
    }

    //Not Tested
    private static int SolveDistinctSubsequencesTabulation(string s1, string s2, int[,] dpArray)
    {
        for (int j = 0; j < s1.Length; j++)
        {
            dpArray[0, j] = 0;
        }

        for (int i = 0; i < s2.Length; i++)
        {
            dpArray[i, 0] = 1;
        }

        for (int m = 1; m < s1.Length; m++)
        {
            for (int n = 1; n < s2.Length; n++)
            {
                if(s1[m-1] == s2[n-1] )
                    dpArray[m, n] = dpArray[m - 1, n - 1] + dpArray[m - 1, n];
                else
                {
                    dpArray[m, n] = dpArray[m - 1, n];
                }
            }
        }

        return dpArray[s1.Length, s2.Length];
    }

    public static int LongestCommonSubstring(string input1, string input2)
    {
        var inputArr1 = input1.ToCharArray();
        var inputArr2 = input2.ToCharArray();


        int res = 0;

        int[,] dpArray = new int[input1.Length + 1, input2.Length + 1];

        for (int i = 0; i < dpArray.GetLength(0); i++)
        {
            for (int j = 0; j < dpArray.GetLength(1); j++)
            {
                dpArray[i, j] = -1;
            }
        }

        return FuncLongestCommonSubstring(inputArr1.Length-1, inputArr2.Length-1, inputArr1, inputArr2, res, dpArray);
        
    }

    private static int FuncLongestCommonSubstring(int index1, int index2, char[] inputArr1, char[] inputArr2, int res, int[,] dpArray)
    {
        if (index1 == 0 || index2 == 0)
        {
            return res;
        }

        if (dpArray[index1, index2] != -1)
        {
            return dpArray[index1, index2];
        }

        if (inputArr1[index1] == inputArr2[index2])
        {
            res = FuncLongestCommonSubstring(index1 - 1, index2 - 1, inputArr1, inputArr2, res + 1, dpArray);
        }

        return dpArray[index1,index2] =  Math.Max(res, Math.Max(
            FuncLongestCommonSubstring(index1 - 1, index2, inputArr1, inputArr2, 0, dpArray),
            FuncLongestCommonSubstring(index1, index2 - 1, inputArr1, inputArr2, 0, dpArray)
        ));
    }
}