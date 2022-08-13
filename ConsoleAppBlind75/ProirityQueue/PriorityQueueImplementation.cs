using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConsoleAppBlind75.ProirityQueue
{
    public class PriorityQueueImplementation
    {
        private static List<int> heapData;

        public PriorityQueueImplementation()
        {
            heapData = new List<int>();
        }

        public void Add(int val)
        {
            heapData.Add(val);
            UpHeapify(heapData.Count-1);
        }

        private void UpHeapify(int index)
        {
            if (index == 0)
            {
                return;
            }
            int parentIndex = (index - 1) / 2;

            if (heapData[index] < heapData[parentIndex])
            {
                Swap(index, parentIndex);
                UpHeapify(parentIndex);
            }   
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            int firstIndexVal = heapData[firstIndex];
            int secondIndexVal = heapData[secondIndex];

            heapData[firstIndex] = secondIndexVal;
            heapData[secondIndex] = firstIndexVal;
        }

        public int Remove()
        {
            if (Size() == 0)
            {
                Debug.WriteLine("Underflow");
                return -1;
            }
            Swap(0, heapData.Count - 1);
            int val = heapData[heapData.Count - 1];
            heapData.RemoveAt(heapData.Count - 1);
            DownHeapify(0);
            return val;
        }

        private void DownHeapify(int parentIndex)
        {   
            int min = parentIndex;

            int leftChildIndex = 2 * parentIndex + 1;
            if (leftChildIndex < heapData.Count && heapData[leftChildIndex] < heapData[min])
            {
                min = leftChildIndex;
            }
            
            int rightChildIndex = 2 * parentIndex + 2;
            if (rightChildIndex < heapData.Count && heapData[rightChildIndex] < heapData[min])
            {
                min = leftChildIndex;
            }

            if (min != parentIndex)
            {
                Swap(parentIndex,min);
                DownHeapify(min);
            }
        }

        public int Peek()
        {
            if (Size() != 0) return heapData.FirstOrDefault();
            Debug.WriteLine("Underflow");
            return -1;

        }

        private int Size()
        {
            return heapData.Count;
        }

    }
    
}