using System;
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
    }
}