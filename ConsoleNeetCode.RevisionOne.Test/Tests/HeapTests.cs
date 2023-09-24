using ConsoleNeetCode.RevisionOne.Heap;
using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test;

[TestFixture]
public class HeapTests
{
    [Test]
    public void TestHeapInsert()
    {
        var heapInstance = new HeapImplementation();
        heapInstance.Arr[0] = -1;
        heapInstance.Arr[1] = 100;
        heapInstance.Arr[2] = 50;
        heapInstance.Arr[3] = 60;
        heapInstance.Arr[4] = 40;
        heapInstance.Arr[5] = 45;

        heapInstance.Size = 5;
        
        heapInstance.Insert(110);
        
        
    }
}