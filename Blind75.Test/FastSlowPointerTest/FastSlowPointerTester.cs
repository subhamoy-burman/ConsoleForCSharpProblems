using ConsoleAppBlind75.FastSlowPointer;
using NUnit.Framework;

namespace Blind75.Test.FastSlowPointerTest
{
    [TestFixture]
    public class FastSlowPointerTester
    {
        [Test]
        public void FastSlowPointerRunTest1()
        {
            ListNode head = new ListNode(1);
            head.Next = new ListNode(2);
            head.Next.Next = new ListNode(3);
            head.Next.Next.Next = new ListNode(4);
            head.Next.Next.Next.Next = new ListNode(5);
            head.Next.Next.Next.Next.Next = new ListNode(6);

            var isCycleExists = false;//new DetectCycleInLinkedList().Execute(head);
            
            //Assert.IsFalse(isCycleExists);

            head.Next.Next.Next.Next.Next.Next = head.Next.Next;
            
            isCycleExists = new DetectCycleInLinkedList().Execute(head);

            Assert.IsTrue(isCycleExists);
            
            head.Next.Next.Next.Next.Next.Next = head.Next.Next.Next;
            
            isCycleExists = new DetectCycleInLinkedList().Execute(head);

            Assert.IsTrue(isCycleExists);

        }
    }
}