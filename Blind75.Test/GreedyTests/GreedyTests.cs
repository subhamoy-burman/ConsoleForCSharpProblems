using ConsoleAppBlind75.Greedy;
using NUnit.Framework;

namespace Blind75.Test.GreedyTests
{
    [TestFixture]
    public class GreedyTests
    {
        [Test]
        public void MaxSubarrayTest()
        {
            var maxSum = Greedy.MaxSubArraySum(new int[] { 5,4,-1,7,8 });
        }

        [Test]
        public void CanJumpTest()
        {
            var isJumpPossible = Greedy.JumpGameGreedy(new int[] {2,3,1,1,4});
        }

        [Test]
        public void NumberOfJumpsTest()
        {
            var numberOfJumps = Greedy.MinNoOfJumpsRequired(new int[] {2,3,0,1,4});
        }

        [Test]
        public void TestValidParenthesis()
        {
            var isValid = Greedy.CheckValidParenthesis("(*))");
        }
        
        [Test]
        public void TestValidParenthesisWithStar()
        {
            var isValid = Greedy.CheckValidParenthesisWithStar("(");
        }
    }
}