using System.Collections.Generic;

namespace ConsoleNeetCode.RevisionOne.DynamicProgramming
{
    public static class Backtracking
    {

        public static List<List<int>> GetCombinationSum(int[] arr, int k)
        {
            List<List<int>> combList = new List<List<int>>();
            List<int> comb = new List<int>();

            SolveCombinationSum(0, arr, k, comb, combList);

            return combList;
        }

        private static void SolveCombinationSum(int index, int[] arr, int targetSum, List<int> comb, List<List<int>> combList)
        {
            if (index == arr.Length)
            {
                if (targetSum == 0)
                {
                    combList.Add(comb);
                }
                return;
            }
            
            if (targetSum - arr[index] >= 0)
            {
                comb.Add(arr[index]);
                SolveCombinationSum(index,arr, targetSum - arr[index], comb, combList);
                comb.RemoveAt(comb.Count-1);
            }
            
            SolveCombinationSum(index + 1,arr, targetSum , comb, combList);
        }
    }
}