namespace ConsoleAppBlind75.TwoPointer
{
    public class CountDuplicates
    {
        public int Execute(int[] arr)
        {
            int i = 0;
            int j = 1;
            int numberOfDuplicates = 0;

            while (i<arr.Length && j<arr.Length)
            {
                if (arr[i] == arr[j])
                {
                    numberOfDuplicates++;
                    i = j;
                    j++;
                    continue;
                }

                i++;
                j++;
            }
            return numberOfDuplicates;
        }

        public int Execute2(int[] arr)
        {
            int currentUniqueElementIndex = 0;
            int currentProcessedIndex = 0;

            while (currentProcessedIndex<arr.Length)
            {
                if (arr[currentUniqueElementIndex]!= arr[currentProcessedIndex])
                {
                    currentUniqueElementIndex++;
                    arr[currentUniqueElementIndex] = arr[currentProcessedIndex];
                }
                currentProcessedIndex++;
            }

            return currentUniqueElementIndex;
        }
    }
}