using ConsoleAppBlind75;
using NUnit.Framework;

namespace Blind75.Test
{
    [TestFixture]
    public class SlidingWindowTester
    {
        [Test]
        public void TestMinSubArrayLen()
        {
            var subArrayLen = SlidingWindow.MinSubArrayLen(7, new int[] {2,3,1,2,4,3});
        }

        [Test]
        public void TestLongestSubStringWithKDistinctElement()
        {
            var longestSubstr = SlidingWindow.LongestSubstringWithNoMoreThanKDistinct("araaci", 2);
        }

        [Test]
        public void TestPalindrome()
        {
            var isIncluded = SlidingWindow.CheckInclusion("hello", "ooolleoooleh");
        }
    }
}