using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    public struct WordLevelPair
    {
        public WordLevelPair(string word, int level)
        {
            Word = word;
            Level = level;
        }

        public int Level { get; }
        public string Word { get; }
    }

    public class WordLadder
    {
        /*
         127. Word Ladder https://leetcode.com/problems/word-ladder/
        Medium

        Given two words (beginWord and endWord), and a dictionary's word list, find the length of shortest transformation sequence from beginWord to endWord, such that:

            Only one letter can be changed at a time.
            Each transformed word must exist in the word list. Note that beginWord is not a transformed word.

        Note:

            Return 0 if there is no such transformation sequence.
            All words have the same length.
            All words contain only lowercase alphabetic characters.
            You may assume no duplicates in the word list.
            You may assume beginWord and endWord are non-empty and are not the same.

        Example 1:

        Input:
        beginWord = "hit",
        endWord = "cog",
        wordList = ["hot","dot","dog","lot","log","cog"]

        Output: 5

        Explanation: As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
        return its length 5.

        Example 2:

        Input:
        beginWord = "hit"
        endWord = "cog"
        wordList = ["hot","dot","dog","lot","log"]

        Output: 0

        Explanation: The endWord "cog" is not in wordList, therefore no possible transformation.

         */

        private readonly IList<IList<string>> resultsDfs;
        private Dictionary<string, IList<string>> adjList;
        private IList<WordLevelPair> resultsBfs;
        private Dictionary<string, bool> visitedBfs;
        private bool[] visitedDfs;

        public WordLadder()
        {
            resultsDfs = new List<IList<string>>();
            resultsBfs = new List<WordLevelPair>();
            adjList = new Dictionary<string, IList<string>>();
            visitedBfs = new Dictionary<string, bool>();
        }

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord)) return 0;

            visitedDfs = new bool[wordList.Count];
            IList<string> accumulator = new List<string>();

            IList<string> allWords = new List<string>(wordList);
            allWords.Insert(0, beginWord);

            BuildAdjList(allWords);

            LadderLengthHelperBfs(beginWord, endWord, wordList);
            LadderLengthHelper(beginWord, endWord, wordList, accumulator, beginWord);

            foreach (WordLevelPair pair in resultsBfs) { Console.WriteLine($"{pair.Word} {pair.Level}"); }

            return resultsBfs.Last().Level;
        }

        public void LadderLengthHelper(string beginWord, string endWord, IList<string> wordList, IList<string> accumulator, string originalBeginWord)
        {
            if (accumulator.Count > 0 && accumulator[accumulator.Count - 1] == endWord)
            {
                resultsDfs.Add(accumulator);
                return;
            }

            for (int i = 0; i < wordList.Count; i++)
            {
                if (!visitedDfs[i])
                {
                    visitedDfs[i] = true;
                    accumulator.Add(wordList[i]);

                    string currWord = wordList[i];

                    if (currWord == originalBeginWord) continue;

                    if (IsOneCharApart(beginWord, currWord))
                        LadderLengthHelper(currWord, endWord, wordList, new List<string>(accumulator), originalBeginWord);

                    visitedDfs[i] = false;
                    accumulator.RemoveAt(accumulator.Count - 1);
                }
            }
        }

        private void BuildAdjList(IList<string> wordList)
        {
            for (int i = 0; i < wordList.Count; i++)
            {
                string key = wordList[i];

                if (!adjList.ContainsKey(key))
                    adjList[key] = new List<string>();

                for (int j = 0; j < wordList.Count; j++)
                {
                    string word = wordList[j];
                    if (key == word) continue; // skip if the begin word is also part of the wordlist
                    if (IsOneCharApart(key, word))
                        adjList[key].Add(word);
                }
            }
        }

        private bool IsOneCharApart(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;
            int count = 0;

            for (int i = 0; i < word1.Length; i++)
                if (word1[i] != word2[i]) count++;

            return count == 1;
        }

        private void LadderLengthHelperBfs(string beginWord, string endWord, IList<string> wordList)
        {
            Queue<WordLevelPair> queue = new Queue<WordLevelPair>();
            WordLevelPair startingPair = new WordLevelPair(beginWord, 1);
            queue.Enqueue(startingPair);
            resultsBfs.Add(startingPair);
            visitedBfs[beginWord] = true;

            while (queue.Count != 0)
            {
                WordLevelPair pair = queue.Dequeue();
                string currentWord = pair.Word;
                int level = pair.Level;

                for (int i = 0; i < wordList.Count; i++)
                {
                    // otherwise, grab the nodes closest to this one and enqueue them
                    IList<string> adjNodes = adjList[currentWord];

                    if (adjNodes == null || adjNodes.Count == 0) continue;

                    foreach (string adjWord in adjNodes)
                    {
                        if (adjWord == endWord)
                        {
                            resultsBfs.Add(new WordLevelPair(adjWord, level + 1));
                            return;
                        }

                        if (!visitedBfs.ContainsKey(adjWord))
                        {
                            visitedBfs[adjWord] = true;
                            WordLevelPair adjLevelPair = new WordLevelPair(adjWord, level + 1);
                            resultsBfs.Add(adjLevelPair);
                            queue.Enqueue(adjLevelPair);
                        }
                    }
                }
            }
        }
    }
}