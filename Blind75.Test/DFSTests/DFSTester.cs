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
            
            new DFSTraversal().TraverseTree(node);
        }
    }
}