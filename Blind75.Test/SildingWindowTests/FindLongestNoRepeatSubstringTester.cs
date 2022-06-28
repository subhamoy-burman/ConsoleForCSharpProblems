using ConsoleAppBlind75;
using NUnit.Framework;

namespace Blind75.Test
{
    [TestFixture]

    public class FindLongestNoRepeatSubstringTester
    {
        [Test]
        public void TestFindLongestNoRepeatSubstring1()
        {
            char[] inputArray = new[] {'a', 'a', 'b', 'c', 'c', 'b', 'b'};
            int maxLengthResult = new FindLongestNoRepeatSubstring().Execute(inputArray);
            
            Assert.AreEqual(3,maxLengthResult);
        }
        
        [Test]
        public void TestFindLongestNoRepeatSubstring2()
        {
            char[] inputArray = new[] {'a', 'b', 'b', 'b', 'b'};
            int maxLengthResult = new FindLongestNoRepeatSubstring().Execute(inputArray);
            
            Assert.AreEqual(2,maxLengthResult);
        }

        [Test]
        public void TestFindLongestNoRepeatSubstring3()
        {
            char[] inputArray = new[] {'a', 'b', 'c', 'c', 'd', 'e'};
            int maxLengthResult = new FindLongestNoRepeatSubstring().Execute(inputArray);
            
            Assert.AreEqual(3,maxLengthResult);
        }
    }
}