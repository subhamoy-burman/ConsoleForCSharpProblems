using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleAppBlind75.DynamicProgramming
{
    public static class DynamicProgramming
    {
        public static int MinimumMovesToClimbStairs(int numberOfSteps, int[] givenSteps)
        {
            int?[] dpArray = new int?[numberOfSteps + 1];

            dpArray[numberOfSteps] = 0;

            for (int i = numberOfSteps - 1; i >= 0; i--)
            {
                if (givenSteps[i] > 0)
                {
                    int min = Int32.MaxValue;

                    for (int j = 1; j <= givenSteps[i] && i + j < dpArray.Length; j++)
                    {
                        if (dpArray[i + j] != null)
                        {
                            min = Math.Min(min, dpArray[i + j].Value);
                        }
                    }

                    if (min != Int32.MaxValue)
                    {
                        dpArray[i] = min + 1;
                    }
                }
            }

            return dpArray[0].Value;
        }

        public static int PathWithMaximumGold(int[,] goldPaths)
        {
            int[,] goldDpPaths = new int[,] { };

            for (int j = goldDpPaths.GetLength(1) - 1; j <= 0; j--)
            {
                for (int i = 0; i < goldDpPaths.GetLength(0); i++)
                {
                    
                }
            }

            return -1;
        }

        public static int NumberOfWaysToClimbStairs(int numberOfStairs, int[] dynArray)
        {
            if (dynArray[numberOfStairs] != -1)
            {
                return dynArray[numberOfStairs];
            }
            if (numberOfStairs == 0)
            {
                dynArray[0] = 1;
            }

            if (numberOfStairs == 1)
            {
                dynArray[1] = 1;
            }

            if (numberOfStairs == 2)
            {
                dynArray[2] = 2;
            }

            return NumberOfWaysToClimbStairs(numberOfStairs - 1, dynArray) + NumberOfWaysToClimbStairs(numberOfStairs - 2, dynArray) 
                                                                           + NumberOfWaysToClimbStairs(numberOfStairs-3, dynArray);
                
            

            return -1; //NumberOfWaysToClimbStairs(numberOfStairs - 1) + NumberOfWaysToClimbStairs(numberOfStairs - 2);
        }
        
        public static int ClimbStairs(int n) {

            if(n==0 || n==1)
            {
                return 1;
            }
            
            int[] solverArray = new int[n+1];
            
            solverArray[0] = 1;
            solverArray[1] = 1;
            solverArray[2] = 2;
            
            for(int i = 3; i<=n; i++)
            {
                if(solverArray[i] == 0)
                {
                    solverArray[i] = solverArray[i-1] + solverArray[i-2];
                }
            }

            return solverArray[n];
        }

        public static int MinCostClimbingStairs(List<int> costOfClimbing)
        {
            int n = costOfClimbing.Count;
            
            return Math.Min(CalculateCostToReach(n-1, costOfClimbing), CalculateCostToReach(n-2, costOfClimbing));
        }

        private static int CalculateCostToReach(int n, List<int> costOfClimbing)
        {
            if (n < 0)
            {
                return 0;
            }

            if (n==0 || n == 1)
            {
                return costOfClimbing[n];
            }

            var costToClimbNthStep = Math.Min(CalculateCostToReach(n - 1, costOfClimbing), CalculateCostToReach(n - 2, costOfClimbing)) +
                   costOfClimbing[n];
            return costToClimbNthStep;
        }

        public static int MinCostOfClimbingStairsOptimized(int[] costOfClimbing)
        {
            int numberOfStairs = costOfClimbing.Length;

            if (numberOfStairs == 0 || numberOfStairs == 1)
            {
                return 0;
            }

            int[] dpArray = new int[numberOfStairs];
            dpArray[0] = costOfClimbing[0];
            dpArray[1] = costOfClimbing[1];
            for (int i = 2; i < numberOfStairs; i++)
            {
                dpArray[i] = Math.Min(dpArray[i - 1], dpArray[i - 2]) + costOfClimbing[i];
            }

            return Math.Min(dpArray[numberOfStairs - 1], dpArray[numberOfStairs - 2]);
        }

        public static int HouseRobber(int[] moneyInHouse)
        {
            int n = moneyInHouse.Length;

            switch (n)
            {
                case 0:
                    return moneyInHouse[0];
                case 1:
                    return Math.Max(moneyInHouse[0], moneyInHouse[1]);
            }

            int[] dpArray = new int[n];
            dpArray[0] = moneyInHouse[0];
            dpArray[1] = Math.Max(moneyInHouse[0], moneyInHouse[1]);

            for (int i = 2; i < dpArray.Length; i++)
            {
                if (dpArray[i - 2] + moneyInHouse[i] >= dpArray[i - 1])
                {
                    dpArray[i] = dpArray[i - 2] + moneyInHouse[i];
                }
                else
                {
                    dpArray[i] = dpArray[i - 1];
                }
            }

            return Math.Max(dpArray[n - 1], dpArray[n - 2]);
        }

        private static int HouseRobberCommon(int[] moneyInHouse, int startIndex, int endIndex)
        {
            int numOfElements = endIndex - startIndex + 1;
            if (numOfElements == 1)
            {
                return Math.Max(moneyInHouse[startIndex], moneyInHouse[endIndex]);
            }
            int[] dpArray = new int[numOfElements];
            dpArray[0] = moneyInHouse[startIndex];
            dpArray[1] = Math.Max(moneyInHouse[startIndex], moneyInHouse[startIndex + 1]);

            for (int i = 2; i < numOfElements; i++)
            {
                dpArray[i] = Math.Max(dpArray[i - 2] + moneyInHouse[startIndex + i], dpArray[i - 1]);
            }

            return Math.Max(dpArray[numOfElements - 1], dpArray[numOfElements - 2]);
        }

        public static int HouseRobber2(int[] moneyInHouse)
        {
            if (moneyInHouse.Length == 1)
            {
                return moneyInHouse[0];
            }

            return Math.Max(HouseRobberCommon(moneyInHouse, 0, moneyInHouse.Length - 2),
                HouseRobberCommon(moneyInHouse, 1, moneyInHouse.Length - 1));
        }
        
        public static int CoinChange(int[] coins, int amount) {
        
            if(amount == 0)
                return 0;

            Array.Sort(coins);
            int coinArrayLength = coins.Length-1;
            int target = amount;
            int count = 0;

            while(true)
            {
                int newTarget = target - coins[coinArrayLength];

                if(newTarget==0)
                {
                    count++;
                    return count;
                }
                if(newTarget>0)
                {
                    target = newTarget;
                    count++;
                    continue;
                }
                if(newTarget<0)
                {
                    coinArrayLength--;
                    if(coinArrayLength<0)
                    {
                        break;
                    }
                    continue;
                }
            }

            return -1;

        }

        public static void PrintBrokenWords(string input, string[] dictionary, string ans)
        {
            if (input.Length == 0)
            {
                Debug.WriteLine(ans);
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                string left = input.Substring(0, i + 1);
                if (dictionary.Contains(left))
                {
                    PrintBrokenWords(input.Substring(i+1),dictionary,ans+"#"+left);
                }
            }
        }

        public static int PrintLongestIncreasingSubsequence(int[] inputSequence)
        {
            return GetLength(0, -1, inputSequence);
        }

        private static int GetLength(int currIndex, int prevIndex, int[] inputSequence)
        {
            if (currIndex == inputSequence.Length)
            {
                return 0;
            }

            int len = GetLength(currIndex + 1, prevIndex, inputSequence);

            if (prevIndex == -1 || (inputSequence[currIndex] > inputSequence[prevIndex]))
            {
                len = Math.Max(len, 1+ GetLength(currIndex + 1, currIndex, inputSequence));
            }

            return len;
        }

        public static bool IsSubSetSum(int[] inputArr, int target)
        {
            int[,] dpArray = new int[inputArr.Length, target + 1];
            for (int x = 0; x < dpArray.GetLength(0); x += 1) {
                for (int y = 0; y < dpArray.GetLength(1); y += 1)
                {
                    dpArray[x, y] = -1;
                }
            }
            return IsSubSetFunc(inputArr,inputArr.Length-1, target, dpArray);
        }

        private static bool IsSubSetFunc(int[] inputArr, int inputArrIndex, int target, int[,] dpArray)
        {
            if (target == 0)
            {
                return true;
            }

            if (inputArrIndex == 0)
            {
                return inputArr[inputArrIndex] == target;
            }

            if (dpArray[inputArrIndex, target] != -1)
            {
                return dpArray[inputArrIndex, target] == 1;
            }
            bool notTake = IsSubSetFunc(inputArr, inputArrIndex - 1, target, dpArray);
            bool take = false;
            
            if (target >= inputArr[inputArrIndex])
            {
                take = IsSubSetFunc(inputArr, inputArrIndex - 1, target - inputArr[inputArrIndex], dpArray);
            }

            dpArray[inputArrIndex, target] = take || notTake? 1:0;
            return take || notTake;
        }

        public static int UniquePaths(int m, int n)
        {
            int[,] dpArray = new int[m+1, n+1];
            
            for (int i=0;i<dpArray.GetLength(0);i++)
            {
                for (int j=0;j<dpArray.GetLength(1);j++)
                {
                    dpArray[i, j] = -1;
                }
            }
            
            return UniquePathFunction(m, n, dpArray);
        }

        private static int UniquePathFunction(int m, int n, int[,] dpArray)
        {
            if (m == 0 && n == 0)
            {
                return 1;
            }

            if (m < 0 || n < 0)
            {
                return 0;
            }

            if (dpArray[m, n] != -1)
            {
                return dpArray[m, n];
            }
            
            int up = UniquePaths(m - 1, n);
            int down = UniquePaths(m, n - 1);

            dpArray[m, n] = up + down;
            return up + down;
        }

        public static int LongestCommonSubsequence(string text1, string text2)
        {
            int m = text1.Length, n = text2.Length;
            int[,] dpArray = new int[m, n];
            
            for (int i=0;i<dpArray.GetLength(0);i++)
            {
                for (int j=0;j<dpArray.GetLength(1);j++)
                {
                    dpArray[i, j] = -1;
                }
            }
            int length = LcsFunction(text1, text2, text1.Length-1, text2.Length-1, dpArray);
            return length;
        }

        private static int LcsFunction(string str1, string str2, int indexOfStr1, int indexOfStr2, int[,] dpArray)
        {
            if (indexOfStr1 == -1 || indexOfStr2 == -1)
            {
                return 0;
            }

            if (dpArray[indexOfStr1, indexOfStr2] != -1)
            {
                return dpArray[indexOfStr1, indexOfStr2];
            }
            if (str1[indexOfStr1] == str2[indexOfStr2])
            {   
                dpArray[indexOfStr1, indexOfStr2] =  1 + LcsFunction(str1, str2, indexOfStr1 - 1, indexOfStr2 - 1, dpArray);
            }
            else
            {
                dpArray[indexOfStr1, indexOfStr2] = Math.Max(LcsFunction(str1, str2, indexOfStr1 - 1, indexOfStr2, dpArray),
                    LcsFunction(str1, str2, indexOfStr1, indexOfStr2 - 1, dpArray));
            }

            return dpArray[indexOfStr1, indexOfStr2];
        }

        public static int CoinChangeCombinations(int[] inputCoins, int target)
        {
            return FuncCoinChangeCombination(inputCoins, inputCoins.Length-1, target);
        }

        private static int FuncCoinChangeCombination(int[] inputCoins, int index, int target)
        {
            if (index == 0)
            {
                return target % inputCoins[0] == 0 ? 1 : 0;
            }
            
            int notPickCount = FuncCoinChangeCombination(inputCoins, index - 1, target);
            
            int pickCount = 0;
            
            if(target >= inputCoins[index])
            {   
                pickCount = FuncCoinChangeCombination(inputCoins, index, target - inputCoins[index]);
            }

            return pickCount + notPickCount;
        }
    }
}