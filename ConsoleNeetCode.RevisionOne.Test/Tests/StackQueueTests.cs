using System.Collections.Generic;
using ConsoleNeetCode.RevisionOne.StackQueueV1;
using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test;

[TestFixture]
public class StackQueueTests
{
    [Test]
    public void TestPushInStackUsingQueue()
    {
        var stackExtend = new StackQueue1.StackExtend();
        stackExtend.Push(1);
        stackExtend.Push(4);
        stackExtend.Push(3);
        stackExtend.Push(8);

        var poppedValue = stackExtend.Pop();
    }
    
    [Test]
    public void FindMiddleElementOfStack_StackWithOddCount_ReturnsMiddleElement()
    {
        // Arrange
        Stack<int> stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);

        // Act
        int result = StackQueue1.FindMiddleElementOfStack(stack);

        // Assert
        Assert.AreEqual(3, result);
    }
}