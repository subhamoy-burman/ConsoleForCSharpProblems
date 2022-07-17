using System.Linq.Expressions;

namespace ConsoleAppBlind75.ReverseLinkedList
{
    public class LinkedListNode
    {
        public int Value { get; set; }
        public LinkedListNode Next { get; set; }

        public LinkedListNode(int value)
        {
            Value = value;
        }
    }
    public class ReverseALinkedList
    {
        public LinkedListNode Execute(LinkedListNode head)
        {
            if (head == null || head.Next == null)
                return head;
            LinkedListNode previous = null;
            LinkedListNode current = head;

            while (current!=null)
            {
                var temp = current.Next;
                current.Next = previous;
                previous = current;
                current = temp;
            }

            return previous;
        }

        public LinkedListNode ReverseALinkedListSubList(LinkedListNode head, int start, int end)
        {
            if (head == null || head.Next == null)
                return head;

            LinkedListNode current = head;
            int nodeIndex = 0;
            LinkedListNode previous = null;

            while (current!=null && nodeIndex<start-1)
            {
                previous = current;
                current = current.Next;
                nodeIndex++;
            }
            
            LinkedListNode startNodeBeforeReversal = previous;
            LinkedListNode lastNodePostReversal = current;
            
            while (nodeIndex< end-1 && current!= null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
                nodeIndex++;
            }

            startNodeBeforeReversal.Next = previous;
            lastNodePostReversal.Next = current;

            return null;
        }

        public LinkedListNode ReverseALinkedListUsingAddFirst(LinkedListNode head)
        {
            LinkedListNode current = head;
            while (current!=null)
            {
                LinkedListNode forwardLL = current.Next;
                current.Next = null;
                AddFirst(current);
                current = forwardLL;
            }

            return LLHead;
        }

        private static LinkedListNode LLHead = null;
        private static LinkedListNode LLTail = null;
        
        public static void AddFirst(LinkedListNode node)
        {
            if (LLHead == null)
            {
                LLHead = node;
                LLTail = node;
            }
            else
            {
                node.Next = LLHead;
                LLHead = node;
            }
        }

        public static int GetLinkedListLength(LinkedListNode node)
        {
            int length = 0;
            var current = node;

            while (current!=null)
            {
                current = current.Next;
                length++;
            }

            return length;
        }

        public LinkedListNode ReverseKNode(LinkedListNode head, int k)
        {
            if (head == null || head.Next == null)
                return head;
            int llLength = GetLinkedListLength(head);
            int nodeIndex = 0;
            LinkedListNode originalHead = null;
            LinkedListNode originalTail = null;
            
            LinkedListNode currNode = head;
            while (llLength >= k)
            {
                int tempK = k;
                while (tempK>0)
                {
                    LinkedListNode forwardNode = currNode.Next;
                    currNode.Next = null;
                    AddFirst(currNode);
                    currNode = forwardNode;
                    tempK--;
                }

                if (originalHead == null)
                {
                    originalHead = LLHead;
                    originalTail = LLTail;
                }
                else
                {
                    originalTail.Next = LLHead;
                    originalTail = LLTail;
                }

                LLHead = null;
                LLTail = null;
                llLength -= k;
            }

            originalTail.Next = currNode;
            return originalHead;
        }
    }
}