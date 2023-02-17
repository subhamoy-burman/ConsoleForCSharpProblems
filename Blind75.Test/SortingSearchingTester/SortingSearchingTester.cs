using ConsoleAppBlind75.SortingSearching;
using NUnit.Framework;

namespace Blind75.Test.SortingSearchingTester
{
    [TestFixture]
    public class SortingSearchingTester
    {
        [Test]
        public void TestSelectionSort()
        {
            int[] inputArray = new[] {64, 25, 12, 22, 11};
            var sortedArray = SortingSearching.SelectionSort(inputArray);
        }
    }
}