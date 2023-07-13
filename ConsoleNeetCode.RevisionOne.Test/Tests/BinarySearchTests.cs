using ConsoleNeetCode.RevisionOne.Trees;
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
    
    [Test]
    public void SearchInRotatedSortedArray_ReturnsCorrectIndex()
    {
        // Arrange
        int[] arr = { 4, 5, 6, 7, 0, 1, 2 };
        int target = 0;
        int expectedIndex = 4;

        // Act
        int actualIndex = BinarySearch.BinarySearch.SearchInRotatedSortedArray(arr, target);

        // Assert
        Assert.AreEqual(expectedIndex, actualIndex);
    }

    [Test]
    public void SearchInRotatedSortedArray_ReturnsMinusOneForNotFound()
    {
        // Arrange
        int[] arr = { 4, 5, 6, 7, 0, 1, 2 };
        int target = 8;
        int expectedIndex = -1;

        // Act
        int actualIndex = BinarySearch.BinarySearch.SearchInRotatedSortedArray(arr, target);

        // Assert
        Assert.AreEqual(expectedIndex, actualIndex);
    }
    
    [Test]
    public void DeleteBSTNode_DeletesNodeFromBST()
    {
        // Create a sample BST
        BinarySearchTree.BSTNode root = new BinarySearchTree.BSTNode(4);
        root.Left = new BinarySearchTree.BSTNode(2);
        root.Right = new BinarySearchTree.BSTNode(6);
        root.Left.Left = new BinarySearchTree.BSTNode(1);
        root.Left.Right = new BinarySearchTree.BSTNode(3);
        root.Right.Left = new BinarySearchTree.BSTNode(5);
        root.Right.Right = new BinarySearchTree.BSTNode(7);

        // Delete a node
        root = BinarySearchTree.DeleteBSTNode(root, 4);

        // Verify the resulting BST
        Assert.AreEqual(5, root.Value);
        Assert.AreEqual(2, root.Left.Value);
        Assert.AreEqual(6, root.Right.Value);
        Assert.AreEqual(1, root.Left.Left.Value);
        Assert.AreEqual(3, root.Left.Right.Value);
        Assert.AreEqual(7, root.Right.Right.Value);
    }
    
    [Test]
    public void BSTKthSmallestNode_ReturnsKthSmallestNodeValue()
    {
        // Arrange
        BinarySearchTree.BSTNode root = new BinarySearchTree.BSTNode(4);
        root.Left = new BinarySearchTree.BSTNode(2);
        root.Right = new BinarySearchTree.BSTNode(6);
        root.Left.Left = new BinarySearchTree.BSTNode(1);
        root.Left.Right = new BinarySearchTree.BSTNode(3);
        root.Right.Left = new BinarySearchTree.BSTNode(5);
        root.Right.Right = new BinarySearchTree.BSTNode(7);

        int k = 3;

        // Act
        int result = BinarySearchTree.BSTKthSmallestNode(root, k);

        // Assert
        Assert.AreEqual(3, result);
    }
}