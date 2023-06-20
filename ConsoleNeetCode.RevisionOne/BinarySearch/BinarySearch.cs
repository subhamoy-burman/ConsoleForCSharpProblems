using System;

namespace ConsoleNeetCode.RevisionOne.BinarySearch;

public static class BinarySearch
{
    public static int FindUpperBound(int[] arr, int target)
    {
        int low = 0;
        int high = arr.Length - 1;
        int ans = -1;

        while (low<=high)
        {
            int mid = (low + high) / 2;
            if (arr[mid] > target)
            {
                high = mid - 1;
                ans = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return ans;
    }

    public static int FindLowerBound(int[] arr, int target)
    {
        int low = 0;
        int high = arr.Length - 1;
        int ans = -1;

        while (low<=high)
        {
            int mid = (high + low) / 2;
            if (arr[mid] >= target)
            {
                ans = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return ans;
    }

    public static Tuple<int, int> FirstAndLastOccurence(int[] arr, int target)
    {
        int lowerBound = FindLowerBound(arr, target);

        if (lowerBound == -1 || arr[lowerBound] != target)
        {
            return new Tuple<int, int>(-1,-1){};
        }
        else
        {
            return new Tuple<int, int>(lowerBound, FindUpperBound(arr, target) - 1);
        }
    }
    
    
    public static Tuple<int, int> FirstAndLastOccurenceBinarySearch(int[] arr, int target)
    {
        int low = 0;
        int high = arr.Length - 1;
        int firstOccurence = -1;

        while (low<=high)
        {
            int mid = (low + high) / 2;

            if (arr[mid] == target)
            {
                high = mid - 1;
                firstOccurence = mid;
            }
            else
            {
                if (arr[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
        }
        
        low = 0;
        high = arr.Length - 1;
        int lastOccurence = -1;
        
        while (low<=high)
        {
            int mid = (low + high) / 2;

            if (arr[mid] == target)
            {
                low = mid + 1;
                lastOccurence = mid;
            }
            else
            {
                if (arr[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
        }

        return new Tuple<int, int>(firstOccurence, lastOccurence);
    }

    public static int SearchInRotatedSortedArray(int[] arr, int target)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low<=high)
        {
            int mid = (low + high) / 2;

            if (target == arr[mid])
            {
                return mid;
            }

            if (arr[low] <= arr[mid])
            {
                if (target >= arr[low] && target <= arr[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            else
            {
                if (target <= arr[high] && target >= arr[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
        }

        return -1;
    }


    public static int MinimumInRotatedSortedArray(int[] arr)
    {
        int low = 0;
        int high = arr.Length - 1;
        int ans = Int32.MaxValue;

        while (low<=high)
        {
            int mid = (high + low) / 2;

            if (arr[low] <= arr[mid])
            {
                ans = Math.Min(ans, arr[low]);
                low = mid + 1;
            }
            else
            {
                ans = Math.Min(ans, arr[mid]);
                high = mid - 1;
            }
        }

        return ans;
    }
}