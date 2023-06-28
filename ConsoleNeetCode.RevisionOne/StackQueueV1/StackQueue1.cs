using System.Collections.Generic;

namespace ConsoleNeetCode.RevisionOne.StackQueueV1;

public static class StackQueue1
{
    //Stack using Queue
    //Using Two Queue

    public class StackExtend
    {
        public Queue<int> PrimaryQueue { get; set; }
        public Queue<int> AuxQueue { get; set; }

        public StackExtend()
        {
            PrimaryQueue = new Queue<int>();
            AuxQueue = new Queue<int>();
        }

        public void Push(int num)
        {
            PrimaryQueue.Enqueue(num);

            while (PrimaryQueue.Count>0)
            {
                AuxQueue.Enqueue(PrimaryQueue.Dequeue());
            }
            
            PrimaryQueue = new Queue<int>(AuxQueue);
            AuxQueue.Clear();
        }

        public int Pop()
        {
            return PrimaryQueue.Dequeue();
        }

        public void PushUsingSingleQueue(int num)
        {
            PrimaryQueue.Enqueue(num);
            int size = PrimaryQueue.Count;

            for (int i = 0; i < size-1; i++)
            {
                var element =PrimaryQueue.Dequeue();
                PrimaryQueue.Enqueue(element);
            }
        }
        
    }
}