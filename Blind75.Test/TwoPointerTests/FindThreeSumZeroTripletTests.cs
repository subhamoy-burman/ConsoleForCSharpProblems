using ConsoleAppBlind75.TwoPointer;
using NUnit.Framework;

namespace Blind75.Test.TwoPointerTests
{
    [TestFixture]
    public class FindThreeSumZeroTripletTests
    {
        [Test]
        public void FindThreeSumZeroTripletTest1()
        {
            int[] arr = { 0, -1, 2, -3, 1 };
            var arrayValue = new FindThreeSumZeroTriplet().ExecuteBruteForce(arr);
            
            Assert.AreEqual(arrayValue,2);

        }
        
        [Test]
        public void FindThreeSumZeroTripletTest2()
        {
            int[] arr = { 0, -1, 2, -3, 1 };
            new FindThreeSumZeroTriplet().ExecuteTwoPointer(arr);
            
            //Assert.AreEqual(arrayValue,2);

        }
    }
}