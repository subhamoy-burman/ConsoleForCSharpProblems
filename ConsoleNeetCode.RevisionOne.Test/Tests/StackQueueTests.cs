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
}