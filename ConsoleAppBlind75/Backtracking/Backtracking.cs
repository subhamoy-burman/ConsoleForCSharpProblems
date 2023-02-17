using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleAppBlind75.Backtracking
{
    public static class Backtracking
    {
        public static void PrintAllPaths(int m, int n)
        {
            int[,] pathMatrix = new int[m, n];
            bool[,] visitedMatrix = new bool[m, n];
            int initialStep = 0;
            PrintAllPathsRecursive(0, 0, initialStep, pathMatrix, visitedMatrix);
        }

        private static void PrintAllPathsRecursive(int row, int column, int step, int[,] pathMatrix,
            bool[,] visitedMatrix)
        {
            //Base case return condition
            if (row == pathMatrix.GetLength(0) - 1 && column == pathMatrix.GetLength(1) - 1)
            {
                pathMatrix[row, column] = step + 1;
                Print2DMatrix(pathMatrix);
                return;
            }

            if (visitedMatrix[row, column])
            {
                return;
            }

            pathMatrix[row, column] = step + 1;
            visitedMatrix[row, column] = true;

            //Moving Down
            if (row < pathMatrix.GetLength(0) - 1)
            {
                PrintAllPathsRecursive(row + 1, column, step + 1, pathMatrix, visitedMatrix);
            }

            //Moving Left
            if (column > 0)
            {
                PrintAllPathsRecursive(row, column - 1, step + 1, pathMatrix, visitedMatrix);
            }

            //Moving Right
            if (column < pathMatrix.GetLength(1) - 1)
            {
                PrintAllPathsRecursive(row, column + 1, step + 1, pathMatrix, visitedMatrix);
            }

            //Moving Up
            if (row > 0)
            {
                PrintAllPathsRecursive(row - 1, column, step + 1, pathMatrix, visitedMatrix);
            }

            pathMatrix[row, column] = 1;
            visitedMatrix[row, column] = false;
        }

        public static int CountNQueen(int matrixParam)
        {
            bool[,] visited = new bool[matrixParam, matrixParam];

            return CountNQueenFunc(0, 0, visited);
        }

        private static int CountNQueenFunc(int row, int column, bool[,] visited)
        {
            if (row == visited.GetLength(0))
            {
                Print2DMatrix(visited);
                return 1;
            }

            int count = 0;
            for (int col = 0; col < visited.GetLength(1); col++)
            {
                if (IsSafeToPlace(row, col, visited))
                {
                    visited[row, col] = true;
                    count += CountNQueenFunc(row + 1, col, visited);
                    visited[row, col] = false;
                }
            }

            return count;
        }

        public static void PrintSubsequencesEqualsSum()
        {
            int[] input = new[] {1, 2, 1};
            int targetSum = 2;
            List<int> subList = new List<int>();

            FuncPrintSubsequenceEqualsSum(0, 0, subList, input, targetSum);
        }

        private static void FuncPrintSubsequenceEqualsSum(int index, int sumSoFar, List<int> subList, int[] input,
            int targetSum)
        {
            if (index >= input.Length)
            {
                if (targetSum.Equals(sumSoFar))
                {
                    foreach (var item in subList)
                    {
                        Debug.Write(item + " - ");
                    }

                    Debug.WriteLine("----------------");
                }

                return;
            }

            //Take condition
            subList.Add(input[index]);
            FuncPrintSubsequenceEqualsSum(index + 1, sumSoFar + input[index], subList, input, targetSum);

            //Not take condition
            subList.Remove(input[index]);
            FuncPrintSubsequenceEqualsSum(index + 1, sumSoFar, subList, input, targetSum);
        }


        private static bool IsSafeToPlace(int row, int column, bool[,] visited)
        {
            // Check whether there exists anything in the column or not
            for (int i = 0; i < row; i++)
            {
                if (visited[row, column])
                {
                    return false;
                }
            }

            int maxLeft = Math.Min(row, column);

            for (int m = 0; m <= maxLeft; m++)
            {
                if (visited[row - m, column - m])
                {
                    return false;
                }
            }

            int maxRight = Math.Min(row, visited.GetLength(1) - column - 1);
            for (int i = 0; i < maxRight; i++)
            {
                if (visited[row - i, column + i])
                {
                    return false;
                }
            }

            /*int rowCount = row;
            int columnCount = column;

            // Check till the left wall
            while (rowCount >= 0 && columnCount >= 0)
            {
                if (visited[rowCount, columnCount])
                {
                    return false;
                }

                rowCount--;
                columnCount--;
            }

            rowCount = row;
            columnCount = column;

            //check till the right wall
            while (rowCount >= 0 && columnCount <= visited.GetLength(1) - 1)
            {
                if (visited[rowCount, column])
                {
                    return false;
                }

                rowCount--;
                columnCount++;
            }*/

            return true;
        }

        public static void Print2DMatrix(int[,] twoDMatrix)
        {
            for (int x = 0; x < twoDMatrix.GetLength(0); x += 1)
            {
                for (int y = 0; y < twoDMatrix.GetLength(1); y += 1)
                {
                    Debug.Write(twoDMatrix[x, y]);
                }

                Debug.WriteLine("");
            }

            Debug.WriteLine("");
        }

        private static void Print2DMatrix(bool[,] twoDMatrix)
        {
            for (int x = 0; x < twoDMatrix.GetLength(0); x += 1)
            {
                for (int y = 0; y < twoDMatrix.GetLength(1); y += 1)
                {
                    if (twoDMatrix[x, y])
                        Debug.Write("Q");
                    else
                    {
                        Debug.Write("X");
                    }
                }

                Debug.WriteLine("");
            }

            Debug.WriteLine("");
        }

        public static void FuncSubsets(int index, List<IList<int>> subsetList, List<int> localSubset, int[] nums)
        {
            if (index >= nums.Length)
            {
                subsetList.Add(localSubset);
                return;
            }

            //Take condition
            localSubset.Add(nums[index]);
            List<int> newTakeSubset = new List<int>(localSubset);
            FuncSubsets(index + 1, subsetList, newTakeSubset, nums);

            //Not take condition
            localSubset.Remove(nums[index]);
            List<int> newNotTakeSubset = new List<int>(localSubset);
            FuncSubsets(index + 1, subsetList, localSubset, nums);
        }

        public static void FuncCombinations(int index, int sumSofar, int[] candidates, int target,
            List<IList<int>> subsetList, List<int> localSubset)
        {
            if (sumSofar == target)
            {
                subsetList.Add(new List<int>(localSubset));
                return;
            }

            if (index >= candidates.Length)
            {
                return;
            }


            //Take condition
            localSubset.Add(candidates[index]);
            if (sumSofar + candidates[index] <= target)
            {
                //List<int> takeSubsetList = new List<int>(localSubset);
                FuncCombinations(index, sumSofar + candidates[index], candidates, target, subsetList, localSubset);
            }

            //Not take condition
            localSubset.Remove(candidates[index]);
            //List<int> notTakeSubsetList = new List<int>(localSubset);
            FuncCombinations(index + 1, sumSofar, candidates, target, subsetList, localSubset);
        }

        public static List<List<int>> SubsetUnique(int[] nums)
        {
            List<List<int>> subsets = new List<List<int>>();
            FuncSubsetUnique(0, new List<int>(), subsets, nums);
            return subsets;
        }

        private static void FuncSubsetUnique(int index, List<int> localSet, List<List<int>> subsets, int[] nums)
        {
            subsets.Add(new List<int>(localSet));
            for (int i = index; i < nums.Length; i++)
            {
                if (i!=index &&  nums[i] == nums[i - 1]) continue;
                localSet.Add(nums[i]);
                FuncSubsetUnique(i+1, localSet, subsets, nums);
                localSet.Remove(localSet.LastOrDefault());
            }
        }
        
        public static List<List<int>> SubsetCombinationSumUnique(int[] nums, int target)
        {
            List<List<int>> subsets = new List<List<int>>();
            Array.Sort(nums);
            FuncSubsetCombinationSumUnique(0, new List<int>(), subsets, nums, target);
            return subsets;
        }

        private static void FuncSubsetCombinationSumUnique(int index, List<int> localSet, List<List<int>> subsets, int[] nums, int target)
        {
            if (target < 0)
            {
                return;
            }
            
            if (target == 0)
            {
                subsets.Add(new List<int>(localSet));
                return;
            }

            for (int i = index; i < nums.Length; i++)
            {
                if (i!=index &&  nums[i] == nums[i - 1]) continue;
                localSet.Add(nums[i]);
                FuncSubsetCombinationSumUnique(i+1, localSet, subsets, nums, target - nums[i]);
                localSet.Remove(localSet.LastOrDefault());
            }
        }

        public static List<List<string>> Partition(string s)
        {
            List<List<string>> res = new List<List<string>>();
            List<string> path = new List<string>();
            FuncPartition(0, s, path, res);
            return res;
        }

        private static void FuncPartition(int index, string s, List<string> path, List<List<string>> res)
        {
            if (index == s.Length)
            {
                res.Add(new List<string>(path));
                return;
            }
            

            for (int i = index; i < s.Length; ++i)
            {
                if (isPalindrome(s, index, i))
                {
                    path.Add(s.Substring(index, i- index+1));
                    FuncPartition(i+1, s, path, res);
                    path.Remove(path.LastOrDefault());
                }
            }
        }

        private static bool isPalindrome(string s, int startIndex, int end)
        {
            while (startIndex <= end)
            {
                if (s[startIndex++] != s[end--])
                {
                    return false;
                }
            }

            return true;
        }
    }
}