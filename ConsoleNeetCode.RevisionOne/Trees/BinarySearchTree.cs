namespace ConsoleNeetCode.RevisionOne.Trees;

public static class BinarySearchTree
{
    public class BSTNode
    {
        public int Value { get; set; }
        public BSTNode Left { get; set; }
        public BSTNode Right { get; set; }

        public BSTNode(int value)
        {
            Value = value;
        }
    }

    public static BSTNode InsertIntoBST(BSTNode root, int newValue)
    {
        if (root == null)
        {
            return root = new BSTNode(newValue);
        }

        if (root.Value > newValue)
        {
            root.Left = InsertIntoBST(root.Left, newValue);
        }
        else
        {
            root.Right = InsertIntoBST(root.Right, newValue);
        }

        return root;
    }

    public static BSTNode FindBstNode(BSTNode root, int targetValue)
    {
        if (root == null)
        {
            return null;
        }

        if (root.Value == targetValue)
        {
            return root;
        }

        if (root.Value > targetValue)
        {
            return FindBstNode(root.Left, targetValue);
        }
        else
        {
            return FindBstNode(root.Right, targetValue);
        }
    }

    public static int MaxValue(BSTNode node)
    {
        BSTNode temp = node;

        if (temp is null)
        {
            return -1;
        }
        
        while (temp.Right!=null)
        {
            temp = temp.Right;
        }

        return temp.Value;
    }

    public static BSTNode DeleteBSTNode(BSTNode root, int target)
    {
        if (root == null)
        {
            return null;
        }

        if (root.Value > target)
        {
            root.Left = DeleteBSTNode(root.Left, target);
        }
        else if(root.Value<target)
        {
            root.Right = DeleteBSTNode(root.Right, target);
        }
        else
        {
            if (root.Left is null && root.Right is null)
            {
                return null;
            }
            else if (root.Left != null && root.Right is null)
            {
                return root.Left;
            }
            else if (root.Left is null && root.Right != null)
            {
                return root.Right;
            }
            else
            {
                int auxValue = MaxValue(root.Left);
                root.Value = auxValue;
                root.Left = DeleteBSTNode(root.Left, auxValue);
            }
        }

        return root;


    }

    public static int BSTKthSmallestNode(BSTNode root, int k)
    {
        int value = 0;
        FuncBSTKthSmallestNode(root, ref k, ref value);
        return value;
    }

    private static void FuncBSTKthSmallestNode(BSTNode root, ref int k, ref int value)
    {
        if (root == null)
        {
            return;
        }
        
        FuncBSTKthSmallestNode(root.Left, ref k, ref value);

        k--;
        if (k == 0)
        {
            value = root.Value;
            return;
        }
        
        FuncBSTKthSmallestNode(root.Right,ref k,ref value);
    }
}