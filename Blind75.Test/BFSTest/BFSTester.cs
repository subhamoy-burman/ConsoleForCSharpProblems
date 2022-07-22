using System.Collections.Generic;
using System.Linq;
using ConsoleAppBlind75.BFS;
using NUnit.Framework;

namespace Blind75.Test.BFS
{
    [TestFixture]
    public class BFSTester
    {
        [Test]
        public void BFSTester1()
        {
            TreeNode root = new TreeNode(12)
            {
                Left = new TreeNode(7),
                Right = new TreeNode(1)
            };
            root.Left.Left = new TreeNode(9);
            root.Right.Left = new TreeNode(10);
            root.Right.Right = new TreeNode(5);

            var resultList = new LevelOrderTraverse().Execute(root);
            
            Assert.AreEqual(resultList.FirstOrDefault().FirstOrDefault(), 12);
        }
        
        [Test]
        public void BFSTester2()
        {
            TreeNode root = new TreeNode(12)
            {
                Left = new TreeNode(7),
                Right = new TreeNode(1)
            };
            root.Left.Left = new TreeNode(9);
            root.Right.Left = new TreeNode(10);
            root.Right.Right = new TreeNode(5);

            var resultList = new LevelOrderReverseTraverse().Execute(root);
            
            Assert.AreEqual(resultList.FirstOrDefault().FirstOrDefault(), 9);
        }
        
        [Test]
        public void BFSTester3()
        {
            TreeNode root = new TreeNode(12)
            {
                Left = new TreeNode(7),
                Right = new TreeNode(1)
            };
            root.Left.Left = new TreeNode(9);
            root.Right.Left = new TreeNode(10);
            root.Right.Right = new TreeNode(5);

            var resultList = new ZigzagTraversal().Execute(root);
            
            Assert.AreEqual(resultList.FirstOrDefault().FirstOrDefault(), 9);
        }

        [Test]
        public void BFSTester4()
        {
            
        }
    }
}