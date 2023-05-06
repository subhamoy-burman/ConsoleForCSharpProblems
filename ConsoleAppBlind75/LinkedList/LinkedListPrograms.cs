using System.Net.Security;

namespace ConsoleAppBlind75.LinkedList
{
    public class LinkedList
    {
        public static LLNode Head;

        public class LLNode
        {
            public int Data { get; set; }
            public LLNode Next { get; set; }

            public LLNode(int data)
            {
                Data = data;
                Next = null;
            }
        }

        public static class LinkedListPrograms
        {
            public static LLNode ReverseLinkedList(LLNode node)
            {
                Head = node;
                LLNode prev = null;

                while (node != null)
                {
                    // ReSharper disable once SwapViaDeconstruction
                    LLNode auxNode = node.Next;

                    node.Next = prev;
                    prev = node;
                    node = auxNode;
                }

                Head = prev;
                return Head;
            }

            public static LLNode MergeSortedLinkedList(LLNode node1, LLNode node2)
            {
                LLNode resultNode = new LLNode(0);
                LLNode tail = resultNode;

                while (node1 != null || node2 != null)
                {
                    if (node2 is null)
                    {
                        tail.Next = node1;
                        break;
                    }

                    if (node1 is null)
                    {
                        tail.Next = node2;
                        break;
                    }

                    if (node1.Data <= node2.Data)
                    {
                        tail.Next = node1;
                        node1 = node1.Next;
                    }
                    else if (node2.Data < node1.Data)
                    {
                        tail.Next = node2;
                        node2 = node2.Next;
                    }

                    tail = tail.Next;

                }

                return resultNode.Next;
            }

            public static int GetNodeSum(LLNode node, int sum, int carry = 0)
            {
                if (node is null)
                {
                    return sum;
                }

                return GetNodeSum(node.Next, sum * 10 + node.Data);
            }

            public static int GetSumOfNodes(LLNode node1, LLNode node2)
            {
                int sum = 0;
                return GetNodeSum(node1, sum) + GetNodeSum(node2, sum);
            }

            public static LLNode ReturnLinkedListIntersectionPoint(LLNode head1, LLNode head2)
            {
                while (head2 != null)
                {
                    LLNode temp = head1;
                    while (temp != null)
                    {
                        // if both Nodes are same
                        if (temp == head2)
                        {
                            return head2;
                        }

                        temp = temp.Next;
                    }

                    head2 = head2.Next;
                }

                return null;
            }

            public static LLNode tempTail = null;
            
            public static LLNode MergeSortedLL2(LLNode node1, LLNode node2)
            {
                if (node1 is null)
                {
                    return node2;
                }

                if (node2 is null)
                {
                    return node1;
                }

                while (node1!=null || node2!=null)
                {
                    if (node1 is null)
                    {
                        tempTail.Next = node2;
                        return tempTail;
                    }

                    if (node2 is null)
                    {
                        tempTail.Next = node1;
                        return tempTail;
                    }

                    if (node1.Data >= node2.Data)
                    {
                        AddLast(node2);
                        node2 = node2.Next;
                        continue;
                    }

                    AddLast(node1);
                    node1 = node1.Next;
                }

                return tempTail;
            }

            private static void AddLast(LLNode node)
            {
                if (tempTail == null)
                {
                    tempTail = new LLNode(node.Data);
                }
                else
                {
                    tempTail.Next = new LLNode(node.Data);
                }
            }

            public static LLNode AddTwoLLNumbers(LLNode node1, LLNode node2)
            {
                int carry = 0;
                LLNode resultHead = new LLNode(0);
                LLNode result = resultHead;
                while (node1 != null || node2 != null)
                {
                    int node1Val = 0;
                    int node2Val = 0;
                    int sum = 0;

                    
                    if (node1 != null)
                    {
                        node1Val = node1.Data;
                        node1 = node1.Next;
                    }

                    if (node2!= null)
                    {
                        node2Val = node2.Data;
                        node2 = node2.Next;
                    }
                    
                    var localSum = node1Val + node2Val + carry;

                    if (localSum >= 10)
                    {
                        sum = (localSum - 10);
                        carry = localSum / 10;
                    }
                    else
                    {
                        sum = localSum;
                        carry = 0;
                    }

                    result.Next = new LLNode(sum);
                    result = result.Next;
                }

                return resultHead.Next;
            }
        }
    }
}
    
    
