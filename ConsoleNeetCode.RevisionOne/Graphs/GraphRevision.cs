using System.Collections;
using System.Collections.Generic;

namespace ConsoleNeetCode.RevisionOne.Graphs;

public static class GraphRevision
{
    public class WordLevel
    {
        public int Level { get; set; }
        public string Word { get; set; }

        public WordLevel(int level, string word)
        {
            Level = level;
            Word = word;
        }
    }
    public static int WordLadderLength(string startWord, string endWord, string[] wordList)
    {
        Queue<WordLevel> wordLevels = new Queue<WordLevel>();
        HashSet<string> uniqueStrings = new HashSet<string>();

        foreach (var item in wordList)
        {
            uniqueStrings.Add(item);
        }
        
        wordLevels.Enqueue(new WordLevel(1, startWord));

        while (wordLevels.Count>0)
        {
            var current = wordLevels.Dequeue();
            var currentLevel = current.Level;
            var currentWord = current.Word;

            if (currentWord == endWord) return currentLevel;

            for (int i = 0; i < currentWord.Length; i++)
            {
                for (char ch = 'a'; ch <= 'z'; ch++)
                {
                    var charArray = currentWord.ToCharArray();
                    charArray[i] = ch;
                    var newWord = new string(charArray);
                    
                    if (uniqueStrings.Contains(newWord))
                    {
                        uniqueStrings.Remove(newWord);
                        wordLevels.Enqueue(new WordLevel(currentLevel+1, newWord));
                    }
                }
            }
        }

        return -1;
    }
}