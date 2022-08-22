using System.Linq.Expressions;

namespace ConsoleAppBlind75.BinarySearch
{
    public static class FindStartEndIndexOfSortedArray
    {
        public static int[] StartEndIndexOfSortedArray(int[] nums, int target)
        {
            int[] ans = new[] {-1, -1};

            var firstIndex = ReturnIndex(nums, target, true);
            var lastIndex = ReturnIndex(nums, target, false);
            ans[0] = firstIndex;
            ans[1] = lastIndex;

            return ans;
        }

        private static int ReturnIndex(int[] nums, int target, bool isFirstIndexRequired)
        {
            var start = 0;
            var end = nums.Length - 1;
            var ans = -1;
            
            while(start <= end)
            {
                var mid = start + (end - start) / 2;
                if (target < nums[mid])
                {
                    end = mid-1;
                }
                else if(target > nums[mid])
                {
                    start = mid+1;
                }
                else
                {
                    ans = mid;
                    if (isFirstIndexRequired)
                    {
                        end = mid-1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
            }

            return ans;

        }
    }
}