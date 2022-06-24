using ConsoleAppBlind75;
using NUnit.Framework;

namespace Blind75.Test
{
    [TestFixture]
    public class FindIfStringContainsPermutationOfAPatternTest
    {
        [Test]
        public void FindIfStringContainsPermutationOfAPatternTest1()
        {
            var inputString = "oidbcaf";
            var patternString = "abc";

            var isMatched = new FindIfStringContainsPermutationOfAPattern().Execute3(inputString, patternString);
            
            Assert.IsTrue(isMatched);
        }
        
        [Test]
        public void FindIfStringContainsPermutationOfAPatternTest2()
        {
            var inputString = "oidbcaf";
            var patternString = "dc";

            var isMatched = new FindIfStringContainsPermutationOfAPattern().Execute3(inputString, patternString);
            
            Assert.IsFalse(isMatched);
        }
        
        [Test]
        public void FindIfStringContainsPermutationOfAPatternTest3()
        {
            var inputString = "bcdxabcdy";
            var patternString = "bcdyabcdx";

            var isMatched = new FindIfStringContainsPermutationOfAPattern().Execute3(inputString, patternString);
            
            Assert.IsTrue(isMatched);
        }
        
        [Test]
        public void FindIfStringContainsPermutationOfAPatternTest4()
        {
            var inputString = "aaacb";
            var patternString = "abc";

            var isMatched = new FindIfStringContainsPermutationOfAPattern().Execute3(inputString, patternString);
            
            Assert.IsTrue(isMatched);
        }
        [Test]
        public void FindIfStringContainsPermutationOfAPatternTest5()
        {
            var inputString = "ooolleoooleh";
            var patternString = "hello";

            //var isMatched = new FindIfStringContainsPermutationOfAPattern().Execute(inputString, patternString);
            var isMatched2 = new FindIfStringContainsPermutationOfAPattern().Execute3(inputString, patternString);
            
            //Assert.IsTrue(isMatched);
            Assert.IsFalse(isMatched2);

        }
    }
}