using ConsoleAppBlind75.TwoPointer;
using NUnit.Framework;

namespace Blind75.Test.TwoPointerTests
{
    [TestFixture]
    public class CountDuplicateTests
    {
        [Test]
        public void CountDuplicateTester1()
        {
            int[] inputArray = new[] {2, 3, 3, 3, 6, 9, 9};
            int resultCount = new CountDuplicates().Execute(inputArray);
            
            Assert.AreEqual(resultCount,3);
        }
        
        [Test]
        public void CountDuplicateTester2()
        {
            int[] inputArray = new[] {2, 2, 2, 11};
            int resultCount = new CountDuplicates().Execute(inputArray);
            
            Assert.AreEqual(resultCount,2);
        }
        
        [Test]
        public void CountDuplicateTester3()
        {
            int[] inputArray = new[] {1,1,2};
            int resultCount = new CountDuplicates().Execute2(inputArray);
            
            Assert.AreEqual(resultCount,2);
        }
        
        /*
        [1,1,2]
        [0,0,1,1,1,2,2,3,3,4]
        */
        [Test]
        public void CountDuplicateTester4()
        {
            int[] inputArray = new[] {0,0,1,1,1,2,2,3,3,4};
            int resultCount = new CountDuplicates().Execute2(inputArray);
            
            Assert.AreEqual(resultCount,2);
        }
    }
}