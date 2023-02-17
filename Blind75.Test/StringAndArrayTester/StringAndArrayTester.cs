using ConsoleAppBlind75.StringAndArray;
using NUnit.Framework;

namespace Blind75.Test.StringAndArrayTester
{
    [TestFixture]
    public class StringAndArrayTester
    {
        [Test]
        public void AnagramTester()
        {
            var isAnagram = StringAndArray.IsAnagram("anagram", "nagaram");
        }

        [Test]
        public void FrequencyTopKTester()
        {
            var topK = StringAndArray.TopKFrequentElements(new[] {1, 1, 1, 2, 2, 3}, 2);
        }
    }
}