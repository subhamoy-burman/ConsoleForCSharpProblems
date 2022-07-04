using ConsoleAppBlind75.TwoPointer;
using NUnit.Framework;

namespace Blind75.Test.TwoPointerTests
{
    [TestFixture]
    public class TripletWithSmallerSumTests
    {
        [Test]
        public void TripletWithSmallerSumTests1()
        {
            int[] arr = new[] {-1, 0, 2, 3};
            int targetSum = 3;

            int noOfTriplets = new TripletWithSmallerSum().Execute(arr, targetSum);
            
            Assert.AreEqual(noOfTriplets, 2);
        }
    }
}