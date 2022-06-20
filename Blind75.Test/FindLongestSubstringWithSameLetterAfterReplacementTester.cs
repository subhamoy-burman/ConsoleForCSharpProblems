using ConsoleAppBlind75;
using NUnit.Framework;

namespace Blind75.Test
{
    [TestFixture]
    public class FindLongestSubstringWithSameLetterAfterReplacementTester
    {
        [Test]
        public void FindLongestSubstringWithSameLetterAfterReplacementTester1()
        {
            char[] charArray = new[] {'a', 'a', 'b', 'c', 'c', 'b', 'b'};
            var result = new FindLongestSubstringWithSameLetterAfterReplacement().Execute(charArray, 2);
            
            Assert.AreEqual(result,5);
        }
        
        [Test]
        public void FindLongestSubstringWithSameLetterAfterReplacementTester2()
        {
            char[] charArray = new[] {'a', 'b', 'b', 'c', 'b'};
            var result = new FindLongestSubstringWithSameLetterAfterReplacement().Execute(charArray, 1);
            
            Assert.AreEqual(result,4);
        }
        
        [Test]
        public void FindLongestSubstringWithSameLetterAfterReplacementTester3()
        {
            char[] charArray = new[] {'a', 'b', 'c', 'c', 'd', 'e'};
            var result = new FindLongestSubstringWithSameLetterAfterReplacement().Execute(charArray, 1);
            
            Assert.AreEqual(result,3);
        }
    }
}