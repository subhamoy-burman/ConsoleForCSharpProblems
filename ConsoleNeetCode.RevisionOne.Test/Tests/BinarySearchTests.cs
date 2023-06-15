using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test;

[TestFixture]
public class BinarySearchTests
{

    [Test]
    public void TestUpperBound()
    {
        Assert.AreEqual(3, 
            BinarySearch.BinarySearch.FindUpperBound(new []{2,3,6,7,8,8,11,11,12}, 6));
    }
    
    
    [Test]
    public void TestLowerBound()
    {
        Assert.AreEqual(3, 
            BinarySearch.BinarySearch.FindLowerBound(new []{1,2,3,3,7,8,9,9,9,11}, 1));
    }
    
    
    [Test]
    public void TestFirstAndLastOccurrence_ExistingTarget_ReturnsCorrectIndices()
    {
        // Arrange
        int[] arr = { 1, 2, 2, 2, 3, 4, 5 };
        int target = 2;

        // Act
        var result = BinarySearch.BinarySearch.FirstAndLastOccurenceBinarySearch(arr, target);

        // Assert
        Assert.AreEqual(1, result.Item1);  // First occurrence of 2 is at index 1
        Assert.AreEqual(3, result.Item2);  // Last occurrence of 2 is at index 3
    }

    [Test]
    public void TestFirstAndLastOccurrence_NonExistingTarget_ReturnsNegativeIndices()
    {
        // Arrange
        int[] arr = { 1, 2, 3, 4, 5 };
        int target = 6;

        // Act
        var result = BinarySearch.BinarySearch.FirstAndLastOccurenceBinarySearch(arr, target);

        // Assert
        Assert.AreEqual(-1, result.Item1);  // Target 6 does not exist in the array, so first occurrence should be -1
        Assert.AreEqual(-1, result.Item2);  // Target 6 does not exist in the array, so last occurrence should be -1
    }

    [Test]
    public void TestFirstAndLastOccurrence_EmptyArray_ReturnsNegativeIndices()
    {
        // Arrange
        int[] arr = { };
        int target = 2;

        // Act
        var result = BinarySearch.BinarySearch.FirstAndLastOccurenceBinarySearch(arr, target);

        // Assert
        Assert.AreEqual(-1, result.Item1);  // Empty array, so first occurrence should be -1
        Assert.AreEqual(-1, result.Item2);  // Empty array, so last occurrence should be -1
    }
}