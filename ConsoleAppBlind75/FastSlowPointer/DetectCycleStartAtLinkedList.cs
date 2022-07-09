namespace ConsoleAppBlind75.FastSlowPointer
{
    
    public class DetectCycleStartAtLinkedList
    {
        public ListNode Execute(ListNode head)
        {
            ListNode firstPointer = head;
            ListNode secondPointer = head;
            ListNode currentPointerToReturn = null;
            int cycleLength = 0;
            
            while (firstPointer!= null && secondPointer!=null && firstPointer.Next != null && secondPointer.Next !=  null)
            {
                firstPointer = firstPointer.Next;
                secondPointer = secondPointer.Next.Next;

                if (firstPointer == secondPointer)
                {
                    currentPointerToReturn = firstPointer;
                    break;
                }
            }

            currentPointerToReturn = currentPointerToReturn?.Next;
            cycleLength++;
            
            while (currentPointerToReturn!=firstPointer)
            {
                cycleLength++;
                if (currentPointerToReturn != null)
                    currentPointerToReturn = currentPointerToReturn.Next;
            }

            ListNode slowPointer = head;
            ListNode fastPointer = head;
            while (cycleLength!=0)
            {
                fastPointer = fastPointer.Next;
                cycleLength--;
            }

            while (slowPointer!=fastPointer)
            {
                slowPointer = slowPointer.Next;
                fastPointer = fastPointer.Next;
            }
            
            return slowPointer;
        }
    }
}