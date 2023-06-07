using System.Collections.Generic;
using ConsoleNeetCode.RevisionOne.Trees;
using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test
{
    public class BinaryTree
    {
        public TreeNode Root { get; set; }

        public BinaryTree(int[] values)
        {
            if (values == null || values.Length == 0)
            {
                Root = null;
                return;
            }

            Root = BuildTree(values, 0);
        }

        private TreeNode BuildTree(int[] values, int index)
        {
            if (index >= values.Length)
                return null;

            TreeNode node = new TreeNode(values[index])
            {
                Left = BuildTree(values, 2 * index + 1),
                Right = BuildTree(values, 2 * index + 2)
            };

            return node;
        }
    }
    public class TreesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInvertBinaryTree()
        {
            int[] values = { 4, 2, 7, 1, 3, 6, 9 };
            BinaryTree binaryTree = new BinaryTree(values);
            TreeNode root = binaryTree.Root;

            var invertedTree = Trees.Trees.InvertBinaryTree(root);
        }
        
        [Test]
        public void TestInvertBinaryTree2()
        {
            int[] values = { 2,1,3 };
            BinaryTree binaryTree = new BinaryTree(values);
            TreeNode root = binaryTree.Root;

            var invertedTree = Trees.Trees.InvertBinaryTree(root);
        }
        
        [Test]
        public void PrintBoundaryTraversal_ShouldReturnCorrectBoundaryNodes()
        {
            // Arrange
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Left.Left = new TreeNode(3);
            root.Left.Right = new TreeNode(4);
            root.Left.Right.Left = new TreeNode(5);
            root.Left.Right.Right = new TreeNode(6);
            root.Right = new TreeNode(7);
            root.Right.Left = new TreeNode(8);
            root.Right.Right = new TreeNode(9);

            List<int> expectedBoundary = new List<int>() { 1, 2, 3, 5, 6, 8, 9 };

            // Act
            List<int> actualBoundary = Trees.Trees.PrintBoundaryTraversal(root);

            // Assert
            CollectionAssert.AreEqual(expectedBoundary, actualBoundary);
        }

        [Test]
        public void PrintRootToNodePathTest()
        {
            TreeNode root = new TreeNode(1)
            {
                Left = new TreeNode(2),
                Right = new TreeNode(3)
            };
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            root.Right.Left = new TreeNode(6);
            root.Right.Right = new TreeNode(7);

            List<int> trees = Trees.Trees.RootToNodePath(root, 7);
        }
        
        
        [Test]
        public void GoodNodes_ReturnsCorrectResult()
        {
            // Arrange
            TreeNode root = new TreeNode(3);
            root.Left = new TreeNode(1);
            root.Right = new TreeNode(4);
            root.Left.Left = new TreeNode(3);
            root.Right.Left = new TreeNode(1);
            root.Right.Right = new TreeNode(5);

            List<int> expected = new List<int> { 3, 4, 5 };

            // Act
            List<int> result = Trees.Trees.GoodNodes(root);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
        
        [Test]
        public void GoodNodes_ReturnsCorrectResult2()
        {
            // Arrange
            TreeNode root = new TreeNode(3)
            {
                Left = new TreeNode(3)
                {
                    Right = new TreeNode(4)
                    {
                        Left = new TreeNode(2)
                    }
                }
            };

            List<int> expected = new List<int> { 3 };

            // Act
            List<int> result = Trees.Trees.GoodNodes(root);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
        
        [Test]
        public void BuildTreeFromInorderAndPreOrder_ReturnsCorrectTree()
        {
            // Arrange
            int[] preOrder = { 1, 2, 4, 5, 3, 6 };
            int[] inOrder = { 4, 2, 5, 1, 6, 3 };

            // Act
            TreeNode result = Trees.Trees.BuildTreeFromInorderAndPreOrder(preOrder, inOrder);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Value);
            Assert.NotNull(result.Left);
            Assert.AreEqual(2, result.Left.Value);
            Assert.NotNull(result.Right);
            Assert.AreEqual(3, result.Right.Value);
            Assert.NotNull(result.Left.Left);
            Assert.AreEqual(4, result.Left.Left.Value);
            Assert.NotNull(result.Left.Right);
            Assert.AreEqual(5, result.Left.Right.Value);
            Assert.NotNull(result.Right.Left);
            Assert.AreEqual(6, result.Right.Left.Value);
        }
        
        
        [Test]
        public void Serialize_ReturnsCorrectSerializationString()
        {
            // Arrange
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Right.Left = new TreeNode(4);
            root.Right.Right = new TreeNode(5);

            // Act
            var result = Trees.Trees.SerializeAndDeserialize(root);

            // Assert
            //List<string> expected = new List<string> { "1", "2", "3", "#", "#", "4", "5", "#", "#" };
            //Assert.AreEqual(expected, result);
        }
    }
}