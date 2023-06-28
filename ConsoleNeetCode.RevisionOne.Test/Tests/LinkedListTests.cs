using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test;

[TestFixture]
public class LinkedListTests
{

    [Test]
    public void LinkedListInit()
    {
        LinkedListV1.LinkedListV1.DoubleLLNode doubleLLNode1 = new LinkedListV1.LinkedListV1.DoubleLLNode(10);
        LinkedListV1.LinkedListV1.DoubleLLNode doubleLLNode2 = new LinkedListV1.LinkedListV1.DoubleLLNode(20);
        LinkedListV1.LinkedListV1.DoubleLLNode doubleLLNode3 = new LinkedListV1.LinkedListV1.DoubleLLNode(30);

        doubleLLNode1.Next = doubleLLNode2;
        doubleLLNode2.Prev = doubleLLNode1;

        doubleLLNode2.Next = doubleLLNode3;
        doubleLLNode3.Prev = doubleLLNode2;

        LinkedListV1.LinkedListV1.DoubleLLNode head = doubleLLNode1;
        LinkedListV1.LinkedListV1.DoubleLLNode tail = doubleLLNode3;
        
        doubleLLNode1.PrintDoubleLL(head);
        
        doubleLLNode1.InsertAtHead(ref head, tail, 5);
        doubleLLNode1.PrintDoubleLL(head);
        doubleLLNode1.InsertAtTail(ref head, tail, 50);
    }
    
}