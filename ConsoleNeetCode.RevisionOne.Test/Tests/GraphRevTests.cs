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
}