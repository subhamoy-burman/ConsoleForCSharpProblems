using ConsoleAppBlind75.Subset;
using NUnit.Framework;

namespace Blind75.Test.SubsetTester
{
    [TestFixture]
    public class SubsetTester
    {
        [Test]
        public void TestSubset()
        {
            //Arrange
            var subsetInstance = new FindSubsets();
            //Act
            var subsets = subsetInstance.Execute(new int[] {1, 5, 3});

        }
        
        [Test]
        public void TestSubsetUnique()
        {
            //Arrange
            var subsetInstance = new FindSubsets();
            //Act
            var subsets = subsetInstance.ExecuteGetUnique(new int[] {1, 5, 3, 3});

        }
        
        [Test]
        public void TestPermunations()
        {
            //Arrange
            var subsetInstance = new FindSubsets();
            //Act
            var subsets = subsetInstance.FindPermutations(new int[] {1, 3, 5});

        }
        
        [Test]
        public void TestPermunationsRecursive()
        {
            //Arrange
            var subsetInstance = new FindSubsets();
            //Act
            var subsets = subsetInstance.FindPermutationsRecursive(new int[] {1, 3, 5});

        }
        
        [Test]
        public void TestPermunationsRecursive2()
        {
            //Arrange
            var subsetInstance = new FindSubsets();
            //Act
            var subsets = subsetInstance.FindAllPermutation(new int[] {1, 3, 5});

        }
    }
}