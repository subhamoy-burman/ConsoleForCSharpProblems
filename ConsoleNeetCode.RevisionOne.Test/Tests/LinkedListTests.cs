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
    
    [Test]
    public void ReverseLinkedList_WithValidInput_ReturnsReversedLinkedList()
    {
        // Arrange
        LinkedListV1.LinkedListV1.LLNode node4 = new LinkedListV1.LinkedListV1.LLNode(4);
        LinkedListV1.LinkedListV1.LLNode node3 = new LinkedListV1.LinkedListV1.LLNode(3, node4);
        LinkedListV1.LinkedListV1.LLNode node2 = new LinkedListV1.LinkedListV1.LLNode(2, node3);
        LinkedListV1.LinkedListV1.LLNode node1 = new LinkedListV1.LinkedListV1.LLNode(1, node2);
        LinkedListV1.LinkedListV1.LLNode head = node1;

        // Act
        LinkedListV1.LinkedListV1.LLNode reversedHead = LinkedListV1.LinkedListV1.ReverseLinkedList(head);

        // Assert
        Assert.AreEqual(4, reversedHead.Value);
        Assert.AreEqual(3, reversedHead.Next.Value);
        Assert.AreEqual(2, reversedHead.Next.Next.Value);
        Assert.AreEqual(1, reversedHead.Next.Next.Next.Value);
        Assert.IsNull(reversedHead.Next.Next.Next.Next);
    }
    
    [Test]
    public void ReverseLinkedList_WithEdgeCases_ReturnsReversedLinkedList()
    {
        // Case 1: Empty linked list
        LinkedListV1.LinkedListV1.LLNode emptyHead = null;

        LinkedListV1.LinkedListV1.LLNode emptyReversedHead = LinkedListV1.LinkedListV1.ReverseLinkedList(emptyHead);
        Assert.IsNull(emptyReversedHead);

        // Case 2: Single-node linked list
        LinkedListV1.LinkedListV1.LLNode singleNodeHead = new LinkedListV1.LinkedListV1.LLNode(1);

        LinkedListV1.LinkedListV1.LLNode singleNodeReversedHead = LinkedListV1.LinkedListV1.ReverseLinkedList(singleNodeHead);
        Assert.AreEqual(1, singleNodeReversedHead.Value);
        Assert.IsNull(singleNodeReversedHead.Next);

        // Case 3: Two-node linked list
        LinkedListV1.LinkedListV1.LLNode node2 = new LinkedListV1.LinkedListV1.LLNode(2);
        LinkedListV1.LinkedListV1.LLNode node1 = new LinkedListV1.LinkedListV1.LLNode(1, node2);
        LinkedListV1.LinkedListV1.LLNode twoNodeHead = node1;

        LinkedListV1.LinkedListV1.LLNode twoNodeReversedHead = LinkedListV1.LinkedListV1.ReverseLinkedList(twoNodeHead);
        Assert.AreEqual(2, twoNodeReversedHead.Value);
        Assert.AreEqual(1, twoNodeReversedHead.Next.Value);
        Assert.IsNull(twoNodeReversedHead.Next.Next);
    }
    
    [Test]
    public void ReverseLinkedListIterative_WithValidInput_ReturnsReversedLinkedList()
    {
        // Arrange
        LinkedListV1.LinkedListV1.LLNode node4 = new LinkedListV1.LinkedListV1.LLNode(4);
        LinkedListV1.LinkedListV1.LLNode node3 = new LinkedListV1.LinkedListV1.LLNode(3, node4);
        LinkedListV1.LinkedListV1.LLNode node2 = new LinkedListV1.LinkedListV1.LLNode(2, node3);
        LinkedListV1.LinkedListV1.LLNode node1 = new LinkedListV1.LinkedListV1.LLNode(1, node2);
        LinkedListV1.LinkedListV1.LLNode head = node1;

        // Act
        LinkedListV1.LinkedListV1.LLNode reversedHead = LinkedListV1.LinkedListV1.ReverseLinkedListIteration(head);

        // Assert
        Assert.AreEqual(4, reversedHead.Value);
        Assert.AreEqual(3, reversedHead.Next.Value);
        Assert.AreEqual(2, reversedHead.Next.Next.Value);
        Assert.AreEqual(1, reversedHead.Next.Next.Next.Value);
        Assert.IsNull(reversedHead.Next.Next.Next.Next);
    }
    
    [Test]
    public void ReverseLinkedListByKNode_ReversesLinkedListByKNodes()
    {
        // Arrange
        LinkedListV1.LinkedListV1.LLNode head = new LinkedListV1.LinkedListV1.LLNode(1);
        head.Next = new LinkedListV1.LinkedListV1.LLNode(2);
        head.Next.Next = new LinkedListV1.LinkedListV1.LLNode(3);
        head.Next.Next.Next = new LinkedListV1.LinkedListV1.LLNode(4);
        head.Next.Next.Next.Next = new LinkedListV1.LinkedListV1.LLNode(5);
        int k = 3;

        // Act
        LinkedListV1.LinkedListV1.LLNode result = LinkedListV1.LinkedListV1.ReverseLinkedListByKNode(head, k);

        // Assert
        Assert.AreEqual(3, result.Value);
        Assert.AreEqual(2, result.Next.Value);
        Assert.AreEqual(1, result.Next.Next.Value);
        Assert.AreEqual(4, result.Next.Next.Next.Value);
        Assert.AreEqual(5, result.Next.Next.Next.Next.Value);
    }
    
}