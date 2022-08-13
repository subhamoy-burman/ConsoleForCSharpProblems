using System.Reflection.Metadata.Ecma335;
using ConsoleAppBlind75.BFS;
using ConsoleAppBlind75.DFS;
using NUnit.Framework;

namespace Blind75.Test.DFSTests
{
    [TestFixture]
    public class DFSTester
    {

        [Test]
        public void DFSTester1()
        {
            TreeNode node = new TreeNode(12);
            node.Left = new TreeNode(7);
            node.Right = new TreeNode(1);
            node.Left.Left = new TreeNode(9);
            node.Right.Left = new TreeNode(10);
            node.Right.Right = new TreeNode(5);
            
            //new DFSTraversal().TraverseTree(node);
        }
        
        [Test]
        public void DFSTester2()
        {
            TreeNode node = new TreeNode(5);
            node.Left = new TreeNode(4);
            node.Right = new TreeNode(8);
            node.Left.Left = new TreeNode(11);
            node.Left.Left.Left = new TreeNode(7);
            node.Left.Left.Right = new TreeNode(2);
            node.Right.Left = new TreeNode(13);
            node.Right.Right = new TreeNode(4);
            node.Right.Right.Left = new TreeNode(5);
            node.Right.Right.Right = new TreeNode(1);

            //var pathSum = DFSTraversal.GetPathsImplementation2(node, 22);
            
            var pathSum = DFSTraversal.FindAllPathToLeaf(node);

            //new DFSTraversal().TraverseTree(node);
        }
    }
}