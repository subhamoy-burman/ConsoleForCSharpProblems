namespace ConsoleAppBlind75.TwoPointer
{
    public static class TwoPointer
    {
        public static int RemoveDuplicates(int[] arr)
        {
            int nextNonDuplicate = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[nextNonDuplicate - 1] != arr[i])
                {
                    arr[nextNonDuplicate++] = arr[i];
                }
            }

            return nextNonDuplicate;
        }
        
        public static int FindUnsortedSubarray(int[] nums)
        {

            int startIndex = 0;
            int endIndex = nums.Length - 1;
            bool isStartSet = false;
            bool isEndSet = false;

            while (startIndex<=endIndex)
            {
                if (!isStartSet)
                {   
                    if (nums[startIndex] > nums[startIndex + 1])
                    {
                        isStartSet = true;
                    }
                    else
                    {
                        startIndex++;
                    }
                }

                if (!isEndSet)
                {
                    if (nums[endIndex] < nums[endIndex - 1])
                    {
                        isEndSet = true;
                    }
                    else
                    {
                        endIndex--;
                    }
                }
                
                if(isStartSet && isEndSet) break;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == nums[startIndex])
                {
                    startIndex = i;
                    break;
                }
            }

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] == nums[endIndex])
                {
                    endIndex = i;
                    break;
                }
            }
            return startIndex>=endIndex?0: endIndex - startIndex + 1;

        }
    }
}