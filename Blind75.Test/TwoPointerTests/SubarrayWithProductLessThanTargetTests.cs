using ConsoleAppBlind75.TwoPointer;
using NUnit.Framework;

namespace Blind75.Test.TwoPointerTests
{
    [TestFixture]
    public class SubarrayWithProductLessThanTargetTests
    {
        [Test]
        public void SubarrayWithProductLessThanTargetTests1()
        {
            int[] array = new[] {2, 5, 3, 10};
            var result = new SubarrayWithProductLessThanTarget().Execute(array, 30);
            Assert.AreEqual(result.Count, 6);
        }
        
        [Test]
        public void SubarrayWithProductLessThanTargetTests2()
        {
            int[] array = new[] {8, 2, 6, 5};
            var result = new SubarrayWithProductLessThanTarget().Execute(array, 50);
            Assert.AreEqual(result.Count, 7);
        }
    }
}