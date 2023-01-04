using ConsoleAppBlind75.BinarySearchTree;
using NUnit.Framework;

namespace Blind75.Test.BSTTester
{
    [TestFixture]
    public class BSTTester
    {
        [Test]
        public void TestBSTConstruct()
        {
            int[] arr = new[] {12, 25, 37, 50, 62, 75, 87};
            var constructBST = BinarySearchTree.NodeConstruct(arr, 0, arr.Length - 1);
            //var replacedBST = 
            BinarySearchTree.ReplaceWithSumLarger(constructBST);
        }

        [Test]
        public void TestBSTLCA()
        {
            BinarySearchTree.Node tree = new BinarySearchTree.Node(20);
            tree.Left = new BinarySearchTree.Node(8);
            tree.Right = new BinarySearchTree.Node(22);
            tree.Left.Left = new BinarySearchTree.Node(4);
            tree.Left.Right = new BinarySearchTree.Node(12);
            tree.Left.Right.Left = new BinarySearchTree.Node(10);
            tree.Left.Right.Right = new BinarySearchTree.Node(14);

            BinarySearchTree.Node resultNode = BinarySearchTree.FindLCAOfBST(tree, 10, 14);         
        }
        
        [Test]
        public void PrintBSTInRange()
        {
            BinarySearchTree.Node tree = new BinarySearchTree.Node(20);
            tree.Left = new BinarySearchTree.Node(8);
            tree.Right = new BinarySearchTree.Node(22);
            tree.Left.Left = new BinarySearchTree.Node(4);
            tree.Left.Right = new BinarySearchTree.Node(12);
         

            BinarySearchTree.PrintRange(tree, 10, 25);         
        }
    }
}