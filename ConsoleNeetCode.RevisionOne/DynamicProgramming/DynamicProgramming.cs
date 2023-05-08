using System;
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

        public static int HouseRobber(int[] houseList)
        {
            var maxRobbed = HouseRobberSolve(houseList, houseList.Length-1);
            return maxRobbed;
        }
        
        public static int HouseRobberDP(int[] houseList)
        {
            int[] dpArray = new int[houseList.Length];
            var maxRobbed = HouseRobberSolveDP(houseList, dpArray);
            return maxRobbed;
        }
        
        public static int HouseRobberMemo(int[] houseList)
        {
            int[] dpArray = new int[houseList.Length];
            Array.Fill(dpArray,-1);
            var maxRobbed = HouseRobberSolveMemo(houseList, houseList.Length - 1, dpArray);
            return maxRobbed;
        }

        private static int HouseRobberSolve(int[] houseList, int houseIndex)
        {
            if (houseIndex < 0)
            {
                return 0;
            }

            if (houseIndex == 0 || houseIndex == 1)
            {
                return houseList[houseIndex];
            }

            return Math.Max(HouseRobberSolve(houseList, houseIndex-1), HouseRobberSolve(houseList, houseIndex-2) + houseList[houseIndex]);
        }

        private static int HouseRobberSolveDP(int[] houseList, int[] dpArray)
        {
            dpArray[0] = houseList[0];
            dpArray[1] = houseList[1];
            for (int i = 2; i < dpArray.Length; i++)
            {
                dpArray[i] = Math.Max(dpArray[i - 1], dpArray[i - 2] + houseList[i]);
            }

            return dpArray[houseList.Length-1];
        }

        private static int HouseRobberSolveMemo(int[] houseList, int index, int[] dpArray)
        {
            if (index == 0 || index == 1)
            {
                return dpArray[index] = houseList[index];
            }
            
            if (dpArray[index] != -1)
            {
                return dpArray[index];
            }

            int result = Math.Max(HouseRobberSolveMemo(houseList, index-1, dpArray),
                HouseRobberSolveMemo(houseList, index - 2 , dpArray)+ houseList[index]);

            dpArray[index] = result;
            return result;
        }
    }
    
}