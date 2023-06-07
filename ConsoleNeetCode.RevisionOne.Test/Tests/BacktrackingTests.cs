using System.Collections.Generic;
using ConsoleNeetCode.RevisionOne.DynamicProgramming;
using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test
{
    [TestFixture]
    public class BacktrackingTests
    {
        [Test]
        public void GetCombinationSum_WithValidInput_ReturnsCorrectCombinations()
        {
            // Arrange
            int[] arr = { 2, 3, 6, 7 };
            int k = 7;
            List<List<int>> expected = new List<List<int>>()
            {
                new List<int>() { 2, 2, 3 },
                new List<int>() { 7 }
            };

            // Act
            List<List<int>> result = Backtracking.GetCombinationSum(arr, k);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void SubsetSumTest()
        {
            var result = Backtracking.SubSetSum(new int[] {3, 1, 4});
        }
    }
}