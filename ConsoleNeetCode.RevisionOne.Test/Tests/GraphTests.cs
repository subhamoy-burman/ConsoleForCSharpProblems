using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test;

[TestFixture]
public class GraphTests
{
    [Test]
    public void SurroundedRegion_ValidInputMatrix_ReturnsModifiedMatrix()
    {
        // Arrange
        char[,] inputMatrix = new char[,]
        {
            { 'X', 'X', 'X', 'X' },
            { 'X', 'O', 'O', 'X' },
            { 'X', 'X', 'O', 'X' },
            { 'X', 'O', 'X', 'X' }
        };

        char[,] expectedOutput = new char[,]
        {
            { 'X', 'X', 'X', 'X' },
            { 'X', 'X', 'X', 'X' },
            { 'X', 'X', 'X', 'X' },
            { 'X', 'O', 'X', 'X' }
        };

        // Act
        char[,] actualOutput = Graphs.GraphRevTwo.SurroundedRegion(inputMatrix);

        // Assert
        Assert.AreEqual(expectedOutput, actualOutput);
    }
}