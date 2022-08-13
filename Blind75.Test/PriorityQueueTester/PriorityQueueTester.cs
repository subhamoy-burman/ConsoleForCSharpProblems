using ConsoleAppBlind75.ProirityQueue;
using NUnit.Framework;

namespace Blind75.Test.PriorityQueueTester
{
    [TestFixture]
    public class PriorityQueueTester
    {
        [Test]
        public void TestPriorityQueue()
        {
            PriorityQueueImplementation priorityQueueImplementation = new PriorityQueueImplementation();
            
            priorityQueueImplementation.Add(20);
            priorityQueueImplementation.Add(45);
            priorityQueueImplementation.Add(14);
            priorityQueueImplementation.Add(12);
            priorityQueueImplementation.Add(31);
            priorityQueueImplementation.Add(7);
            priorityQueueImplementation.Add(11);
            priorityQueueImplementation.Add(13);
            priorityQueueImplementation.Add(7);


            var peekElement = priorityQueueImplementation.Peek();
        }
    }
}