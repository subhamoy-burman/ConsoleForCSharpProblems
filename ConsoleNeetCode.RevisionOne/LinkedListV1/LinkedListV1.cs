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

    
}