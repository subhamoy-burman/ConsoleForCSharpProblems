using System;
using System.Diagnostics;
using ConsoleAppBlind75.BFS;

namespace ConsoleAppBlind75.DFS
{
    public class DFSTraversal
    {
        int targetSum = 23;

        public void TraverseTree(TreeNode node)
        {
            if(node == null)
                return;
            
            TraverseTree(node.Left);
            
            targetSum -= node.Value;
            Debug.WriteLine(node.Value);
            Debug.WriteLine($"Target sum value: {targetSum}");
            
            
            TraverseTree(node.Right);
        }
    }
}