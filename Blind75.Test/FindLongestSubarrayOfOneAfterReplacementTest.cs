using ConsoleAppBlind75;
using NUnit.Framework;

namespace Blind75.Test
{
    [TestFixture]
    public class FindLongestSubarrayOfOneAfterReplacementTest
    {
        [Test]
        public void FindLongestSubarrayOfOneAfterReplacementTester1()
        {
            int[] intArray = new[] {0 , 1, 1, 0, 0, 0, 1, 1, 0, 1, 1};
            var result = new FindLongestSubarrayOfOneAfterReplacement().Execute(intArray, 2);
            
            Assert.AreEqual(result,6);
        }
        
        [Test]
        public void FindLongestSubarrayOfOneAfterReplacementTester2()
        {
            int[] intArray = new[] {0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1};
            var result = new FindLongestSubarrayOfOneAfterReplacement().Execute(intArray, 3);
            
            Assert.AreEqual(result,9);
        }
    }
}