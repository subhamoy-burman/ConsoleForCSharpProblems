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
            RecursionPractice.PrintPattern1Iteratively(4);
        }
    }
}