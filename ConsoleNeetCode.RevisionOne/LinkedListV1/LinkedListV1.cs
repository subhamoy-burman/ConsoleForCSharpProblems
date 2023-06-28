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
    
}