using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleNeetCode.RevisionOne.Trees;

public static class TreeRevision
{
    public class NodeVLevel
    {
        public int VerticalLevel { get; set; }
        public TreeNodeRev Node { get; set; }
    }

    public class TreeNodeRev
    {
        public int Val;
        public TreeNodeRev Left;
        public TreeNodeRev Right;

        public TreeNodeRev(int val = 0, TreeNodeRev left = null, TreeNodeRev right = null)
        {
            this.Val = val;
            this.Left = left;
            this.Right = right;
        }
    }

    public static void ChildrenSumTree(TreeNodeRev root)
    {
        if (root == null)
        {
            return;
        }

        int childSum = 0;
        if (root.Left != null)
        {
            childSum += root.Left.Val;
        }

        if (root.Right != null)
        {
            childSum += root.Right.Val;
        }

        if (childSum >= root.Val)
        {
            root.Val = childSum;
        }
        else
        {
            if (root.Left != null) root.Left.Val = root.Val;
            if (root.Right != null) root.Right.Val = root.Val;
        }
        
        ChildrenSumTree(root.Left);
        ChildrenSumTree(root.Right);

        int total = 0;
        if (root.Left != null) total += root.Left.Val;
        if (root.Right != null) total += root.Right.Val;

        if (root.Left != null || root.Right != null) root.Val = total;
    }

    public static List<int> TopViewOnBinaryTree(TreeNodeRev treeNode)
    {
        Queue<NodeVLevel> nodeVLevels = new Queue<NodeVLevel>();
        nodeVLevels.Enqueue(new NodeVLevel()
        {
            Node = treeNode,
            VerticalLevel = 0
        });

        Dictionary<int, TreeNodeRev> levelDictionary = new Dictionary<int, TreeNodeRev>();

        while (nodeVLevels.Count != 0)
        {
            var currentNode = nodeVLevels.Dequeue();

            if (!levelDictionary.ContainsKey(currentNode.VerticalLevel))
            {
                levelDictionary.Add(currentNode.VerticalLevel, currentNode.Node);
            }

            if (currentNode.Node.Left != null)
            {
                nodeVLevels.Enqueue(new NodeVLevel()
                {
                    Node = currentNode.Node.Left,
                    VerticalLevel = currentNode.VerticalLevel - 1
                });
            }

            if (currentNode.Node.Right != null)
            {
                nodeVLevels.Enqueue(new NodeVLevel()
                {
                    Node = currentNode.Node.Right,
                    VerticalLevel = currentNode.VerticalLevel + 1
                });
            }
        }

        List<int> sortedKeys = levelDictionary.Keys.ToList();
        sortedKeys.Sort();
        List<int> verticalLevel = new List<int>();

        foreach (var key in sortedKeys)
        {
            verticalLevel.Add(levelDictionary[key].Val);
        }

        return verticalLevel;
    }
    
    public static List<int> BottomViewOfBinaryTree(TreeNodeRev treeNode)
    {
        Queue<NodeVLevel> nodeVLevels = new Queue<NodeVLevel>();
        nodeVLevels.Enqueue(new NodeVLevel()
        {
            Node = treeNode,
            VerticalLevel = 0
        });

        Dictionary<int, TreeNodeRev> levelDictionary = new Dictionary<int, TreeNodeRev>();

        while (nodeVLevels.Count != 0)
        {
            var currentNode = nodeVLevels.Dequeue();

            if (!levelDictionary.ContainsKey(currentNode.VerticalLevel))
            {
                levelDictionary.Add(currentNode.VerticalLevel, currentNode.Node);
            }
            else
            {
                levelDictionary[currentNode.VerticalLevel] = currentNode.Node;
            }

            if (currentNode.Node.Left != null)
            {
                nodeVLevels.Enqueue(new NodeVLevel()
                {
                    Node = currentNode.Node.Left,
                    VerticalLevel = currentNode.VerticalLevel - 1
                });
            }

            if (currentNode.Node.Right != null)
            {
                nodeVLevels.Enqueue(new NodeVLevel()
                {
                    Node = currentNode.Node.Right,
                    VerticalLevel = currentNode.VerticalLevel + 1
                });
            }
        }

        List<int> sortedKeys = levelDictionary.Keys.ToList();
        sortedKeys.Sort();
        List<int> verticalLevel = new List<int>();

        foreach (var key in sortedKeys)
        {
            verticalLevel.Add(levelDictionary[key].Val);
        }

        return verticalLevel;
    }

    public static List<int> NodesAtDistanceK(TreeNodeRev treeNodeRev, TreeNodeRev target, int k)
    {
        Dictionary<TreeNodeRev, TreeNodeRev> dictTreeNodeParent = new Dictionary<TreeNodeRev, TreeNodeRev>();
        MarkParents(treeNodeRev, dictTreeNodeParent);

        Dictionary<TreeNodeRev, bool> visited = new Dictionary<TreeNodeRev, bool>();
        Queue<TreeNodeRev> queue = new Queue<TreeNodeRev>();
        queue.Enqueue(target);
        visited.Add(target,true);
        int currLevel = 0;

        while (queue.Count!=0)
        {
            int size = queue.Count;
            if(currLevel == k) break;
            currLevel++;

            for (int i = 0; i < size; i++)
            {
                TreeNodeRev current = queue.Dequeue();
                if (current.Left != null && !visited.ContainsKey(current.Left))
                {
                    queue.Enqueue(current.Left);
                    visited.Add(current.Left, true);
                }
                
                if (current.Right != null && !visited.ContainsKey(current.Right))
                {
                    queue.Enqueue(current.Right);
                    visited.Add(current.Right, true);
                }

                if (dictTreeNodeParent.ContainsKey(current) && !visited.ContainsKey(dictTreeNodeParent[current]))
                {
                    queue.Enqueue(dictTreeNodeParent[current]);
                    visited.Add(dictTreeNodeParent[current], true);
                }
            }
        }

        List<int> result = new List<int>();
        while (queue.Count != 0)
        {
            TreeNodeRev current = queue.Dequeue();
            result.Add(current.Val);
        }

        return result;
    }

    private static void MarkParents(TreeNodeRev treeNodeRev, Dictionary<TreeNodeRev, TreeNodeRev> dictTreeNodeParent)
    {
        Queue<TreeNodeRev> queue = new Queue<TreeNodeRev>();
        queue.Enqueue(treeNodeRev);

        while (queue.Count != 0)
        {
            TreeNodeRev current = queue.Dequeue();
            if (current.Left != null)
            {
                dictTreeNodeParent.Add(current.Left, current);
                queue.Enqueue(current.Left);
            }

            if (current.Right != null)
            {
                dictTreeNodeParent.Add(current.Right, current);
                queue.Enqueue(current.Right);
            }
        }
    }
}