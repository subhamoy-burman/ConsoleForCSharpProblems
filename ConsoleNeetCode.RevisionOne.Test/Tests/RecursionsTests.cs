using System.Collections.Generic;
using ConsoleNeetCode.RevisionOne.Recursion;
using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test;

[TestFixture]
public class RecursionsTests
{
    [Test]
    public void GraphColoring_ReturnsTrue_WhenColoringIsPossible()
    {
        // Arrange
        List<List<int>> graph = new List<List<int>>
        {
            new List<int> { 1, 2 },   // Node 0 is connected to nodes 1 and 2
            new List<int> { 0, 2 },   // Node 1 is connected to nodes 0 and 2
            new List<int> { 0, 1 }    // Node 2 is connected to nodes 0 and 1
        };
        int[] colors = new int[3];
        int m = 3;

        // Act
        bool result = Recursions.GraphColoring(graph, colors, m);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void GraphColoring_ReturnsFalse_WhenColoringIsNotPossible()
    {
        // Arrange
        List<List<int>> graph = new List<List<int>>
        {
            new List<int> { 1, 2 },   // Node 0 is connected to nodes 1 and 2
            new List<int> { 0, 2 },   // Node 1 is connected to nodes 0 and 2
            new List<int> { 0, 1 }    // Node 2 is connected to nodes 0 and 1
        };
        int[] colors = new int[3];
        int m = 2; // Only 2 colors available

        // Act
        bool result = Recursions.GraphColoring(graph, colors, m);

        // Assert
        Assert.IsFalse(result);
    }
}