using System;
using System.Xml.Linq;

namespace ConsoleNeetCode.RevisionOne.DoubleEndedQueue;

public class DoubleEndedQueue
{
    public int Front { get; set; }
    public int  Rear { get; set; }
    public int[] Array { get; set; }
    public int Size { get; set; }

    public DoubleEndedQueue(int size)
    {
        Size = size;
        Array = new int[size];
        Front = -1;
        Rear = -1;
    }

    public void PushRear(int m)
    {
        if (Front == 0 && Rear == Size - 1)
        {
            Console.WriteLine("Queue is full so cant enter");
            return;
        }
        else if(Front == -1)
        {
            Front = Rear = 0;
            Array[Rear] = m;
        }
        else if(Rear == Size-1 && Front!=0)
        {
            Rear = 0;
            Array[Rear] = m;
        }
        else
        {
            Array[Rear++] = m;
        }
    }

    public void PushFront(int data)
    {
        //if(Front==0 )
    }
    
}