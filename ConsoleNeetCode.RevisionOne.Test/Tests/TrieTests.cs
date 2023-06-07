using ConsoleNeetCode.RevisionOne.Tries;
using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test;

[TestFixture]
public class TrieTests
{
    [Test]
    public void Search_ExistingString_ReturnsTrue()
    {
        // Arrange
        Trie trie = new Trie();
        trie.Insert("apple");

        // Act
        bool result = trie.Search("apple");

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Search_NonExistingString_ReturnsFalse()
    {
        // Arrange
        Trie trie = new Trie();
        trie.Insert("apple");

        // Act
        bool result = trie.Search("banana");

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void Insert_ValidString_StringInsertedSuccessfully()
    {
        // Arrange
        Trie trie = new Trie();

        // Act
        trie.Insert("apple");

        // Assert
        bool result = trie.Search("apple");
        Assert.IsTrue(result);
    }

}