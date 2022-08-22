using System.Collections.Generic;
using System.Text;
using ConsoleAppBlind75.RecursionPractice;
using NUnit.Framework;

namespace Blind75.Test
{
    [TestFixture]
    public class RecursionTester
    {
        [Test]
        public void TestRecusrion()
        {
            //RecursionPractice.CountNoOfZeros(30204);
            var zeroCount = RecursionPractice.CountNoOfZeroWithCounter(30204, 0);
        }

        [Test]
        public void TestRecursionIsArraySorted()
        {
            var isArraySorted = RecursionPractice.IsArraySorted(new[] {1, 2, 4, 17, 9, 12});
        }

        [Test]
        public void TestRecursionLinearSearch()
        {
            var elementIndex = RecursionPractice.FindElementInArray(new[] {1, 2, 4, 17, 9, 12}, 17);
        }
        
        [Test]
        public void TestMultipleOccurancesLinearSearch()
        {
            var elementIndex = RecursionPractice.CountMultipleOccurances(new[] {1, 2, 4, 17, 9, 12, 17}, 17,0);
            Assert.AreEqual(RecursionPractice.TargetOccuranceCount,2);
        }
        
        [Test]
        public void TestGetOccurancesIndexLinearSearch()
        {
            var elementIndex = RecursionPractice.GetMultipleOccurancesIndex(new[] {1, 2, 4, 17, 9, 12, 17}, 17,0);
            Assert.AreEqual(elementIndex.Count,2);
        }
        
        [Test]
        public void TestPrintPattern1Iteratively()
        {
            var patten = RecursionPractice.PrintPattern1Iteratively(4);
        }
        
        [Test]
        public void TestPrintPattern1Recursively()
        {
            RecursionPractice.PrintPattern1Recursively(4,0, new StringBuilder());
        }
        
        [Test]
        public void TestPrintPattern2Recursively()
        {
            RecursionPractice.PrintPattern2Recursively(1,0, new StringBuilder());
        }
        
        [Test]
        public void TestBubbleSort()
        {
            var sortedArray = RecursionPractice.BubbleSort(new int[] { 4, 3, 2 , 1});
        }
        
        [Test]
        public void TestBubbleSortRecursion()
        {
            var arr = new int[] {5, 1, 4, 2, 8};
            RecursionPractice.BubbleSortRecursion(arr, arr.Length );
        }
        
        [Test]
        public void TestSkipACharacter()
        {
            var arr = "baccad";
            var result = RecursionPractice.SkipACharacter(arr, "" );
        }
        
        [Test]
        public void TestSkipAWord()
        {
            var arr = "bacapplecad";
            var result = RecursionPractice.SkipAWord(arr, new StringBuilder() );
        }
        
        [Test]
        public void TestPrintSubsets()
        {
            var arr = "abc";
            RecursionPractice.PrintSubsets(arr, "" );
        }
        
        [Test]
        public void TestPrintPermutations()
        {
            RecursionPractice.PrintPermutations("", "abc" );
        }
        
        [Test]
        public void TestCountPermutations()
        {
           var noOfPermutations =  RecursionPractice.CountPermutations("", "abc" );
        }
        
        [Test]
        public void TestFindSubsetsRecursively()
        {
            var noOfPermutations =  RecursionPractice.GetSubsets(new []{ 1, 5, 3} );
        }
        
        [Test]
        public void TestFindPermutationsRecursively()
        {
            var noOfPermutations =  RecursionPractice.PrintPermutations(new []{ 1, 5, 3} );
        }
    }
}