using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppBlind75.Subset
{
    public class FindSubsets
    {
        public List<List<int>> Execute(int[] nums)
        {
            List<List<int>> subsets = new List<List<int>>();
            subsets.Add(new List<int>());

            foreach (var num in nums)
            {
                int n = subsets.Count;

                for (int i = 0; i < n; i++)
                {
                    List<int> set = new List<int>(subsets[i]);
                    set.Add(num);
                    subsets.Add(set);
                }
            }
            return subsets;
        }
        
        public List<List<int>> ExecuteGetUnique(int[] nums)
        {
            List<List<int>> subsets = new List<List<int>>();
            Array.Sort(nums);
            
            subsets.Add(new List<int>());

            int startIndex = 0, endIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                startIndex = 0;

                if (i > 0 && nums[i] == nums[i - 1])
                {
                    startIndex = endIndex + 1;
                }
                endIndex = subsets.Count - 1;

                for (int j = startIndex; j <= endIndex; j++)
                {
                    List<int> set = new List<int>(subsets[j]);
                    set.Add(nums[i]);
                    subsets.Add(set);
                }
            }
            
            return subsets;
        }

        public List<List<int>> FindPermutations(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            Queue<List<int>> permutations = new Queue<List<int>>();
            
            permutations.Enqueue(new List<int>());

            foreach (var currentNumber in nums)
            {
                int n = permutations.Count;

                for (int i = 0; i < n; i++)
                {
                    List<int> oldPermutations = permutations.Dequeue();
                    for (int j = 0; j <= oldPermutations.Count; j++)
                    {
                        List<int> newPermutations = new List<int>(oldPermutations);
                        newPermutations.Insert(j,currentNumber);

                        if (newPermutations.Count == nums.Length)
                        {
                            result.Add(newPermutations);
                        }
                        else
                        {
                            permutations.Enqueue(newPermutations);
                        }
                    }
                }
            }

            return result;
        }

        public List<List<int>> FindPermutationsRecursive(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            GeneratePermutationsRecursive(nums, 0, new List<int>(), result);
            return result;
        }

        private void GeneratePermutationsRecursive(int[] nums, int index, List<int> currentPermutation, List<List<int>> result)
        {
            if (index == nums.Length)
            {
                result.Add(currentPermutation);
            }
            else
            {
                for (int i = 0; i <= currentPermutation.Count; i++)
                {
                    var numToProcess = nums[index];
                    List<int> newPermutation = new List<int>(currentPermutation);
                    newPermutation.Insert(i,numToProcess);
                    GeneratePermutationsRecursive(nums, index+1, newPermutation, result);
                }
            }
        }

        public List<List<int>> FindAllPermutation(int[] nums)
        {
            List<List<int>> result = new List<List<int>>();
            FindAllPermutations(nums,  new List<int>(), result);
            return result;
        }

        private void FindAllPermutations(int[] nums, List<int> currentPermutation, List<List<int>> result)
        {
            if (nums.Length == 0)
            {
                result.Add(currentPermutation);
                return;
            }
            
            for (int i = 0; i < nums.Length; i++)
            {
                int currentNum = nums[i];
                var leftArray = i>0? nums[..(i-1)]: new int[]{};
                var rightArray = nums[(i+1)..(nums.Length)];

                var resultArray = leftArray.Concat(rightArray).ToArray();
                currentPermutation.Add(currentNum);
                FindAllPermutations(resultArray, new List<int>(currentPermutation), result);
            }
        }
    }
}