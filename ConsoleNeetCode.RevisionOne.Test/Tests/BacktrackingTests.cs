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
        
        [Test]
        public void TestPrintAllPermutations()
        {
            int[] nums = { 1, 2, 3 };
            List<List<int>> expected = new List<List<int>>()
            {
                new List<int>(){1,2,3},
                new List<int>(){1,3,2},
                new List<int>(){2,1,3},
                new List<int>(){2,3,1},
                new List<int>(){3,1,2},
                new List<int>(){3,2,1}
            };
            var actual = Backtracking.PrintAllPermutations(nums);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}