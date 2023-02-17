using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleAppBlind75.Greedy
{
    public static class Greedy
    {
        public static int MaxSubArraySum(int[] inputArr)
        {
            int currentSum = inputArr[0];
            int overallSum = inputArr[0];

            for (int i = 1; i < inputArr.Length; i++)
            {
                if (inputArr[i] + currentSum > inputArr[i])
                {
                    currentSum += inputArr[i];
                }
                else
                {
                    currentSum = inputArr[i];
                }

                if (currentSum > overallSum)
                {
                    overallSum = currentSum;
                }
            }

            return overallSum;
        }

        public static bool JumpGame(int[] jumps)
        {
            return FuncJumpGame(0, jumps);
        }

        private static bool FuncJumpGame(int index, int[] jumps)
        {
            if (index == jumps.Length)
            {
                return true;
            }

            if (jumps[index] == 0)
            {
                return false;
            }
            for (int i = 1; i <= jumps[index]; i++)
            {
                if (FuncJumpGame(index + i, jumps))
                    return true;
            }

            return false;
        }

        public static bool JumpGameGreedy(int[] nums)
        {
            int maxReach = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (i > maxReach)
                {
                    return false;
                }

                if (maxReach >= nums.Length-1)
                {
                    return true;
                }

                maxReach = Math.Max(maxReach, i+ nums[i]);
            }
            

            return false;
        }

        public static int MinNoOfJumpsRequired(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 1;
            }

            int maxReach = nums[0];
            int numberOfJump = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] + i > maxReach)
                {
                    maxReach = nums[i] + i;
                    numberOfJump++;
                }
                
                if(maxReach >= nums.Length-1) break;
            }

            return numberOfJump;
        }

        public static bool CheckValidParenthesis(string s)
        {
            Stack<char> parenthesisStack = new Stack<char>();
            foreach (var item in s)
            {
                if (item == '(')
                {
                    parenthesisStack.Push(item);
                    continue;
                }

                if (item == '*')
                {
                    //Do nothing
                }

                if (item == ')')
                {
                    if (parenthesisStack.Count == 0)
                    {
                        return false;
                    }

                    var topChar = parenthesisStack.Pop();
                    if (topChar == '(')
                    {
                        continue;
                    }
                    return false;
                }
            }

            return parenthesisStack.Count == 0;
        }

        public static bool CheckValidParenthesisWithStar(string s)
        {
            Stack<int> openStack = new Stack<int>();
            Stack<int> starStack = new Stack<int>();

            for(int i = 0; i< s.Length; i++)
            {
                if (s[i] == '(')
                {
                    openStack.Push(i);
                }

                else if (s[i] == '*')
                {
                    starStack.Push(i);
                }

                else
                {
                    if (openStack.Count > 0)
                    {
                        openStack.Pop();
                    }
                    else if(starStack.Count>0)
                    {
                        if (starStack.Peek() < i)
                        {
                            starStack.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            while (openStack.Count!=0)
            {
                if (starStack.Count > 0)
                {
                    if (openStack.Peek() < starStack.Peek())
                    {
                        openStack.Pop();
                        starStack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}