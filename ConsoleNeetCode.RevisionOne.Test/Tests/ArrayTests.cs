using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test;

[TestFixture]
public class ArrayTests
{
    [Test]
    public void LongestSubArraySum_ReturnsCorrectLength()
    {
        // Arrange
        int[] arr = { 3, 1, 2, -1, 4, 5, -1, 2 };
        int k = 5;
        int expectedLength = 4;

        // Act
        int actualLength = Arrays.Arrays.LongestSubArraySum(arr, k);

        // Assert
        Assert.AreEqual(expectedLength, actualLength);
    }
}