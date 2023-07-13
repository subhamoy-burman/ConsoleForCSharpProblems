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

        public static List<List<int>> PrintAllPermutations(int[] nums)
        {
            HashSet<int> map = new HashSet<int>();
            var answerList = new List<List<int>>();
            
            SolvePrintAllPermutation(nums, new List<int>(), map, answerList);
            return answerList;
        }

        private static void SolvePrintAllPermutation(int[] nums, List<int> ans, HashSet<int> map, List<List<int>> answerList)
        {
            if (ans.Count == nums.Length)
            {
                answerList.Add(new List<int>(ans));
                return;
            }
            
            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.Contains(nums[i]))
                {
                    map.Add(nums[i]);
                    ans.Add(nums[i]);
                    SolvePrintAllPermutation(nums,ans,map, answerList);
                    map.Remove(nums[i]);
                    ans.Remove(nums[i]);
                }
            }
        }

        public class GridIndex
        {
            public int RowIndex { get; set; }
            public int ColIndex { get; set; }
        }
        
        public static bool WordSearch(List<List<char>> grid, string target)
        {
            int numOfRows = grid.Count;
            int numOfColumns = grid[0].Count;

            var visited = new HashSet<(int, int)>();

            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfColumns; j++)
                {
                    if (target[0].Equals(grid[i][j]))
                    {
                        if (WordSearchDFS(i, j, 0, target, grid, visited))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private static bool WordSearchDFS(int rowIndex, int colIndex, int currIndex, string target, List<List<char>> grid, HashSet<(int, int)> visited)
        {
            if (currIndex == target.Length)
            {
                return true;
            }

            if (rowIndex < 0 && colIndex < 0 && rowIndex >= grid.Count && colIndex >= grid[0].Count
                && visited.Contains((rowIndex, colIndex)) && target[currIndex] != grid[rowIndex][colIndex])
            {
                return false;
            }

            visited.Add((rowIndex, colIndex));

            bool result = WordSearchDFS(rowIndex + 1, colIndex, currIndex + 1, target, grid, visited) ||
                          WordSearchDFS(rowIndex - 1, colIndex, currIndex + 1, target, grid, visited)
                          || WordSearchDFS(rowIndex, colIndex -1, currIndex + 1, target, grid, visited) ||
                          WordSearchDFS(rowIndex , colIndex + 1, currIndex + 1, target, grid, visited);
            
            visited.Remove((rowIndex, colIndex));
            return result;
        }

        public static List<List<int>> GetAllPermutations(int[] arr)
        {
            List<List<int>> permutationList = new List<List<int>>();
            HashSet<int> freqMap = new HashSet<int>();
            List<int> localList = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                freqMap.Add(i);
                localList.Add(arr[i]);
                SolveGetAllPermutations(i, freqMap, localList, permutationList, arr);
                freqMap.Clear();
                localList.Clear();
            }

            return permutationList;
        }

        private static void SolveGetAllPermutations(int index, HashSet<int> freqMap, List<int> localList, List<List<int>> globalList, int[] arr)
        {
            if (freqMap.Count == arr.Length)
            {
                globalList.Add(new List<int>(localList));
                return;
            }
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (freqMap.Contains(i))
                {
                    continue;
                }
                localList.Add(arr[i]);
                freqMap.Add(i);
                SolveGetAllPermutations(i+1, freqMap, localList, globalList, arr);
                localList.Remove(arr[i]);
                freqMap.Remove(i);
            }
        }
    }
}