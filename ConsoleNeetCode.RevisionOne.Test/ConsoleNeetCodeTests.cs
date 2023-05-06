using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(2,2)]
        [TestCase(3,3)]
        
        public void TestClimbingStairsRecursion(int input, int expectedResult)
        {
            var stairs = DynamicProgramming.DynamicProgramming.ClimbingStairsRecursionCount(input);
            Assert.AreEqual(stairs,expectedResult);
        }
    }
}