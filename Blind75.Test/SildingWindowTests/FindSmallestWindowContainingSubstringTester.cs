using ConsoleAppBlind75;
using NUnit.Framework;

namespace Blind75.Test
{
    [TestFixture]
    public class FindSmallestWindowContainingSubstringTester
    {
        [Test]
        public void FindSmallestWindowContainingSubstringTester1()
        {
            string sourceString = "ADOBECODEBANC";
            string pattenString = "ABC";

            var smallestString = FindSmallestWindowContainingSubstring.Execute(sourceString, pattenString);
            
            Assert.AreEqual("BANC", smallestString);
        }
    }
}