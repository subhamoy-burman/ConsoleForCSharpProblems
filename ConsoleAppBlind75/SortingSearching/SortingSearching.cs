namespace ConsoleAppBlind75.SortingSearching
{
    public class SortingSearching
    {
        public static int[] SelectionSort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int minIndex = i;
                for (int j = i; j < input.Length; j++)
                {
                    if (input[j] < input[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // ReSharper disable once SwapViaDeconstruction
                var temp = input[minIndex];
                input[minIndex] = input[i];
                input[i] = temp;
            }

            return input;
        }
    }
}