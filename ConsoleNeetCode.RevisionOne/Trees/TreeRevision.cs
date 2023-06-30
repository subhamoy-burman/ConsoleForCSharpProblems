using System.Collections.Generic;
using System.Linq;

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
}