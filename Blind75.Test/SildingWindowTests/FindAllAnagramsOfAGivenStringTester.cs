using ConsoleAppBlind75;
using NUnit.Framework;

namespace Blind75.Test
{
    [TestFixture]
    public class FindAllAnagramsOfAGivenStringTester
    {
        [Test]
        public void FindAllAnagramsOfAGivenStringTester1()
        {
            string sourceString = "ppqp";
            string patternString = "pq";

            int anagramCount = new FindAllAnagramsOfAGivenString().Execute(sourceString, patternString);
            
            Assert.AreEqual(anagramCount,2);
        }
        
        [Test]
        public void FindAllAnagramsOfAGivenStringTester2()
        {
            string sourceString = "abbcabc";
            string patternString = "abc";

            int anagramCount = new FindAllAnagramsOfAGivenString().Execute(sourceString, patternString);
            
            Assert.AreEqual(anagramCount,3);
        }
        
        //"cbaebabacd"
        //"abc"
        
        [Test]
        public void FindAllAnagramsOfAGivenStringTester3()
        {
            string sourceString = "cbaebabacd";
            string patternString = "abc";

            int anagramCount = new FindAllAnagramsOfAGivenString().Execute(sourceString, patternString);
            
            Assert.AreEqual(anagramCount,2);
        }
        
        //"aaaaaaaaaa"
        //"aaaaaaaaaaaaa"
        [Test]
        public void FindAllAnagramsOfAGivenStringTester4()
        {
            string sourceString = "aaaaaaaaaa";
            string patternString = "aaaaaaaaaaaaa";

            int anagramCount = new FindAllAnagramsOfAGivenString().Execute(sourceString, patternString);
            
            Assert.AreEqual(anagramCount,2);
        }

    }
}