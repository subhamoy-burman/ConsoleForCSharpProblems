namespace ConsoleAppBlind75.TwoPointer
{
    public class PairWithTargetSum
    {
        public int[] Execute(int[] arr, int targetSum)
        {
            int startIndex = 0;
            int endIndex = arr.Length - 1;
            int[] resultArray = new int[2];

            while (startIndex< endIndex)
            {
                int currentSum = arr[startIndex] + arr[endIndex];

                if (currentSum == targetSum)
                {
                    resultArray[0] = startIndex;
                    resultArray[1] = endIndex;
                    break;
                }

                if (currentSum > targetSum)
                {
                    endIndex--;
                    continue;
                }

                if (currentSum < targetSum)
                {
                    startIndex++;
                }
            }

            return resultArray;
        }
        
    }
}