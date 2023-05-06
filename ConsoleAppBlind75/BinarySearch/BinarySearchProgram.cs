namespace ConsoleAppBlind75.BinarySearch
{
    public static class BinarySearchProgram
    {
        public static int FindMinimumInRotatedSortedArray(int[] nums)
        {
            if(nums.Length == 1)
            {
                return nums[0];
            }
            int left = 0;
            int right = nums.Length;

            return Solve(left, right, nums);
        }

        private static int Solve(int left, int right, int[] nums)
        {
            if (nums[left] < nums[right-1])
            {
                return nums[left];
            }
            int mid = (left + right) / 2;

            if (mid+1<nums.Length && nums[mid + 1] < nums[mid])
            {
                return nums[mid+1];
            }
            if (nums[mid] > nums[left] && nums[mid] < nums[right-1])
            {
                return nums[left];
            }

            if(nums[mid]<nums[left])
            {
                return Solve(left, mid - 1, nums);
            }

            return Solve(mid + 1, right, nums);
        }
    }
}