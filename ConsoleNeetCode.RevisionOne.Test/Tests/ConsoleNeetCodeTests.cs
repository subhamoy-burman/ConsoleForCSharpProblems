using System.Collections.Generic;
using System.Reflection;
using ConsoleNeetCode.RevisionOne.Graphs;
using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(2,2)]
        [TestCase(3,3)]
        
        public void TestClimbingStairsRecursion(int input, int expectedResult)
        {
            var stairs = DynamicProgramming.DynamicProgramming.ClimbingStairsRecursionCount(input);
            Assert.AreEqual(stairs,expectedResult);
        }

        [Test]
        [TestCase(new int[] {1,2,3,1},4)]
        [TestCase(new int[] {2,7,9,3,1},12)]
        public void TestHouseRobber(int[] arr, int expectedResult)
        {
            var maxRobbed = DynamicProgramming.DynamicProgramming.HouseRobber(arr);
            Assert.AreEqual(maxRobbed, expectedResult);
        }
        
        [Test]
        [TestCase(new int[] {1,2,3,1},4)]
        [TestCase(new int[] {2,7,9,3,1},12)]
        public void TestHouseRobberDp(int[] arr, int expectedResult)
        {
            var maxRobbed = DynamicProgramming.DynamicProgramming.HouseRobberDP(arr);
            Assert.AreEqual(maxRobbed, expectedResult);
        }
        
        [Test]
        [TestCase(new int[] {1,2,3,1},4)]
        [TestCase(new int[] {2,7,9,3,1},12)]
        public void TestHouseRobberMemo(int[] arr, int expectedResult)
        {
            var maxRobbed = DynamicProgramming.DynamicProgramming.HouseRobberMemo(arr);
            Assert.AreEqual(maxRobbed, expectedResult);
        }

        [Test]
        [TestCase("abcde","ace",3)]
        [TestCase("abc","abc",3)]
        [TestCase("abc","def",0)] 
        public void TestLCS(string s1, string s2, int expectedResult)
        {
            Assert.AreEqual(expectedResult, DynamicProgramming.DynamicProgramming.LongestCommonSubsequence(s1,s2));
        }

        [Test]
        public void TestNinjaTraining()
        {
            int[,] inputArray = new int[,] {{1, 2, 5}, {3, 1, 1}, {3, 3, 3}};
            Assert.AreEqual(11, DynamicProgramming.DynamicProgramming.NinjasTraining(inputArray));
        }
        
        [Test]
        public void TestLongestCommonSubstring()
        {
            var s1 = "ABCXYZAY";
            var s2 = "XYZABCB";
            
            Assert.AreEqual(4, DynamicProgramming.DynamicProgramming.LongestCommonSubstring(s1,s2));
        }
        
        [Test]
        public void TestLongestCommonSubstringDP()
        {
            var s1 = "ABCXYZAY";
            var s2 = "XYZABCB";
            
            Assert.AreEqual(4, DynamicProgramming.DynamicProgramming.LongestCommonSubstring(s1,s2));
        }

        [Test]
        public void CountNoOfPalindromes()
        {
            Assert.AreEqual(10,DynamicProgramming.DynamicProgramming.NumberOfPalindromicSubstrings("racecar"));
        }
        
        [Test]
        [TestCase(new int[] { 1, 2, 3 },5, true)]
        [TestCase(new int[] { 1, 2, 3 },6, true)]
        [TestCase(new int[] { 1, 2, 3 },7, false)]
        [TestCase(new int[] { },0, true)]
        public void TestSubsetEqualsK(int[] inputArray, int target, bool expectedResult)
        {
            Assert.AreEqual(expectedResult,DynamicProgramming.DynamicProgramming.SubsetSumEqualsK(inputArray, target));
        }

        [Test]
        [TestCase(new int[] { 10,20,30 },new int[] { 60,100,120 }, 50, 220)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 10, 15, 40 }, 6, 65)]
        [TestCase(new int[] { 10, 20, 30 }, new int[] { 60, 100, 120 }, 50, 220)]
        [TestCase(new int[] { 5, 10, 15, 20 }, new int[] { 10, 20, 30, 40 }, 30, 60)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 4, 6, 8, 10 }, 7, 14)]
        [TestCase(new int[] { 5, 10, 15 }, new int[] { 10, 20, 30 }, 12, 20)]
        public void TestKnapsackProblem(int[] weights, int[] values, int targetWeight, int expected)
        {
            Assert.AreEqual(expected,DynamicProgramming.DynamicProgramming.KnapsackProblem(weights, values,targetWeight ));
        }

        [Test]
        [TestCase(new string[] { "apple", "pie", "air", "line" }, "applepieairline",  new string[] { "apple pie air line" })]
        [TestCase(new string[] { "i", "like", "to", "eat", "ice", "cream" }, "iliketoeaticecream",  new string[] { "i like to eat ice cream" })]
        [TestCase(new string[] { "go", "od", "g", "o" }, "good",  new string[] { "go od", "g o od" })]

        public void TestWordBreak(string[] words, string targetWord, string[] expectedResults)
        {
            var result = DynamicProgramming.DynamicProgramming.WordBreak(words, targetWord);

            Assert.That(result.ToArray(), Is.EquivalentTo(expectedResults));
        }

        [Test]
        public void TestGraphMaxAreaIsland()
        {
            int[,] grid = new int[,]
            {
                {0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                {0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0},
                {0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0}
            };

            int expected = 6;

            var result = Graphs.Graphs.MaxAreaOfIsland(grid);
            Assert.AreEqual(expected, result);

        }

        [Test]
        public void TestLongestIncreasingSubsequence()
        {
            int[] inputArray = new[] {10, 9, 2, 5, 3, 7, 101, 18};
            Assert.AreEqual(4,DynamicProgramming.DynamicProgramming.LongestIncreasingSubsequence(inputArray));
        }

        [Test]
        public void TestSurroundedRegion()
        {
            char[,] grid = new char[,]
            {
                { 'X', 'X', 'X', 'X' },
                { 'X', '0', '0', 'X' },
                { 'X', 'X', '0', 'X' },
                { 'X', '0', 'X', 'X' }
            };
            
            Assert.AreEqual(0, Graphs.Graphs.SurroundedRegion(grid));
        }

        [Test]
        public void TestUniquePaths()
        {
            Assert.AreEqual(28, DynamicProgramming.DynamicProgramming.UniqueGridPaths(3,7));
        }

        [Test]
        public void TestAlienDictionary()
        {
            List<string> dict = new List<string>
                {
                    "baa", "abcd", "abca", "cab", "cad"
                }
                ;
            Assert.AreEqual("bdac",Graphs.Graphs.AlienDictionary(dict,4));
        }
        
        
        [Test]
        public void FindItinerary_Example1_ReturnsCorrectItinerary()
        {
            // Arrange
            var listOfTickets = new List<List<string>>()
            {
                new List<string>() { "MUC", "LHR" },
                new List<string>() { "JFK", "MUC" },
                new List<string>() { "SFO", "SJC" },
                new List<string>() { "LHR", "SFO" }
            };

            // Act
            var result = Graphs.Graphs.FindItinerary(listOfTickets);

            // Assert
            CollectionAssert.AreEqual(new List<string>() { "JFK","MUC","LHR","SFO","SJC" }, result);
        }
        
        
        [Test]
        public void MinCostToConnectAllPoints_ShouldReturnCorrectCost()
        {
            // Arrange
            List<GridIndex> points = new List<GridIndex>
            {
                new GridIndex { RowIndex = 0, ColIndex = 0 },
                new GridIndex { RowIndex = 2, ColIndex = 2 },
                new GridIndex { RowIndex = 3, ColIndex = 10 },
                new GridIndex { RowIndex = 5, ColIndex = 2 },
                new GridIndex { RowIndex = 7, ColIndex = 0 }
            };

            int expectedCost = 20;

            // Act
            int actualCost = Graphs.Graphs.MinCostToConnectAllPoints(points);

            // Assert
            Assert.AreEqual(expectedCost, actualCost);
        }
        
        [Test]
        public void PalindromePartitioning_WithNonPalindromeString_ReturnsListOfPalindromes()
        {
            // Arrange
            string inputString = "aab";

            // Act
            var result = DynamicProgramming.DynamicProgramming.PalindromePartitioning(inputString);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.Contains("aa", result);
            Assert.Contains("b", result);
        }
    }
}