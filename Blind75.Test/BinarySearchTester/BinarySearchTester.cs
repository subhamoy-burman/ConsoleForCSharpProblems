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
        
        [Test]
        public void TestPeakIndexInMountainArray()
        {
            int[] arrayOfLetters = new int[] {0,10,5,2};
            //int target = 7;
            var index = PeakIndexOfMountainArray.PeakIndexInMountainArray(arrayOfLetters);
        }
        
        //[0,5,3,1]
        //1
        
        //[1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51,53,55,57,59,61,63,65,67,69,71,73,75,77,79,81,83,85,87,89,91,93,95,97,99,101,103,105,107,109,111,113,115,117,119,121,123,125,127,129,131,133,135,137,139,141,143,145,147,149,151,153,155,157,159,161,163,165,167,169,171,173,175,177,179,181,183,185,187,189,191,193,195,197,199,201,199,197,195,193,191,189,187,185,183,181,179,177,175,173,171,169,167,165,163]
        //181
        [Test]
        public void TestFindIndexInMountainArray()
        {
            int[] arrayOfLetters = new int[] {0,5,3,1};
            int target = 1;
            var index = PeakIndexOfMountainArray.FindInMountainArray(arrayOfLetters,target);
        }
        
        [Test]
        public void TestFindIndexInLongMountainArray()
        {
            int[] arrayOfLetters = new int[] {1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51,53,55,57,59,61,63,65,67,69,71,73,75,77,79,81,83,85,87,89,91,93,95,97,99,101,103,105,107,109,111,113,115,117,119,121,123,125,127,129,131,133,135,137,139,141,143,145,147,149,151,153,155,157,159,161,163,165,167,169,171,173,175,177,179,181,183,185,187,189,191,193,195,197,199,201,199,197,195,193,191,189,187,185,183,181,179,177,175,173,171,169,167,165,163};
            int target = 181;
            var index = PeakIndexOfMountainArray.FindInMountainArray(arrayOfLetters,target);
        }

        [Test]
        public void SearchInRotatedArray()
        {
            //int[] input = {4, 5, 6, 7, 8, 0, 1, 3};
            //int[] input = {3, 4, 5, 1, 2};
            //int[] input = {4, 5, 6, 7, 0, 1, 2};
            //int[] input = {11, 13, 15, 17};
            int[] input = {1,2};

            var min = BinarySearchProgram.FindMinimumInRotatedSortedArray(input);
        }
    }
}