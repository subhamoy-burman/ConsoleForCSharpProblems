using System.Collections.Generic;
using ConsoleNeetCode.RevisionOne.Graphs;
using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test;

[TestFixture]
public class GraphRevTests
{
    [Test]
    public void WordLadderLength_ShouldReturnCorrectLength_WhenValidWordLadderExists()
    {
        // Arrange
        string startWord = "hit";
        string endWord = "cog";
        string[] wordList = { "hot", "dot", "dog", "lot", "log", "cog" };

        // Act
        int length =  GraphRevision.WordLadderLength(startWord, endWord, wordList);

        // Assert
        Assert.AreEqual(5, length);
    }
    
    [Test]
    public void Dijkstra_ShouldCalculateShortestDistances()
    {
        // Arrange
        int V = 4; // Number of vertices
        List<List<List<int>>> adjList = new List<List<List<int>>>()
        {
            new List<List<int>>() { new List<int>() { 1, 1 }, new List<int>() { 2, 4 } }, // Adjacency list for node 0
            new List<List<int>>() { new List<int>() { 2, 2 }, new List<int>() { 3, 5 } }, // Adjacency list for node 1
            new List<List<int>>() { new List<int>() { 3, 1 } }, // Adjacency list for node 2
            new List<List<int>>() // Adjacency list for node 3 (no outgoing edges)
        };
        int source = 0;

        // Act
        List<int> distances = GraphRevTwo.Dijkstra(V, adjList, source);

        // Assert
        Assert.AreEqual(new List<int>() { 0, 1, 3, 6 }, distances);
    }
}