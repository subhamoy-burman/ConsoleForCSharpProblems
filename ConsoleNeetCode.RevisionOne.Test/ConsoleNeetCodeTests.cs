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

        [Test]
        [TestCase(new int[] {1,2,3,1},4)]
        [TestCase(new int[] {2,7,9,3,1},12)]
        public void TestHouseRobber(int[] arr, int expectedResult)
        {
            var maxRobbed = DynamicProgramming.DynamicProgramming.HouseRobber(arr);
            Assert.AreEqual(maxRobbed, expectedResult);
        }
        
        [Test]
        [TestCase(new int[] {1,2,3,1},4)]
        [TestCase(new int[] {2,7,9,3,1},12)]
        public void TestHouseRobberDp(int[] arr, int expectedResult)
        {
            var maxRobbed = DynamicProgramming.DynamicProgramming.HouseRobberDP(arr);
            Assert.AreEqual(maxRobbed, expectedResult);
        }
        
        [Test]
        [TestCase(new int[] {1,2,3,1},4)]
        [TestCase(new int[] {2,7,9,3,1},12)]
        public void TestHouseRobberMemo(int[] arr, int expectedResult)
        {
            var maxRobbed = DynamicProgramming.DynamicProgramming.HouseRobberMemo(arr);
            Assert.AreEqual(maxRobbed, expectedResult);
        }
    }
}