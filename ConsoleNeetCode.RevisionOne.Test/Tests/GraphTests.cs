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
    
    [Test]
    public void NumberOfDistinctIslands_ShouldReturnCorrectCount()
    {
        // Arrange
        int[,] inputMatrix = {
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1 },
            { 1, 1, 0, 1, 1 }
        };

        

        // Act
        int distinctIslands = Graphs.GraphRevTwo.NumberOfDistinctIslands(inputMatrix);

        // Assert
        Assert.AreEqual(3, distinctIslands);
    }
}
