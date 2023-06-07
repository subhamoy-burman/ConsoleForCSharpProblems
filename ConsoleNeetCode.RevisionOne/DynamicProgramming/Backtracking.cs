using System.Collections.Generic;
using System.Linq;

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

        public static List<List<int>> CombinationSum2(int[] candidates, int target)
        {
            List<List<int>> listOfInt = new List<List<int>>();
            SolveCombinationSum2(0, candidates, target, listOfInt, new List<int>());
            return listOfInt;
        }

        private static void SolveCombinationSum2(int index, int[] candidates, int target, List<List<int>> listOfInt, List<int> localList)
        {
            if (target == 0)
            {
                listOfInt.Add(localList);
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                if (i > index && candidates[index] == candidates[index + 1])
                {
                    continue;
                }

                if (target - candidates[i] >= 0)
                {
                    localList.Add(candidates[i]);
                    SolveCombinationSum2(i, candidates, target - candidates[i], listOfInt, localList);
                    localList.Remove(candidates[i]);
                }
                else
                {
                    break;
                }
            }
        }

        public static List<int> SubSetSum(int[] arr)
        {
            List<int> sumList = new List<int>();
            SolveSubsetSum(0, arr, sumList, new List<int>());
            return sumList;
        }

        private static void SolveSubsetSum(int index, int[] arr, List<int> sumList, List<int> sumSoFar)
        {
            if (index == arr.Length)
            {
                sumList.Add(sumSoFar.Sum());
                return;
            }
            
            sumSoFar.Add(arr[index]);
            SolveSubsetSum(index+1, arr, sumList, sumSoFar);
            sumSoFar.Remove(arr[index]);
            SolveSubsetSum(index+1, arr, sumList, sumSoFar);
        }
    }
}