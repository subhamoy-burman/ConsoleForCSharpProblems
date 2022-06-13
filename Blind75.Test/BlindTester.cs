using ConsoleAppBlind75;
using NUnit.Framework;

namespace Blind75.Test
{
    [TestFixture]  
    public class BlindTester
    {

        [Test]
        public void TestFindSmallestSubArrayOfGivenSum1()
        {
            var instance = new FindSmallestSubArrayOfGivenSum();

            var result = instance.Execute(new int[] {2, 1, 5, 2, 3, 2}, 7);
            Assert.AreEqual(result,2);
        }
        
        [Test]
        public void TestFindSmallestSubArrayOfGivenSum2()
        {
            var instance = new FindSmallestSubArrayOfGivenSum();

            var result = instance.Execute(new int[] {2, 1, 5, 2, 8}, 7);
            Assert.AreEqual(result,1);
            
        }
        
        [Test]
        public void TestFindSmallestSubArrayOfGivenSum3()
        {
            var instance = new FindSmallestSubArrayOfGivenSum();

            var result = instance.Execute(new int[] {3, 4, 1, 1, 6}, 8);
            Assert.AreEqual(result,3);
            
        }
    }
}