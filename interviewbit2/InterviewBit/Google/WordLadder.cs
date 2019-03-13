using System;
using System.Collections.Generic;

namespace Google
{
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

        private readonly IList<IList<string>> results;
        private bool[] visited;

        public WordLadder() => results = new List<IList<string>>();

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord)) return 0;

            visited = new bool[wordList.Count];
            IList<string> accumulator = new List<string>();
            LadderLengthHelper(beginWord, endWord, wordList, accumulator, beginWord);

            /**/
            int min = int.MaxValue;

            foreach (IList<string> result in results)
            {
                IList<string> r = result;
                if (!result.Contains(beginWord))
                    r.Insert(0, beginWord);
                min = Math.Min(min, r.Count);
                Console.WriteLine(string.Join("->", r));
            }

            return min == int.MaxValue ? 0 : min;
        }

        public void LadderLengthHelper(string beginWord, string endWord, IList<string> wordList, IList<string> accumulator, string originalBeginWord)
        {
            if (accumulator.Count > 0 && accumulator[accumulator.Count - 1] == endWord)
            {
                results.Add(accumulator);
                return;
            }

            for (int i = 0; i < wordList.Count; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    accumulator.Add(wordList[i]);

                    string currWord = wordList[i];

                    if (currWord == originalBeginWord) continue;

                    if (IsOneCharApart(beginWord, currWord))
                        LadderLengthHelper(currWord, endWord, wordList, new List<string>(accumulator), originalBeginWord);

                    visited[i] = false;
                    accumulator.RemoveAt(accumulator.Count - 1);
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

            /*Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char c in word1)
            {
                if (!map.ContainsKey(c)) map[c] = 1;
                else map[c]++;
            }

            foreach (char c in word2)
                if (map.ContainsKey(c)) map[c]--;

            int cc = map.Values.Count(c => c == 1);
            return cc == 1;*/
        }
    }
}