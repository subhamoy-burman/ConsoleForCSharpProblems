using ConsoleAppBlind75.Maths;
using NUnit.Framework;

namespace Blind75.Test.MathsTests
{
    [TestFixture]
    public class MathsTests
    {
        [Test]
        public void SqrtTests()
        {
            var sqrtVal = DSAMaths.FindSqrt(36);
        }
        
        [Test]
        public void SqrtTests1()
        {
            var sqrtVal = DSAMaths.FindSqrt(40);
        }
        
        [Test]
        public void SqrtTests2()
        {
            var missingNumber = DSAMaths.GetMissingNumber(new int[] { 1,5,2,6,4});
        }
    }
}