using System;
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

    public class TwoStackUsingAnArray
    {
        public int[] arr { get; set; }
        public int Size { get; set; }
        public int Top1 { get; set; }
        public int Top2 { get; set; }

        public TwoStackUsingAnArray(int size)
        {
            arr = new int[size];
            Size = size;
            Top1 = -1;
            Top2 = size;
        }

        void Push1(int item)
        {
            if (Top2 - Top1 == 1)
            {
                return;
            }

            arr[++Top1] = item;
        }

        void Push2(int item)
        {
            if (Top2 - Top1 == 1)
            {
                return;
            }

            arr[--Top2] = item;
        }

        void Pop1()
        {
            if (Top1 == -1)
            {
                //underflow
                return;
            }

            Top1--;
        }

        void Pop2()
        {
            if (Top2 == Size)
            {
                //underflow
                return;
            }

            Top2++;
        }
        
    }

    public static int FindMiddleElementOfStack(Stack<int> inputStack)
    {
        int targetSize = (int)Math.Ceiling((double)inputStack.Count/2);
        return FuncFindMidElementOfStack(targetSize, inputStack);
    }

    private static int FuncFindMidElementOfStack(int targetSize,  Stack<int> inputStack)
    {
        if (inputStack.Count == targetSize)
        {
            return inputStack.Peek();
        }

        var temp = inputStack.Pop();

        var value = FuncFindMidElementOfStack(targetSize, inputStack);
        inputStack.Push(temp);
        return value;
    }
    
    public static int LongestValidParentheses(string s)
    {
        Stack<int> stack = new();
        int max = Int32.MinValue;
        stack.Push(-1);

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                stack.Push(i);
            }
            else
            {
                stack.Pop();
                if(stack.Count>0)
                     max = Math.Max(max,i - stack.Peek());
            }

            if (stack.Count == 0)
            {
                stack.Push(i);
            }
        }

        return max == Int32.MaxValue ? 0 : max;
    }

    public static int[] NextSmallerElements(int[] arr)
    {
        Stack<int> elementStack = new Stack<int>();
        int k = arr.Length;
        int[] outputArray = new int[k];
        elementStack.Push(-1);
        elementStack.Push(arr[k-1]);
        outputArray[--k] = -1;

        for (int i = arr.Length - 2; i >= 0; i--)
        {
            if (arr[i] >= elementStack.Peek())
            {
                outputArray[--k] = elementStack.Peek();
                elementStack.Push(arr[i]);
            }
            else
            {
                while (elementStack.Peek()> arr[i])
                {
                    elementStack.Pop();
                }
                outputArray[--k] = elementStack.Peek();
                elementStack.Push(arr[i]);
            }
        }

        return outputArray;
    }
}