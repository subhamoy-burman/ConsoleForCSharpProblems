using System;

namespace ConsoleAppBlind75.DynamicProgramming
{
    public static class DynamicProgramming
    {
        public static int MinimumMovesToClimbStairs(int numberOfSteps, int[] givenSteps)
        {
            int?[] dpArray = new int?[numberOfSteps + 1];

            dpArray[numberOfSteps] = 0;

            for (int i = numberOfSteps - 1; i >= 0; i--)
            {
                if (givenSteps[i] > 0)
                {
                    int min = Int32.MaxValue;

                    for (int j = 1; j <= givenSteps[i] && i + j < dpArray.Length; j++)
                    {
                        if (dpArray[i + j] != null)
                        {
                            min = Math.Min(min, dpArray[i + j].Value);
                        }
                    }

                    if (min != Int32.MaxValue)
                    {
                        dpArray[i] = min + 1;
                    }
                }
            }

            return dpArray[0].Value;
        }

        public static int PathWithMaximumGold(int[,] goldPaths)
        {
            int[,] goldDpPaths = new int[,] { };

            for (int j = goldDpPaths.GetLength(1) - 1; j <= 0; j--)
            {
                for (int i = 0; i < goldDpPaths.GetLength(0); i++)
                {
                    
                }
            }

            return -1;
        }

        public static int NumberOfWaysToClimbStairs(int numberOfStairs, int[] dynArray)
        {
            if (dynArray[numberOfStairs] != -1)
            {
                return dynArray[numberOfStairs];
            }
            if (numberOfStairs == 0)
            {
                dynArray[0] = 1;
            }

            if (numberOfStairs == 1)
            {
                dynArray[1] = 1;
            }

            if (numberOfStairs == 2)
            {
                dynArray[2] = 2;
            }

            return NumberOfWaysToClimbStairs(numberOfStairs - 1, dynArray) + NumberOfWaysToClimbStairs(numberOfStairs - 2, dynArray) 
                                                                           + NumberOfWaysToClimbStairs(numberOfStairs-3, dynArray);
                
            

            return -1; //NumberOfWaysToClimbStairs(numberOfStairs - 1) + NumberOfWaysToClimbStairs(numberOfStairs - 2);
        }
    }
}