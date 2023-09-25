namespace ConsoleNeetCode.RevisionOne.Heap;

public class HeapImplementation
{
    public int Size = 0;
    public int[] Arr;

    public HeapImplementation()
    {
        Arr = new int[101];
        Size = 0;
    }

    public void Insert(int value)
    {
        Size = Size + 1;
        int index = Size;
        Arr[index] = value;

        while (index >1)
        {
            int parentIndex = index / 2;

            if (Arr[index] > Arr[parentIndex])
            {
                (Arr[index], Arr[parentIndex]) = (Arr[parentIndex], Arr[index]);
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    public int Delete()
    {
        //Replace root node value with last node data
        int ans = Arr[1];
        Arr[1] = Arr[Size];
        Size--;

        int index = 1;
        while (index<Size)
        {
            int left = 2 * index;
            int right = 2 * index + 1;

            int largest = index;
            if (left < Size && Arr[index] < Arr[left])
            {
                largest = left;
            }

            if (right < Size && Arr[index] < Arr[right])
            {
                largest = right;
            }

            if (largest == index)
            {
                return ans;
            }

            (Arr[index], Arr[largest]) = (Arr[largest], Arr[index]);
            index = largest;
        }

        return ans;
    }

    public void Heapify(int[] arr, int i)
    {
        int index = i;
        
        int left = 2 * index;
        int right = 2 * index + 1;

        int largest = index;
        if (left < Size && arr[index] < arr[left])
        {
            largest = left;
        }

        if (right < Size && arr[index] < arr[right])
        {
            largest = right;
        }

        if (largest == index)
        {
            return;
        }
        else
        {
            (arr[index], arr[largest]) = (arr[largest], arr[index]);
            index = largest;
            Heapify(arr,index);
        }
    }

    public void BuildHeap(int[] arr, int n)
    {
        for (int i = n / 2; i > 0; i--)
        {
            Heapify(arr,i);
        }
    }

    public void HeapSort(int[] arr)
    {
        int index = arr.Length;
        while (index!=1)
        {
            (arr[index], arr[1]) = (arr[1], arr[index]);
            index--;
            Heapify(arr,1);
        }
    }
}