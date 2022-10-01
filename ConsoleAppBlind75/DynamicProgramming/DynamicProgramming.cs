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
    }
}