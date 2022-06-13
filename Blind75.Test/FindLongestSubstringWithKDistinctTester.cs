using ConsoleAppBlind75;
using NUnit.Framework;

namespace Blind75.Test
{
    [TestFixture]
    public class FindLongestSubstringWithKDistinctTester
    {
        [Test]
        public void TestFindLongestSubstringWithKDistinct1()
        {
            char[] testString = {'a', 'r', 'a', 'a', 'c', 'i'};

            int output = new FindLongestSubstringWithKDistinct().Execute(testString, 2);
            
            Assert.AreEqual(4,output);
        }
        
        [Test]
        public void TestFindLongestSubstringWithKDistinct2()
        {
            char[] testString = {'a', 'r', 'a', 'a', 'c', 'i'};

            int output = new FindLongestSubstringWithKDistinct().Execute(testString, 1);
            
            Assert.AreEqual(2,output);
        }
    }
}