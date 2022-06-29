using ConsoleAppBlind75.TwoPointer;
using NUnit.Framework;

namespace Blind75.Test.TwoPointerTests
{
    [TestFixture]
    public class TargetSumTest
    {
        [Test]
        public void TargetSumTester1()
        {
            int[] arr = new[] {1, 2, 3, 4, 6};
            int targetSum = 6;
            int[] resultArray = new PairWithTargetSum().Execute(arr, targetSum);

            Assert.AreEqual(resultArray[0], 1);
            Assert.AreEqual(resultArray[1], 3);
        }
        
        [Test]
        public void TargetSumTester2()
        {
            int[] arr = new[] {2, 5, 9, 11};
            int targetSum = 11;
            int[] resultArray = new PairWithTargetSum().Execute(arr, targetSum);

            Assert.AreEqual(resultArray[0], 1);
            Assert.AreEqual(resultArray[1], 2);
        }
    }
}