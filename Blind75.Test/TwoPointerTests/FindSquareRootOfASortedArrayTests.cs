using System.Linq;
using ConsoleAppBlind75.TwoPointer;
using NUnit.Framework;

namespace Blind75.Test.TwoPointerTests
{
    [TestFixture]
    public class FindSquareRootOfASortedArrayTests
    {
        [Test]
        public void FindSquareRootOfASortedArrayTest1()
        {
            int[] inputArray = new[] { -2, -1, 0, 2, 3 };
            int[] resultArray = new[] {0, 1, 4, 4, 9};

            var testResult = new FindSquaresOfASortedArray().Execute(inputArray);
            bool isEqual = testResult.SequenceEqual(resultArray);
            
            Assert.IsTrue(isEqual);
        }
        
        /*  [-4,-1,0,3,10]
            [-7,-3,2,3,11] 
            [0,1,9,16,100]
            [4,9,9,49,121]*/
        
        [Test]
        public void FindSquareRootOfASortedArrayTest2()
        {
            int[] inputArray = new[] { -7,-3,2,3,11 };
            int[] resultArray = new[] {4,9,9,49,121};

            var testResult = new FindSquaresOfASortedArray().Execute(inputArray);
            bool isEqual = testResult.SequenceEqual(resultArray);
            
            Assert.IsTrue(isEqual);
        }
    }
}