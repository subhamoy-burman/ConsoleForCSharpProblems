using ConsoleAppBlind75.BinarySearch;
using NUnit.Framework;

namespace Blind75.Test.BinarySearchTester
{
    [TestFixture]
    public class BinarySearchTester
    {
        [Test]
        public void TestSmallestCharacterNearToTargetInArray()
        {
            char[] arrayOfLetters = new char[] {'a', 'b'};
            char target = 'z';
            var result = SmallestLetterGreaterThanTarget.GetSmallestLetterGreaterThanTarget(arrayOfLetters, target);
        }
        
        [Test]
        public void TestSmallestCharacterNearToTargetInArray1()
        {
            char[] arrayOfLetters = new char[] {'c','f','j'};
            char target = 'a';
            var result = SmallestLetterGreaterThanTarget.GetSmallestLetterGreaterThanTarget(arrayOfLetters, target);
        }
        
        [Test]
        public void TestSmallestCharacterNearToTargetInArray2()
        {
            char[] arrayOfLetters = new char[] {'a', 'b'};
            char target = 'z';
            var result = SmallestLetterGreaterThanTarget.GetSmallestLetterGreaterThanTarget(arrayOfLetters, target);
        }
        
        [Test]
        public void TestSmallestCharacterNearToTargetInArray3()
        {
            char[] arrayOfLetters = new char[] {'c','f','j'};
            char target = 'c';
            var result = SmallestLetterGreaterThanTarget.GetSmallestLetterGreaterThanTarget(arrayOfLetters, target);
        }
        
        [Test]
        public void TestSmallestCharacterNearToTargetInArray4()
        {
            char[] arrayOfLetters = new char[] {'c','f','j'};
            char target = 'c';
            var result = SmallestLetterGreaterThanTarget.GetSmallestLetterGreaterThanTarget(arrayOfLetters, target);
        }
        //["e","e","e","e","e","e","n","n","n","n"]
        //"e"
        
        [Test]
        public void TestSmallestCharacterNearToTargetInArray5()
        {
            char[] arrayOfLetters = new char[] {'e','e','e','e','e','e','n','n','n','n'};
            char target = 'e';
            var result = SmallestLetterGreaterThanTarget.GetSmallestLetterGreaterThanTarget(arrayOfLetters, target);
        }
        
        [Test]
        public void TestFirstAndLastIndex()
        {
            int[] arrayOfLetters = new int[] {5, 7,7,7,7,8,8,9};
            int target = 7;
            var result = FindStartEndIndexOfSortedArray.StartEndIndexOfSortedArray(arrayOfLetters, target);
        }
    }
}