using ConsoleAppBlind75.LinkedList;
using NUnit.Framework;

namespace Blind75.Test.LinkedListTests
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void TestReverseLinkedList()
        {
            LinkedList.LLNode llNode = new LinkedList.LLNode(85);
            llNode.Next = new LinkedList.LLNode(15);
            llNode.Next.Next = new LinkedList.LLNode(4);
            llNode.Next.Next.Next = new LinkedList.LLNode(20);

            var node = LinkedList.LinkedListPrograms.ReverseLinkedList(llNode);
        }

        [Test]
        public void TestMergeSortedLinkedList()
        {
            LinkedList.LLNode llNode1 = new LinkedList.LLNode(5);
            llNode1.Next = new LinkedList.LLNode(10);
            llNode1.Next.Next = new LinkedList.LLNode(15);

            LinkedList.LLNode llNode2 = new LinkedList.LLNode(2);
            llNode2.Next = new LinkedList.LLNode(3);
            llNode2.Next.Next = new LinkedList.LLNode(20);

            var resultList = LinkedList.LinkedListPrograms.MergeSortedLinkedList(llNode1, llNode2);
        }

        [Test]
        public void TestGetSumOfNodes()
        {
            LinkedList.LLNode llNode1 = new LinkedList.LLNode(3);
            llNode1.Next = new LinkedList.LLNode(4);
            llNode1.Next.Next = new LinkedList.LLNode(2);

            LinkedList.LLNode llNode2 = new LinkedList.LLNode(4);
            llNode2.Next = new LinkedList.LLNode(6);
            llNode2.Next.Next = new LinkedList.LLNode(5);

            var result = LinkedList.LinkedListPrograms.GetSumOfNodes(llNode1, llNode2);
        }
        
        [Test]
        public void TestGetIntersectionPoint()
        {
            LinkedList.LLNode llNode1 = new LinkedList.LLNode(3);
            llNode1.Next = new LinkedList.LLNode(6);
            llNode1.Next.Next = new LinkedList.LLNode(9);
            llNode1.Next.Next.Next = new LinkedList.LLNode(15);
            llNode1.Next.Next.Next.Next = new LinkedList.LLNode(30);

            LinkedList.LLNode llNode2 = new LinkedList.LLNode(10);
            llNode2.Next = new LinkedList.LLNode(15);
            llNode2.Next.Next = new LinkedList.LLNode(30);

            var result = LinkedList.LinkedListPrograms.ReturnLinkedListIntersectionPoint(llNode1, llNode2);
        }
        
        [Test]
        public void TestMergeSortedLinkedList2()
        {
            LinkedList.LLNode llNode1 = new LinkedList.LLNode(5);
            llNode1.Next = new LinkedList.LLNode(10);
            llNode1.Next.Next = new LinkedList.LLNode(15);

            LinkedList.LLNode llNode2 = new LinkedList.LLNode(2);
            llNode2.Next = new LinkedList.LLNode(3);
            llNode2.Next.Next = new LinkedList.LLNode(20);

            var resultList = LinkedList.LinkedListPrograms.MergeSortedLL2(llNode1, llNode2);
        }

        [Test]
        public void TestAddTwoLLNumbers()
        {
            LinkedList.LLNode llNode1 = new LinkedList.LLNode(2);
            llNode1.Next = new LinkedList.LLNode(4);
            llNode1.Next.Next = new LinkedList.LLNode(3);

            LinkedList.LLNode llNode2 = new LinkedList.LLNode(5);
            llNode2.Next = new LinkedList.LLNode(6);
            llNode2.Next.Next = new LinkedList.LLNode(2);

            var result = LinkedList.LinkedListPrograms.AddTwoLLNumbers(llNode1, llNode2);
        }
    }
}