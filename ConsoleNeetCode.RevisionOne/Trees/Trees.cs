// ReSharper disable SwapViaDeconstruction

using System;
using System.Collections.Generic;

namespace ConsoleNeetCode.RevisionOne.Trees
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        
        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
    public static class Trees
    {
        public static TreeNode InvertBinaryTree(TreeNode node)
        {
            ProcessInvertBt(node);
            return node;
        }

        private static void ProcessInvertBt(TreeNode node)
        {
            if (node is null)
            {
                return;
            }

            var tempNode = node.Left;
            node.Left = node.Right;
            node.Right = tempNode;
            
            ProcessInvertBt(node.Left);
            ProcessInvertBt(node.Right);
        }

        public static int FindDiameterOfABinaryTree(TreeNode node)
        {
            if (node is null) return 0;
            
            int leftDiameter = FindDiameterOfABinaryTree(node.Left);
            int rightDiameter = FindDiameterOfABinaryTree(node.Right);

            int leftHeight = GetHeight(node.Left);
            int rightHeight = GetHeight(node.Right);

            int diameter = leftHeight + rightHeight + 2;

            return Math.Max(Math.Max(leftDiameter, rightDiameter), diameter);
        }

        public static int GetHeight(TreeNode node)
        {
            if (node is null)
            {
                return 0;
            }

            return Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }

        public static int GetDiameter(TreeNode node)
        {
            int maxi = Int32.MinValue;
            SolveDiameter(node, ref maxi);
            return maxi;
        }
        private static int SolveDiameter(TreeNode node, ref int maxi)
        {
            if (node is null) return 0;

            int lh = SolveDiameter(node.Left, ref maxi);
            int rh = SolveDiameter(node.Right, ref maxi);

            maxi = Math.Max(maxi, lh + rh);
            return 1 + Math.Max(lh, rh);
        }

        public static int IsBalancedTree(TreeNode node)
        {
            return SolveIsBalancedTree(node);
        }

        private static int SolveIsBalancedTree(TreeNode node)
        {
            int lh = GetHeight(node.Left);
                if (lh == -1) return -1;
            int rh = GetHeight(node.Right);
                if (rh == -1) return -1;
            
            if (Math.Abs(lh - rh) > 1)
            {
                return -1;
            }
            
            return 1 + Math.Max(lh, rh);
        }


        public static int GetMaximumPathSum(TreeNode node)
        {
            return -1;
        }

        public static List<int> PrintBoundaryTraversal(TreeNode node)
        {
            var boundaryNodes = new List<int>() { node.Value };
            var leftNodes = GetLeftNodes(node.Left);
            var leafNodes = GetLeafNodes(node);
            var rightNodes = GetRightNodes(node.Right);
            boundaryNodes.AddRange(leafNodes);
            boundaryNodes.AddRange(leafNodes);
            boundaryNodes.AddRange(rightNodes);

            return boundaryNodes;
        }

        private static List<int> GetLeftNodes(TreeNode node)
        {
            List<int> listOfLeftNodes = new List<int>();
            while (node!=null)
            {
                if (!IsLeaf(node))
                {
                    listOfLeftNodes.Add(node.Value);
                }
                node = node.Left ?? node.Right;
            }

            return listOfLeftNodes;
        }
        
        private static List<int> GetRightNodes(TreeNode node)
        {
            List<int> listOfRightNodes = new List<int>();
            while (node!=null)
            {
                if (!IsLeaf(node))
                {
                    listOfRightNodes.Add(node.Value);
                }
                node = node.Right ?? node.Left;
            }
            
            listOfRightNodes.Reverse();
            return listOfRightNodes;
        }

        private static List<int> GetLeafNodes(TreeNode node)
        {
            List<int> leafNodes = new List<int>();
            Inorder(node, ref leafNodes);
            return leafNodes;
        }

        private static void Inorder(TreeNode node, ref List<int> leafNodes)
        {
            if (node.Left is null && node.Right is null)
            {
                leafNodes.Add(node.Value);
                return;
            }
            if(node.Left!=null) Inorder(node.Left, ref leafNodes);
            if(node.Right!=null) Inorder(node.Right, ref leafNodes);
        }

        private static bool IsLeaf(TreeNode node)
        {
            return node.Left is null && node.Right is null;
        }

        public static List<int> RootToNodePath(TreeNode node, int targetNode)
        {
            var path = new List<int>();
            FoundRootToNodePath(node, targetNode, path);
            return path;
        }

        private static bool FoundRootToNodePath(TreeNode node, int targetNode, List<int> path)
        {
            if (node is null)
            {
                return false;
            }

            if (node.Value.Equals(targetNode))
            {
                path.Add(node.Value);
                return true;
            }

            if (FoundRootToNodePath(node.Left, targetNode, path))
            {
                path.Add(node.Value);
                return true;
            }

            if (FoundRootToNodePath(node.Right, targetNode, path))
            {
                path.Add(node.Value);
                return true;
            }

            return false;
        }

        public static List<int> GoodNodes(TreeNode node)
        {
            List<int> listOfGoodNodes = new List<int>();
            CountGoodNodes(node, listOfGoodNodes, 0);
            
            return listOfGoodNodes;
        }

        private static void CountGoodNodes(TreeNode node, List<int> listOfGoodNodes, int max)
        {
            if(node is null) return;

            if (node.Value >= max)
            {
                max = node.Value;
                listOfGoodNodes.Add(node.Value);
            }
            
            CountGoodNodes(node.Left, listOfGoodNodes, max);
            CountGoodNodes(node.Right, listOfGoodNodes, max);
        }
    }
}