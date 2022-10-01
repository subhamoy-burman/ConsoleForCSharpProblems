using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppBlind75
{
    public class TreeNode
    {
        public int Val;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode()
        {
            
        }
        public TreeNode(int val)
        {
            Val = val;
            Left = Right = null;
        }

    }
    public static class Trees
    {

        public static List<int> GetLevelOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            var levelOrderList = new List<int>();
            Queue<TreeNode> levelOrderQueue = new Queue<TreeNode>();
            levelOrderQueue.Enqueue(root);

            while (levelOrderQueue.Count>0)
            {
                int queueLength = levelOrderQueue.Count;

                for (int i = 0; i < queueLength; i++)
                {
                    if (levelOrderQueue.Peek().Left != null)
                    {
                        levelOrderQueue.Enqueue(levelOrderQueue.Peek().Left);
                    }

                    if (levelOrderQueue.Peek().Right != null)
                    {
                        levelOrderQueue.Enqueue(levelOrderQueue.Peek().Right);
                    }
                    levelOrderList.Add(levelOrderQueue.Dequeue().Val);
                }
            }

            return levelOrderList;
        }
        public static List<int> PreOrderIterativeTraversal(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            Stack<TreeNode> preOrderStack = new Stack<TreeNode>();
            preOrderStack.Push(root);
            List<int> preOrderList = new List<int>();

            while (preOrderStack.Count > 0)
            {
                TreeNode currentNode = preOrderStack.Peek();
                preOrderList.Add(preOrderStack.Pop().Val);

                if (currentNode.Right != null)
                {
                    preOrderStack.Push(currentNode.Right);
                }

                if (currentNode.Left != null)
                {
                    preOrderStack.Push(currentNode.Left);
                }
            }

            return preOrderList;
        }
        public static List<int> InOrderTraversalIterative(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            List<int> inorderTraversalList = new List<int>();
            Stack<TreeNode> inorderTreeStack = new Stack<TreeNode>();
            
            inorderTreeStack.Push(root);
            TreeNode currentNode = root;

            while (inorderTreeStack.Count > 0)
            {
                currentNode = inorderTreeStack.Peek(); 
                if (inorderTreeStack.Peek().Left != null)
                {   
                    inorderTreeStack.Push(currentNode.Left);
                }
                else
                {
                    inorderTraversalList.Add(inorderTreeStack.Pop().Val);
                    if (inorderTreeStack.Count > 0)
                    {
                        currentNode = inorderTreeStack.Peek();
                        inorderTraversalList.Add(inorderTreeStack.Pop().Val);
                        if (currentNode.Right != null)
                            inorderTreeStack.Push(currentNode.Right);
                    }
                }
                
            }

            return inorderTraversalList;
        }

        public static int GetDiameterOfABinaryTree(TreeNode root)
        {
            int[] diameter = new int[1];
            Height(root, diameter);
            return diameter[0];
        }

        private static int Height(TreeNode root, int[] diameter)
        {
            if (root == null)
                return 0;

            int lh = Height(root.Left, diameter);
            int rh = Height(root.Right, diameter);

            diameter[0] = Math.Max(diameter[0], lh + rh);
            return 1 + Math.Max(lh,rh);
        }

        public static List<int> PrintZigZagTraversal(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            Queue<TreeNode> treeQueue = new Queue<TreeNode>();

            List<int> treeTraversalValues = new List<int>();
            treeQueue.Enqueue(root);
            bool isReverse = false;
            while (treeQueue.Count>0)
            {
                var countOfQElements = treeQueue.Count;

                var localList = new List<int>();
                for (int i = 0; i < countOfQElements; i++)
                {
                    if (treeQueue.Peek().Left != null)
                    {
                        treeQueue.Enqueue(treeQueue.Peek().Left);
                    }

                    if (treeQueue.Peek().Right != null)
                    {
                        treeQueue.Enqueue(treeQueue.Peek().Right);
                    }

                    localList.Add(treeQueue.Dequeue().Val);
                }

                if (isReverse)
                {
                    localList.Reverse();
                }
                
                treeTraversalValues.AddRange(localList);
                isReverse = !isReverse;
                
            }

            return treeTraversalValues;
        }

        public static List<int> PrintBoundaryOfTree(TreeNode root)
        {
            List<int> treeBoundary = new List<int>();
            if (root == null)
            {
                return treeBoundary;
            }

            if (IsLeaf(root))
            {
                 treeBoundary.Add(root.Val);
                 return treeBoundary;
            }

            treeBoundary.Add(root.Val);
            AddLeftBoundary(root, treeBoundary);
            AddLeaves(root, treeBoundary);
            AddRightBoundary(root, treeBoundary);

            return treeBoundary;
        }

        private static void AddRightBoundary(TreeNode root, List<int> treeBoundary)
        {
            var currentNode = root.Right;

            var localList = new List<int>();
            while (currentNode!=null)
            {
                if (!IsLeaf(currentNode))
                {
                    localList.Add(currentNode.Val);
                }

                if (currentNode.Right != null)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode = currentNode.Left;
                }
            }

            localList.Reverse();
            treeBoundary.AddRange(localList);
        }

        private static void AddLeaves(TreeNode root, List<int> treeBoundary)
        {
            if (IsLeaf(root))
            {
                treeBoundary.Add(root.Val);
                return;
            }

            if (root.Left != null)
            {
                AddLeaves(root.Left, treeBoundary);
            }

            if (root.Right != null)
            {
                AddLeaves(root.Right, treeBoundary);
            }
        }
        

        private static void AddLeftBoundary(TreeNode root, List<int> treeBoundary)
        {
            var currentNode = root.Left;
            while (currentNode!=null)
            {
                if (!IsLeaf(currentNode))
                {
                    treeBoundary.Add(currentNode.Val);
                }

                if (currentNode.Left != null)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }
        }

        private static bool IsLeaf(TreeNode node)
        {
            return (node.Left == null) && (node.Right == null);
        }

        
        public static List<List<int>> VerticalTraversalOfATree(TreeNode root)
        {
            Queue<NodeLevelPair> nodeLevelPairs = new Queue<NodeLevelPair>();
            Dictionary<int, List<int>> levelPairMap = new Dictionary<int, List<int>>();
            int minLevel = 0;
            int maxLevel = 0;

            List<List<int>> ans = new List<List<int>>();
            
            nodeLevelPairs.Enqueue(new NodeLevelPair(root,0));

            while (nodeLevelPairs.Count > 0)
            {
                int size = nodeLevelPairs.Count;

                for (int i = 0; i < size; i++)
                {
                    NodeLevelPair pair = nodeLevelPairs.Dequeue();

                    maxLevel = Math.Max(maxLevel, pair.Level);
                    minLevel = Math.Min(minLevel, pair.Level);

                    if (levelPairMap.ContainsKey(pair.Level))
                    {
                        var levelOrderValuesSofar = levelPairMap[pair.Level];
                        levelOrderValuesSofar.Add(pair.Node.Val);
                        levelPairMap[pair.Level] = levelOrderValuesSofar;
                    }
                    else
                    {
                        levelPairMap[pair.Level] = new List<int> {pair.Node.Val};
                    }

                    if (pair.Node.Left != null)
                    {
                        nodeLevelPairs.Enqueue( new NodeLevelPair(pair.Node.Left, pair.Level - 1));
                    }

                    if (pair.Node.Right != null)
                    {
                        nodeLevelPairs.Enqueue(new NodeLevelPair(pair.Node.Right, pair.Level + 1));
                    }
                }
            }

            for (int i = minLevel; i <= maxLevel; i++)
            {
                ans.Add(levelPairMap[i]);
            }

            return ans;

        }
        
        public static List<int> PathFinder(TreeNode root, int value)
        {
            List<int> listOfPaths = new List<int>();
            if (root == null)
            {
                return listOfPaths;
            }

            GetPath(root, listOfPaths, value);
            return listOfPaths;
        }

        private static bool GetPath(TreeNode root, List<int> listOfPaths, int value)
        {
            if (root == null)
            {
                return false;
            }
            
            listOfPaths.Add(root.Val);

            if (root.Val == value)
            {
                return true;
            }

            if (GetPath(root.Left, listOfPaths, value) || GetPath(root.Right, listOfPaths, value))
            {
                return true;
            }

            listOfPaths.Remove(listOfPaths.LastOrDefault());
            return false;
        }

        public static int GetMaxWidthOfATree(TreeNode root)
        {
            Queue<NodeLevelPair> pairs = new Queue<NodeLevelPair>();
            int max = 0;
            if (root == null)
            {
                return 0;
            }
            pairs.Enqueue(new NodeLevelPair(root,0));

            while (pairs.Count>0)
            {
                int queueSize = pairs.Count;
                var leftMost = pairs.Peek().Level;
                var rightMost = pairs.Peek().Level;
                
                for (int i = 0; i < queueSize; i++)
                {
                    var removedPair = pairs.Dequeue();
                    rightMost = removedPair.Level;

                    if (removedPair.Node.Left != null)
                    {
                        pairs.Enqueue(new NodeLevelPair(removedPair.Node.Left, removedPair.Level*2 + 1));
                    }

                    if (removedPair.Node.Right != null)
                    {
                        pairs.Enqueue(new NodeLevelPair(removedPair.Node.Right, removedPair.Level*2 + 2));
                    }
                        
                }

                max = Math.Max(max, rightMost - leftMost + 1);
            }

            return max;
        }

        private static int time = 0;

        public static void BurnTree(TreeNode root, TreeNode blockNode, int time)
        {
            
        }

        public static TreeNode BuildTree(int[] preOrder, int[] inOrder, int preOrderStart, int preOrderEnd,
            int inOrderStart, int inOrderEnd)
        {
            if (inOrderStart > inOrderEnd)
            {
                return null;
            }

            int index = inOrderStart;

            while (inOrder[index] != preOrder[preOrderStart])
            {
                index++;
            }

            int countOfLeftSubtree = index + inOrderStart;

            TreeNode node = new TreeNode(preOrder[preOrderStart]);

            node.Left = BuildTree(preOrder, inOrder,
                preOrderStart + 1,
                preOrderStart + countOfLeftSubtree,
                inOrderStart, index - 1
            );
            
            node.Right = BuildTree(preOrder, inOrder,
                preOrderStart +countOfLeftSubtree + 1,
                preOrderEnd,
                index + 1, inOrderEnd
            );

            return node;
        }

        public static TreeNode BuildTree(int[] preOrder, int[] inOrder)
        {
            return BuildTree(preOrder, inOrder, 0, preOrder.Length - 1, 0, inOrder.Length - 1);
        }
        public static int TotalTimeForBurningTree(TreeNode root, int fireNode)
        {
            if (root.Val == fireNode)
            {
                BurnTree(root,null,0);
            }
            int leftTime = TotalTimeForBurningTree(root.Left, fireNode);
            int rightTime = TotalTimeForBurningTree(root.Right, fireNode);

            return -1;
        }
    }

    public class NodeLevelPair
    {
        public TreeNode Node;
        public int Level;

        public NodeLevelPair(TreeNode node, int level)
        {
            Node = node;
            Level = level;
        }
    }
    
    
}