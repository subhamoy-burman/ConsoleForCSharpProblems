using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleAppBlind75.DynamicProgramming;
using NUnit.Framework;

namespace Blind75.Test.DynamicProgrammingTester
{
    [TestFixture]
    public class DynamicProgrammingTester
    {
        [Test]
        public void TestMinMovesStairs()
        {
            var minMoves = DynamicProgramming.MinimumMovesToClimbStairs(10, 
                new int[] { 3, 2, 4, 2, 0, 2, 3, 1, 2, 2 });
        }

        [Test]
        public void TestNoOfWaysToClimbStairs()
        {
            int[] numberArray = new int[6];
            foreach (var i in numberArray)
            {
                numberArray[i] = -1;
            }
            var moves = DynamicProgramming.NumberOfWaysToClimbStairs(5, numberArray);
        }

        [Test]
        public void ClimbStairsTester()
        {
            var moves = DynamicProgramming.ClimbStairs(1);
        }
        
        [Test]
        public void ClimbStairsWithMinCost()
        {
            var moves = DynamicProgramming.MinCostClimbingStairs(new List<int> {1,100,1,1,1,100,1,1,100,1});
        }
        
        [Test]
        public void ClimbStairsWithMinCostOptimized()
        {
            var moves = DynamicProgramming.MinCostOfClimbingStairsOptimized(new []{16, 19, 10, 12, 18});
        }
        
        [Test]
        public void HouseRobberTester()
        {
            var moves = DynamicProgramming.HouseRobber(new []{6, 7, 1, 3, 8, 2, 4});
        }
        
        [Test]
        public void HouseRobber2Tester()
        {
            var moves = DynamicProgramming.HouseRobber2(new []{1,2,3,5});
        }
        
        [Test]
        public void HouseRobber2Tester2()
        {
            var moves = DynamicProgramming.HouseRobber2(new []{1,2,3,5});
        }

        [Test]
        public void CoinChangeTester()
        {
            var coins = DynamicProgramming.CoinChange(new[] {186, 419, 83, 408}, 6249);
        }

        [Test]
        public void WordBreakerTester()
        {
            DynamicProgramming.PrintBrokenWords("microsofthiring", new[] {"micro", "soft", "microsoft", "hi", "ring", "hiring"}, string.Empty);
        }

        [Test]
        public void LISTester()
        {
            var length = DynamicProgramming.PrintLongestIncreasingSubsequence(new[] {0, 1, 0, 3, 2, 3});
        }

        [Test]
        public void SubSetSumTester()
        {
            var doesExist = DynamicProgramming.IsSubSetSum(new[] {2, 3, 1, 1}, 4);
        }

        [Test]
        public void UniquePathTester()
        {
            int m = 3, n = 7;
            var paths = DynamicProgramming.UniquePaths(m-1, n-1);
        }

        [Test]
        public void LongestCommonSubsequenceTester()
        {
            var pathLength = DynamicProgramming.LongestCommonSubsequence("abcde", "ace");
        }

        [Test]
        public void CoinChangeCombinationsTester()
        {
            var coinChangeCombinationCount = DynamicProgramming.CoinChangeCombinations(new[] {1, 2, 5}, 5);
        }
    }
}