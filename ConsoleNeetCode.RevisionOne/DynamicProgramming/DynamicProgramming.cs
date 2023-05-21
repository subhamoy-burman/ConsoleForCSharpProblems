using System.Globalization;

namespace ConsoleNeetCode.RevisionOne.DynamicProgramming
{
    public static class DynamicProgramming
    {
        public static int ClimbingStairsRecursionCount(int noOfStairs)
        {
            if (noOfStairs == 0 || noOfStairs == 1)
            {
                return 1;
            }

            if (noOfStairs == 2)
            {
                return 2;
            }

            return ClimbingStairsRecursionCount(noOfStairs - 1) + ClimbingStairsRecursionCount(noOfStairs - 2);
        }

        public static int ClimbingStairsUsingMemoization(int noOfStairs)
        {
            int[] resultArray = new int[noOfStairs+1];

            resultArray[0] = 0;
            resultArray[1] = 1;

            for (int i = 2; i <= noOfStairs; i++)
            {
                resultArray[i] = resultArray[i - 1] + resultArray[i - 2];
            }

            return resultArray[noOfStairs];
        }

        public static int MinCostInClimbingNoOfStairs(int[] costOfClimbing)
        {
            return 1;
        }
    }
    
}