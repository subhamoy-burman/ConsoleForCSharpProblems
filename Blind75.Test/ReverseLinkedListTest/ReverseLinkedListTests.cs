using ConsoleAppBlind75.ReverseLinkedList;
using NUnit.Framework;

namespace Blind75.Test.ReverseLinkedListTest
{
    [TestFixture]
    public class ReverseLinkedListTests
    {
        [Test]
        public void LinkedListTester1()
        {
            LinkedListNode node = new LinkedListNode(2)
            {
                Next = new LinkedListNode(4)
                {
                    Next = new LinkedListNode(6)
                    {
                        Next = new LinkedListNode(8)
                        {
                            Next = new LinkedListNode(10)
                        }
                    }
                }
            };

            var resultLinkedList = new ReverseALinkedList().Execute(node);
            Assert.AreEqual(resultLinkedList.Value, 10);
        }
        
        [Test]
        public void LinkedListTester2()
        {
            LinkedListNode node = new LinkedListNode(1)
            {
                Next = new LinkedListNode(2)
                {
                    Next = new LinkedListNode(3)
                    {
                        Next = new LinkedListNode(10)
                        {
                            Next = new LinkedListNode(15)
                            {
                                Next = new LinkedListNode(21)
                                {
                                    Next = new LinkedListNode(72)
                                }
                            }
                        }
                    }
                }
            };

            var resultLinkedList = new ReverseALinkedList().ReverseALinkedListUsingAddFirst(node);
            Assert.AreEqual(resultLinkedList.Value, 10);
        }
        
        [Test]
        public void LinkedListTester3()
        {
            LinkedListNode node = new LinkedListNode(1)
            {
                Next = new LinkedListNode(2)
                {
                    Next = new LinkedListNode(3)
                    {
                        Next = new LinkedListNode(10)
                        {
                            Next = new LinkedListNode(15)
                            {
                                Next = new LinkedListNode(21)
                                {
                                    Next = new LinkedListNode(72)
                                }
                            }
                        }
                    }
                }
            };

            var resultLinkedList = new ReverseALinkedList().ReverseKNode(node,3);
            Assert.AreEqual(resultLinkedList.Value, 10);
        }
    }
}