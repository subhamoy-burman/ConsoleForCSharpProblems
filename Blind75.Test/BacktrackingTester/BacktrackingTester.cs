using System.Collections.Generic;
using ConsoleAppBlind75.Backtracking;
using NUnit.Framework;

namespace Blind75.Test.BacktrackingTester
{
    [TestFixture]
    public class BacktrackingTester
    {
        [Test]
        public void TestMatrixPathPrint()
        {
            Backtracking.PrintAllPaths(3, 3);
        }
        
        [Test]
        public void TestNQueen()
        {
            var nQueen = Backtracking.CountNQueen(4);
        }

        [Test]
        public void TestSubsequenceEqualsSum()
        {
            Backtracking.PrintSubsequencesEqualsSum();
        }
        
        [Test]
        public void TestSubsetLeetcode()
        {
            var subsetList = new List<IList<int>>();
            List<int> localSubset = new List<int>();
            int[] nums = new[] {1, 2, 3};
            
            Backtracking.FuncSubsets(0, subsetList, localSubset, nums);
        }
        
        [Test]
        public void TestCombinationSumLeetcode()
        {
            var subsetList = new List<IList<int>>();
            List<int> localSubset = new List<int>();
            int[] candidates = new[] {2,3,6,7};
            int target = 7;
            Backtracking.FuncCombinations(0, 0, candidates, target, subsetList,localSubset);
            
        }

        [Test]
        public void TestSubsetsUnique()
        {
            var uniqueSets = Backtracking.SubsetUnique(new[] {1, 2, 2});
        }
        
        [Test]
        public void TestSubsetsCombinationUnique()
        {
            var uniqueSets = Backtracking.SubsetCombinationSumUnique(new[] {10,1,2,7,6,1,5},8);
        }

        [Test]
        public void TestPartition()
        {
            var partitionSet = Backtracking.Partition("aabb");
        }
    }
}