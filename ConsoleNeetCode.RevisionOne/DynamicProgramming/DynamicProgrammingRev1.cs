using System;
using System.Text.RegularExpressions;

namespace ConsoleNeetCode.RevisionOne.DynamicProgramming;

public static class DynamicProgrammingRev1
{
    public static int LcsRecursive(string input1, string input2)
    {
        int index1 = input1.Length - 1;
        int index2 = input2.Length - 1;

        return LcsRecursiveUtil(input1, input2, index1, index2);
    }

    private static int LcsRecursiveUtil(string input1, string input2, int index1, int index2)
    {
        if (index1 < 0 || index2 < 0)
        {
            return 0;
        }

        if (input1[index1] == input2[index2])
        {
            return 1 + LcsRecursiveUtil(input1, input2, index1 - 1, index2 - 1);
        }

        return Math.Max(LcsRecursiveUtil(input1, input2, index1 - 1, index2),
            LcsRecursiveUtil(input1, input2, index1, index2 - 1));
    }

    public static int LcsDpMemoization(string input1, string input2)
    {
        int[,] dpArray = new int[input1.Length, input2.Length];
        int index1 = input1.Length-1;
        int index2 = input2.Length-1;

        for (int i = 0; i < dpArray.GetLength(0); i++)
        {
            for (int j = 0; j < dpArray.GetLength(1); j++)
            {
                dpArray[i, j] = -1;
            }
        }

        return LcsDpUtil(index1, index2, input1, input2, dpArray);

        
    }

    private static int LcsDpUtil(int index1, int index2, string input1, string input2, int[,] dpArray)
    {
        if (index1 < 0 || index2 < 0)
        {
            return  0;
        }

        if (dpArray[index1, index2] != -1)
        {
            return dpArray[index1, index2];
        }

        if (input1[index1] == input2[index2])
        {
            return  dpArray[index1, index2] = 1 + LcsDpUtil(index1 - 1, index2 - 1, input1, input2, dpArray);
        }

        return dpArray[index1, index2] = Math.Max(LcsDpUtil(index1, index2 - 1, input1, input2, dpArray),
            LcsDpUtil(index1 - 1, index2, input1, input2, dpArray));
    }
}