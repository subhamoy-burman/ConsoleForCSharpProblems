namespace ConsoleAppBlind75.BinarySearch
{
    public static  class PeakIndexOfMountainArray
    {
        public static  int PeakIndexInMountainArray(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;

            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                if (arr[mid] > arr[mid + 1])
                {
                    if (arr[mid - 1] < arr[mid])
                    {
                        return mid;
                    }

                    end = mid;
                }
                else
                {
                    start = mid;
                }
            }

            return -1;
        }
        
        public static int FindInMountainArray(int[] arr, int target) {
        
            int peakIndex = -1;
        
            int start = 0;
            int end = arr.Length - 1;

            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                if (arr[mid] > arr[mid + 1])
                {
                    if (arr[mid - 1] < arr[mid])
                    {
                        peakIndex = mid;
                        break;
                    }

                    end = mid;
                }
                else
                {
                    start = mid;
                }
            }
        
            start = 0;
            end = peakIndex;
        
            while(start<=end)
            {
                var mid = start + (end-start)/2;
            
                if(arr[mid] == target)
                {
                    return mid;
                }
                if(target>arr[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid -1;
                }
            }
        
            start = peakIndex+1;
            end = arr.Length - 1;
        
            while(start<=end)
            {
                var mid = start + (end-start)/2;
            
                if(arr[mid] == target)
                {
                    return mid;
                }
                if(target<arr[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid -1;
                }
            }
        
            return -1;
        }
    }
}