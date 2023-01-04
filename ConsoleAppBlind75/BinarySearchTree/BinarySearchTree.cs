using System;
using System.Diagnostics;

namespace ConsoleAppBlind75.BinarySearchTree
{
    public static class BinarySearchTree
    {
        public class Node
        {
            public int NodeVal;
            public Node Left;
            public Node Right;

            public Node(int val, Node left = null, Node right= null)
            {
                NodeVal = val;
                Left = left;
                Right = right;
            }
        }

        public static Node NodeConstruct(int[] arr, int low, int high)
        {
            if (low > high)
            {
                return null;
            }
            int mid = (low + high) / 2;
            int data = arr[mid];

            Node leftChild = NodeConstruct(arr, low, mid - 1);
            Node rightChild = NodeConstruct(arr, mid + 1, high);

            Node root = new Node(data, leftChild, rightChild);

            return root;
        }

        public static Node AddNode(Node node, int val)
        {
            if (node == null)
                return new Node(val, null, null);
            
            if (node.NodeVal > val)
            {
                node.Right = AddNode(node.Right, val);
            }

            if (node.NodeVal < val)
            {
                node.Right = AddNode(node.Left, val);
            }

            return node;
        }

        public static Node RemoveNode(Node node, int val)
        {
            if (node == null)
            {
                return null;
            }
            
            if (node.NodeVal > val)
            {
                node.Right = RemoveNode(node.Right, val);
            }
            else if(node.NodeVal < val)
            {
                node.Left = RemoveNode(node.Left, val);
            }
            else
            {
                if (node.Right != null && node.Left != null)
                {
                    int data = GetMax(node.Left);
                    node.NodeVal = data;
                    node.Left = RemoveNode(node.Left, data);
                    return node;
                }

                if(node.Right!=null)
                {
                    return node.Right;
                }
                if(node.Left!=null)
                {
                    return node.Left;
                }

                return null;
            }

            return node;
        }

        private static int GetMax(Node node)
        {
            if (node.Right != null)
            {
                return GetMax(node.Right);
            }

            return node.NodeVal;
        }

        private static int _sumOfNodeSoFar = 0;
        public static void ReplaceWithSumLarger(Node rootNode)
        {
            if (rootNode == null)
            {
                return;
            }
            ReplaceWithSumLarger(rootNode.Right);

            int originalData = rootNode.NodeVal;
            rootNode.NodeVal = _sumOfNodeSoFar;
            _sumOfNodeSoFar += originalData;
            
            ReplaceWithSumLarger(rootNode.Left);

        }

        public static Node FindLCAOfBST(Node rootNode, int data1, int data2)
        {
            if (rootNode == null)
            {
                return null;
            }

            if (rootNode.NodeVal > data1 && rootNode.NodeVal > data2)
            {
                return FindLCAOfBST(rootNode.Left, data1, data2);
            }

            if( rootNode.NodeVal < data1 && rootNode.NodeVal < data2)
            {
                return FindLCAOfBST(rootNode.Right, data1, data2);
            }

            return rootNode;
        }

        public static void PrintRange(Node rootNode, int data1, int data2)
        {
            if (rootNode == null)
            {
                return;
            }
            
            if (rootNode.NodeVal > data1 && rootNode.NodeVal< data2)
            {   
                PrintRange(rootNode.Left, data1, data2);
                Debug.WriteLine(rootNode.NodeVal);
                PrintRange(rootNode.Right,data1, data2);
            }

            if (rootNode.NodeVal < data1 && rootNode.NodeVal< data2)
            {
                if (rootNode.Right is null)
                {
                    Debug.WriteLine(rootNode.NodeVal);
                    return;
                }
                PrintRange(rootNode.Right, data1, data2);
            }

            if (rootNode.NodeVal > data2 && rootNode.NodeVal > data2)
            {
                if (rootNode.Left is null)
                {
                    Debug.WriteLine(rootNode.NodeVal);
                    return;
                }
                PrintRange(rootNode.Left, data1, data2);
            }
        }
    }
}