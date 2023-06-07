using System;

namespace ConsoleNeetCode.RevisionOne.Tries;

public class TrieNode
{
    public char Data { get; set; }
    public int WordEnd { get; set; }
    public TrieNode[] Child { get; set; }

    public TrieNode(char data)
    {
        Data = data;
        WordEnd = 0;
        Child = new TrieNode[26];
    }
}
public class Trie
{
    private TrieNode _root;

    public Trie()
    {
        _root = new TrieNode('/');
    }

    public void Insert(string s)
    {
        var curr = _root;

        foreach (var t in s)
        {
            int index = t - 'a';
            curr.Child[index] = new TrieNode(t);
            curr = curr.Child[index];
        }

        curr.WordEnd = 1;
    }

    public bool Search(string s)
    {
        var curr = _root;
        
        // ReSharper disable once ForCanBeConvertedToForeach
        for (int i = 0; i < s.Length; i++)
        {
            int index = s[i] - 'a';
            if (curr.Child[index]!=null)
            {
                curr = curr.Child[index];
            }
            else
            {
                return false;
            }
        }

        return (curr.WordEnd == 1);
    }
    
}