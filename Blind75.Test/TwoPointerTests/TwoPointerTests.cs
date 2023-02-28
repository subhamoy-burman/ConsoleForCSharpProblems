using ConsoleAppBlind75.TwoPointer;
using NUnit.Framework;

namespace Blind75.Test.TwoPointerTests
{
    [TestFixture]
    public class TwoPointerTests
    {
        [Test]
        public void TestMinimumWindowSortSubArray()
        {
            //var input = new[] {2, 6, 4, 8, 10, 9, 15 };
            //var input = new[] {1, 2, 3};
            var input = new[] {1, 3, 2, 2, 2};
            var minWindowSize = TwoPointer.FindUnsortedSubarray(input);
        }
    }
}