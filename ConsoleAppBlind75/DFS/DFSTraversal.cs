using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using ConsoleAppBlind75.BFS;

namespace ConsoleAppBlind75.DFS
{
    public class DFSTraversal
    {
        int targetSum = 23;

        public static bool HasPathSum(TreeNode node, int targetSum)
        {
            if (node == null)
                return false;

            if (node.Right == null && node.Left == null)
            {
                return targetSum - node.Value == 0;
            }
            return HasPathSum(node.Left, targetSum - node.Value) || HasPathSum(node.Right, targetSum - node.Value);
        }

        public static List<List<int>> PathSum(TreeNode node, int sum)
        {
            var paths = new List<List<int>>();

            FindPaths(node, sum, new List<int>(), paths);

            return paths;
        }

        private static void FindPaths(TreeNode node, int sum, List<int> current, List<List<int>> paths)
        {
            if (node == null)
            {
                return;
            }
            current.Add(node.Value);

            if (node.Value == sum && node.Left == null && node.Right == null)
            {
                paths.Add(current);
                return;
            }
            FindPaths(node.Left, sum -node.Value, new List<int>(current), paths);
            FindPaths(node.Right, sum -node.Value, new List<int>(current), paths);

        }

        public static List<List<TreeNode>> GetPaths(TreeNode node, int sum)
        {
            List<List<TreeNode>> listOfPaths = new List<List<TreeNode>>();
            if (node == null)
            {
                return listOfPaths;
            }

            var nodeStack = new Stack<TreeNode>();
            nodeStack.Push(node);

            while (nodeStack.Count!=0)
            {
                var current = nodeStack.Pop();

                if (current.Right == null && current.Left == null)
                {
                    if (sum - (current.Value + nodeStack.Sum(x => x.Value)) == 0)
                    {
                        List<TreeNode> listOfVal = new List<TreeNode>();
                        foreach (var item in nodeStack)
                        {
                            listOfVal.Add(item);
                        }

                        listOfPaths.Add(listOfVal);
                    }
                }
                
                if(current.Right!=null)
                    nodeStack.Push(current.Right);
                if(current.Left!=null)
                    nodeStack.Push(current.Left);
                
            }

            return listOfPaths;
        }

        public static int[] GetDFSValues(TreeNode node)
        {
            if (node == null)
                return new int[] {};

            var listOfLeftTree = GetDFSValues(node.Left);
            var listOfRightTree = GetDFSValues(node.Right);

            var listOfNodes = new int[] { node.Value };
            listOfNodes.Concat(listOfLeftTree);
            listOfNodes.Concat(listOfRightTree);

            return listOfNodes;
        }

        public static List<List<int>> GetPathsImplementation2(TreeNode node, int sum)
        {
            List<List<int>> listOfAllPaths = new List<List<int>>();
            List<int> currentPath = new List<int>();
            
            FindPathsImplementation2(node, sum, currentPath, listOfAllPaths);
            return listOfAllPaths;
        }

        private static void FindPathsImplementation2(TreeNode node, int sum, List<int> currentPath, List<List<int>> listOfAllPaths)
        {
            if(node == null)
                return;

            currentPath.Add(node.Value);
            if (sum == node.Value && node.Left == null && node.Right == null)
            {
                listOfAllPaths.Add(new List<int>(currentPath));
            }
            else
            {
                FindPathsImplementation2(node.Left, sum - node.Value, new List<int>(currentPath), listOfAllPaths);
                FindPathsImplementation2(node.Right,sum - node.Value, new List<int>(currentPath), listOfAllPaths);
            }

            currentPath.Remove(currentPath.LastOrDefault());
        }

        public static List<List<int>> FindAllPathToLeaf(TreeNode node)
        {
            List<List<int>> pathsToLeaf = new List<List<int>>();
            List<int> currentPath = new List<int>();
            FindPathsToLeaf(node, currentPath, pathsToLeaf);
            return pathsToLeaf;
        }

        private static void FindPathsToLeaf(TreeNode node, List<int> currentPath, List<List<int>> pathsToLeaf)
        {
            if (node == null)
                return;
            
            currentPath.Add(node.Value);

            if (node.Left == null && node.Right == null)
            {
                pathsToLeaf.Add(new List<int>(currentPath));
            }
            else
            {
                FindPathsToLeaf(node.Left, new List<int>(currentPath), pathsToLeaf);
                FindPathsToLeaf(node.Right, new List<int>(currentPath), pathsToLeaf);
            }

            currentPath.Remove(currentPath.LastOrDefault());
        }
    }
}