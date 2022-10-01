using ConsoleAppBlind75;
using NUnit.Framework;

namespace Blind75.Test.TreeDSTester
{
    [TestFixture]
    public class TreeDSTester
    {
        [Test]
        public void LevelOrderTester()
        {
            TreeNode tree = new TreeNode(1)
            {
                Left = new TreeNode(2),
                Right = new TreeNode(3)
            };
            tree.Left.Left = new TreeNode(4);
            tree.Left.Right = new TreeNode(5);

            var levelOrderList = Trees.GetLevelOrderTraversal(tree);
        }

        [Test]
        public void PreOrderIterativeTester()
        {
            TreeNode tree = new TreeNode(1)
            {
                Left = new TreeNode(2),
                Right = new TreeNode(7)
            };

            tree.Left.Left = new TreeNode(3);
            tree.Left.Right = new TreeNode(4);

            tree.Left.Right.Left = new TreeNode(5);
            tree.Left.Right.Right = new TreeNode(6);

            var preOrderList = Trees.PreOrderIterativeTraversal(tree);
        }

        [Test]
        public void InOrderIterativeTester()
        {
            TreeNode tree = new TreeNode(1)
            {
                Left = new TreeNode(2),
                Right = new TreeNode(3)
            };

            tree.Left.Left = new TreeNode(4);
            tree.Left.Right = new TreeNode(5);

            tree.Left.Right.Left = new TreeNode(6);
            tree.Left.Right.Right = new TreeNode(7);

            var inorderList = Trees.InOrderTraversalIterative(tree);
        }

        [Test]
        public void TreeDiameterTester()
        {
            TreeNode tree = new TreeNode(1);
            tree.Left = new TreeNode(2);
            tree.Right = new TreeNode(3);
            tree.Left.Left = new TreeNode(4);
            tree.Left.Right = new TreeNode(5);
            

            int diameter = Trees.GetDiameterOfABinaryTree(tree);
        }
        
        [Test]
        public void TreeZigZagTester()
        {
            TreeNode tree = new TreeNode(1);
            tree.Left = new TreeNode(2);
            tree.Right = new TreeNode(3);
            tree.Left.Left = new TreeNode(4);
            tree.Left.Right = new TreeNode(5);
            tree.Right.Left = new TreeNode(6);

            var listOfValues = Trees.PrintZigZagTraversal(tree);
        }
        
        [Test]
        public void TreeBoundaryTester()
        {
            TreeNode tree = new TreeNode(1);
            tree.Left = new TreeNode(2);
            tree.Right = new TreeNode(7);
            tree.Left.Left = new TreeNode(3);
            tree.Left.Left.Right = new TreeNode(4);
            tree.Left.Left.Right.Left = new TreeNode(5);
            tree.Left.Left.Right.Right = new TreeNode(6);

            tree.Right.Right = new TreeNode(8);
            tree.Right.Right.Left = new TreeNode(9);

            tree.Right.Right.Left.Left = new TreeNode(10);
            tree.Right.Right.Left.Right = new TreeNode(11);

            var listOfValues = Trees.PrintBoundaryOfTree(tree);
        }

        [Test]
        public void TreeVerticalTester()
        {
            TreeNode tree = new TreeNode(1);
            tree.Left = new TreeNode(2);
            tree.Right = new TreeNode(7);
            tree.Left.Left = new TreeNode(3);
            tree.Left.Left.Right = new TreeNode(4);
            tree.Left.Left.Right.Left = new TreeNode(5);
            tree.Left.Left.Right.Right = new TreeNode(6);

            tree.Right.Right = new TreeNode(8);
            tree.Right.Right.Left = new TreeNode(9);

            tree.Right.Right.Left.Left = new TreeNode(10);
            tree.Right.Right.Left.Right = new TreeNode(11);
            var values = Trees.VerticalTraversalOfATree(tree);
        }

        [Test]
        public void TreePathToNodeTester()
        {
            TreeNode tree = new TreeNode(1)
            {
                Left = new TreeNode(2),
                Right = new TreeNode(3)
            };

            tree.Left.Left = new TreeNode(4);
            tree.Left.Right = new TreeNode(5)
            {
                Left = new TreeNode(6),
                Right = new TreeNode(7)
            };

            var path = Trees.PathFinder(tree, 7);
        }

        [Test]
        public void TreeMaximumWidth()
        {
            TreeNode tree = new TreeNode(1)
            {
                Left = new TreeNode(3),
                Right = new TreeNode(2)
            };

            tree.Left.Left = new TreeNode(5);
            tree.Left.Right = new TreeNode(3);

            tree.Right.Right = new TreeNode(9);

            int maxLength = Trees.GetMaxWidthOfATree(tree);
        }
    }
}