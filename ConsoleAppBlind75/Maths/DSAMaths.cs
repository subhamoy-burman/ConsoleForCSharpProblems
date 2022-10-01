namespace ConsoleAppBlind75.Maths
{
    public static class DSAMaths
    {

        public static double FindSqrt(int num)
        {
            double sqrt = 0.0;
            int start = 0;
            int end = num;
            while (start<=end)
            {
                var mid = start + (end - start) / 2;
                if (mid * mid == num)
                {
                    return mid;
                }
                if(mid * mid > num)
                {
                    end = mid - 1;
                }

                if (mid * mid < num)
                {
                    start = mid + 1;
                }
            }

            sqrt = end;
            double incr = 0.1;
            
            for (int i = 0; i < 3; i++)
            {
                while (sqrt*sqrt <= num)
                {
                    sqrt = sqrt + incr;
                }

                sqrt = sqrt - incr;
                incr = incr / 10;
            }
            return sqrt;
        }

        public static int GetMissingNumber(int[] arr)
        {
            int n = arr.Length + 1;
            
            //Find the XOR sum of all numbers from 1 to n
            int x1 = 1;
            for (int i = 2; i <= n; i++)
            {
                x1 = x1 ^ i;
            }

            //Find the XOR sum
            int x2 = arr[0];
            for (int i = 1; i < n - 1; i++)
            {
                x2 = x2 ^ arr[i];
            }

            return x1 ^ x2;
        }
    }
}