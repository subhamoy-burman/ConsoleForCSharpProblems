using ConsoleAppBlind75.FastSlowPointer;
using NUnit.Framework;

namespace Blind75.Test.FastSlowPointerTest
{
    [TestFixture]
    public class DetectCycleStartAtLinkedListTester
    {
        [Test]
        public void DetectCycleStartAtLinkedListTester1()
        {
            ListNode head = new ListNode(1);
            head.Next = new ListNode(2);
            head.Next.Next = new ListNode(3);
            head.Next.Next.Next = new ListNode(4);
            head.Next.Next.Next.Next = new ListNode(5);
            head.Next.Next.Next.Next.Next = new ListNode(6);

            head.Next.Next.Next.Next.Next.Next = head.Next.Next;

            var cycleStartNode = new DetectCycleStartAtLinkedList().Execute(head);
            
            Assert.AreEqual(cycleStartNode.value, 3);
        }
    }
}