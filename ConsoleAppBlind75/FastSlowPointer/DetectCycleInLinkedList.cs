using System.Reflection;

namespace ConsoleAppBlind75.FastSlowPointer
{
    public class ListNode
    {
        public int value;
        public ListNode Next;

        public ListNode(int value)
        {
            this.value = value;
        }
    }
    
    public class DetectCycleInLinkedList
    {
        public bool Execute(ListNode head)
        {
            ListNode firstNode = head;
            ListNode secondNode = head;

            while (firstNode != null && secondNode != null && firstNode.Next != null && secondNode.Next != null)
            {
                firstNode = firstNode.Next;
                if (secondNode.Next != null ) 
                    secondNode = secondNode.Next.Next;

                if (firstNode == secondNode)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}