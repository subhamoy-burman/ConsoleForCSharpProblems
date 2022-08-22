namespace ConsoleAppBlind75.BinarySearch
{
    public static class SmallestLetterGreaterThanTarget
    {
        public static char GetSmallestLetterGreaterThanTarget(char[] letters, char target)
        {
            int start = 0;
            int end = letters.Length - 1;
            int mid = start;
        

            if (target >= letters[end])
            {
                return letters[0];
            }
            while(start<end)
            {
                mid = start + (end - start)/2;
                
                if (target>=letters[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
                
            }
        
            return letters[start];
        }
    }
}