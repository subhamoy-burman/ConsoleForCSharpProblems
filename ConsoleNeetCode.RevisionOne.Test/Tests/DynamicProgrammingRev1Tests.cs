using System;
using ConsoleNeetCode.RevisionOne.DynamicProgramming;
using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test;

[TestFixture]
public class DynamicProgrammingRev1Tests
{
    [Test]
    public void LcsRecursive_ReturnsCorrectLength()
    {
        // Arrange
        string input1 = "ABCDGH";
        string input2 = "AEDFHR";

        // Act
        int result = DynamicProgrammingRev1.LcsDpMemoization(input1, input2);

        // Assert
        Assert.AreEqual(3, result);
    }
    
    [Test]
    public void MinimumNoOfCoins_Example1()
    {
        int[] coins = { 1, 2, 5 };
        int target = 11;
        int expected = 3;

        int result = DynamicProgrammingRev1.MinimumNoOfCoins(coins, target);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void MinimumNoOfCoins_Example2()
    {
        int[] coins = { 2 };
        int target = 3;
        int expected = Int32.MaxValue;

        int result = DynamicProgrammingRev1.MinimumNoOfCoins(coins, target);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void MinimumNoOfCoins_Example3()
    {
        int[] coins = { 1, 3, 4 };
        int target = 6;
        int expected = 2;

        int result = DynamicProgrammingRev1.MinimumNoOfCoins(coins, target);

        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void TestCoinChange2_Example1()
    {
        int[] coins = { 1, 2, 5 };
        int target = 5;
        int expected = 4;
        int actual = DynamicProgrammingRev1.CoinChange2(coins, target);
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void DistinctSubsequences_ValidInput_ReturnsCorrectResult()
    {
        // Arrange
        string s1 = "rabbbit";
        string s2 = "rabbit";
        int expectedOutput = 3;

        // Act
        int result = DynamicProgrammingRev1.DistinctSubsequences(s1, s2);

        // Assert
        Assert.AreEqual(expectedOutput, result);
    }
}
