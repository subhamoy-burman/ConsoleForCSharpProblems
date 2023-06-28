// ReSharper disable SwapViaDeconstruction

using System;
using System.Collections.Generic;
using System.Linq;

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
        
        public static TreeNode BuildTreeFromInorderAndPreOrder(int[] preOrder, int[] inOrder)
        {
            int totalIndex = preOrder.Length;

            return BuildTree(preOrder, inOrder, 0, totalIndex - 1, 0, totalIndex - 1);
        }

        private static TreeNode BuildTree(int[] preOrder, int[] inOrder, int preOrderStartIndex, int preOrderEndIndex, int inOrderStartIndex, int inOrderEndIndex)
        {
            if (preOrderStartIndex > preOrderEndIndex || inOrderStartIndex > inOrderEndIndex)
            {
                return null;
            }
            TreeNode node = new TreeNode(preOrder[preOrderStartIndex]);

            int inorderRootIndex = Array.IndexOf(inOrder, node.Value);
            int numOfElementsOnLeftTree = inorderRootIndex - inOrderStartIndex;
            node.Left = BuildTree(preOrder, inOrder, preOrderStartIndex + 1,
                preOrderStartIndex + numOfElementsOnLeftTree, inOrderStartIndex, inorderRootIndex - 1);
            node.Right = BuildTree(preOrder, inOrder, preOrderStartIndex + numOfElementsOnLeftTree + 1,
                preOrderEndIndex, inorderRootIndex + 1, inOrderEndIndex);

            return node;
        }

        public static TreeNode SerializeAndDeserialize(TreeNode root)
        {
            List<string> serialized = Serialize(root);
            TreeNode deserializedTree = Deserialize(serialized);
            return deserializedTree;
        }

        private static TreeNode Deserialize(List<string> input)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode root = new TreeNode(Convert.ToInt32(input.FirstOrDefault()));
            queue.Enqueue(root);

            for (int i = 1; i < input.Count; i += 2)  // Increment by 2 to skip both left and right child markers
            {
                TreeNode parent = queue.Dequeue();

                if (input[i] != "#")
                {
                    TreeNode left = new TreeNode(Convert.ToInt32(input[i]));
                    parent.Left = left;
                    queue.Enqueue(left);
                }

                if (input[i+1] != "#")
                {
                    TreeNode right = new TreeNode(Convert.ToInt32(input[i+1]));
                    parent.Right = right;
                    queue.Enqueue(right);
                }
            }

            return root;
        }

        private static List<string> Serialize(TreeNode root)
        {
            Queue<TreeNode> levels = new Queue<TreeNode>();
            levels.Enqueue(root);
            List<string> serializedString = new List<string>() { root.Value.ToString()};

            while (levels.Count>0)
            {
                var elementCount = levels.Count;
                for (int i = 0; i < elementCount; i++)
                {
                    var element = levels.Dequeue();
                    if (element.Left != null)
                    {
                        serializedString.Add(element.Left.Value.ToString());
                        levels.Enqueue(element.Left);
                    }
                    else
                    {
                        serializedString.Add("#");
                    }

                    if (element.Right != null)
                    {
                        serializedString.Add(element.Right.Value.ToString());
                        levels.Enqueue(element.Right);
                    }
                    else
                    {
                        serializedString.Add("#");
                    }
                }
            }

            return serializedString;
        }
    }
}