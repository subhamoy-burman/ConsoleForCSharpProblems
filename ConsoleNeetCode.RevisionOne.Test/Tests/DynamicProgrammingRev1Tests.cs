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
}