using System.Diagnostics;

namespace ConsoleNeetCode.RevisionOne.LinkedListV1;

public class LinkedListV1
{
    public class DoubleLLNode
    {
        public int Value { get; set; }
        public DoubleLLNode Prev { get; set; }
        public DoubleLLNode Next { get; set; }

        public DoubleLLNode(int value)
        {
            Value = value;
        }

        public void PrintDoubleLL(DoubleLLNode head)
        {
            DoubleLLNode node = head;

            while (node!=null)
            {
                Debug.WriteLine(node.Value);
                node = node.Next;
            }
        }

        public int GetLLCount(DoubleLLNode head)
        {
            DoubleLLNode node = head;
            int length = 0;

            while (node!= null)
            {
                length++;
                node = node.Next;
            }
            
            return length;
        }

        public void InsertAtHead(ref DoubleLLNode head, DoubleLLNode tail, int value)
        {
            if (head is null)
            {
                DoubleLLNode newNode = new DoubleLLNode(value);
                head = newNode;
                tail = newNode;
            }
            else
            {
                DoubleLLNode newNode = new DoubleLLNode(value);

                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }

        }
        
        public void InsertAtTail(ref DoubleLLNode head, DoubleLLNode tail, int value)
        {
            if (head is null)
            {
                DoubleLLNode newNode = new DoubleLLNode(value);
                head = newNode;
                tail = newNode;
            }
            else
            {
                DoubleLLNode newNode = new DoubleLLNode(value);

                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }

        }
    }


    public class LLNode
    {
        public LLNode(int value, LLNode next=null)
        {
            Value = value;
            Next = next;
        }

        public int Value { get; set; }
        public LLNode Next { get; set; }

        public int Length
        {
            get
            {
                var len = 0;
                var temp = this;
                while (temp!=null)
                {
                    temp = temp.Next;
                    len++;
                }

                return len;
            }
        }
    }

    public static LLNode SortZeroOneTwoLinkedList(LLNode head)
    {
        LLNode zeroFirstNode = new LLNode(-1);
        LLNode oneFirstNode = new LLNode(-1);
        LLNode twoFirstNode = new LLNode(-1);

        var temp = head;
        var zeroNode = zeroFirstNode;
        var oneNode = oneFirstNode;
        var twoNode = twoFirstNode;
        
        while (temp!=null)
        {
            if (temp.Value == 0)
            {
                zeroNode.Next = new LLNode(0);
                zeroNode = zeroNode.Next;
            }

            if (temp.Value == 1)
            {
                oneNode.Next = new LLNode(1);
                oneNode = oneNode.Next;
            }

            if (temp.Value == 2)
            {
                twoNode.Next = new LLNode(2);
                twoNode = twoNode.Next;
            }

            temp = temp.Next;
        }

        zeroNode.Next = oneFirstNode.Next;
        oneNode.Next = twoFirstNode.Next;

        return zeroFirstNode.Next;

    }

    public static bool CheckLLPalindrome(LLNode head)
    {
        LLNode slow = head;
        LLNode fast = head;

        while (fast!=null)
        {
            if (fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            else
            {
                break;
            }
        }

        LLNode mid = slow;

        LLNode prev = null;
        LLNode curr = mid.Next;

        while (curr!=null)
        {
            LLNode forward = curr.Next;
            curr.Next = prev;
            prev = curr;
            curr = forward;
        }

        slow.Next = prev;

        LLNode start = head;
        while (prev != null)
        {   
            if (prev.Value != start.Value)
            {
                return false;
            }
            start = start.Next;
            prev = prev.Next;
        }

        return true;
    }
    
    public static LLNode ReturnStartOfCycle(LLNode head)
    {
        LLNode slow = head;
        LLNode fast = head;

        while (fast!=null)
        {
            fast = fast.Next;
            if (fast != null)
            {
                fast = fast.Next;
                slow = slow.Next;
            }

            if (fast == slow)
            {
                slow = head;
                break;
            }
        }

        while (slow != fast)
        {
            slow = slow.Next;
            fast = fast.Next;
        }

        return slow;
    }
    
    public static bool IsCyclePresentInLL(LLNode head)
    {
        LLNode slow = head;
        LLNode fast = head;

        while (fast!=null)
        {
            fast = fast.Next;
            if (fast != null)
            {
                fast = fast.Next;
                slow = slow.Next;
            }

            if (fast == slow)
            {
                return true;
            }
        }

        return false;
    }
    
    public static LLNode ReverseLinkedListByKNode(LLNode head, int k)
    {
        if (head == null)
        {
            return head;
        }

        int len = head.Length;

        if (k > len)
        {
            return head;
        }
        
        //Reverse first KNode of LL

        LLNode prev = null;
        LLNode curr = head;
        LLNode forward = curr.Next;

        int count = 0;
        
        while (count<k)
        {
            forward = curr.Next;
            curr.Next = prev;
            prev = curr;
            curr = forward;
            count++;
        }

        if (forward != null)
        {
            head.Next = ReverseLinkedListByKNode(forward, k);
        }

        return prev;
    }

    public static LLNode ReverseLinkedList(LLNode head)
    {
        LLNode prevNodeReference = null;
        return ReversedLinkedList(head, prevNodeReference);
    }

    private static LLNode ReversedLinkedList(LLNode head, LLNode prevRef)
    {
        if (head is null)
        {
            return prevRef;
        }
        LLNode curr = head;
        LLNode next = curr.Next;
        curr.Next = prevRef;
        return ReversedLinkedList(next, curr);
    }
    
    public static LLNode ReverseLinkedListIteration(LLNode head)
    {
        LLNode curr = head;
        LLNode prev = null;
        LLNode forward = curr.Next;

        while (curr != null)
        {
            curr.Next = prev;
            prev = curr;
            curr = forward;
            forward = forward?.Next;
        }

        return prev;
    }

    public static LLNode RotateALinkedList(LLNode head, int k)
    {
        LLNode curr = head;
        int nodeCount = 0;
        LLNode kthNode = null;

        while (curr.Next!=null)
        {
            if (++nodeCount == k)
            {
                kthNode = curr;
            }
            curr = curr.Next;
        }

        curr.Next = head;
        head = kthNode.Next;

        kthNode.Next = null;

        return head;
    }

    public static LLNode MergeNonZeroNodes(LLNode head)
    {
        head = head.Next;
        LLNode curr = head;

        while (curr!=null)
        {
            LLNode end = curr;
            int sum = 0;
            while (end.Value!=0)
            {
                sum = sum + end.Value;
                end = end.Next;
            }

            curr.Value = sum;
            curr.Next = end.Next;
            curr = curr.Next;
        }
        
        return head;
    }

    public static LLNode MergeNodesRec(LLNode head)
    {
        if (head.Next is null)
        {
            return null;
        }

        LLNode curr = head.Next;
        int sum = 0;
        while (curr.Value!=0)
        {
            sum = sum + curr.Value;
            curr = curr.Next;
        }

        head.Next.Value = sum;
        head.Next.Next = MergeNodesRec(curr);
        return head.Next;
    }

}