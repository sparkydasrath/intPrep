using System.Collections.Generic;

namespace Google
{
    public class WordSearch2BruteForce
    {
        /*
         212. Word Search II https://leetcode.com/problems/word-search-ii/
        Hard

        Given a 2D board and a list of words from the dictionary, find all words in the board.

        Each word must be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once in a word.

        Example:

        Input:
        words = ["oath","pea","eat","rain"] and board =
        [
          ['o','a','a','n'],
          ['e','t','a','e'],
          ['i','h','k','r'],
          ['i','f','l','v']
        ]

        Output: ["eat","oath"]

        Note:
        You may assume that all inputs are consist of lowercase letters a-z.
         */

        private int cols = 0;
        private IList<string> results = new List<string>();
        private List<string> resultsTemp = new List<string>();
        private int rows = 0;
        private bool[,] visited;

        public bool Exist(char[,] board, string word)
        {
            // this is dfs with choose, explore, unchoose pattern
            rows = board.GetLength(0);
            cols = board.GetLength(1);
            visited = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    bool exist = DfsExists(board, row, col, word, 0);
                    if (exist) return true;
                }
            }

            return false;
        }

        public IList<string> FindWords(char[,] board, string[] words)
        {
            foreach (string word in words)
            {
                if (Exist(board, word)) resultsTemp.Add(word);
            }

            resultsTemp.Sort();

            foreach (string w in resultsTemp)
            {
                results.Add(w);
            }

            return results;
        }

        private bool DfsExists(char[,] board, int row, int col, string word, int wordIndex)
        {
            // keep track of how many chars you have successfully found so far

            // once you find the word, stop
            if (wordIndex == word.Length) return true;

            // boundary check
            if (row < 0 || row >= rows || col < 0 || col >= cols // illegal boundaries
                || visited[row, col] // already visited
                || board[row, col] != word[wordIndex]) // char does not match
            {
                return false;
            }

            // choose
            visited[row, col] = true;

            // explore in all directions

            if (DfsExists(board, row + 1, col, word, wordIndex + 1)) /*down*/ return true;
            if (DfsExists(board, row - 1, col, word, wordIndex + 1)) /*up*/ return true;
            if (DfsExists(board, row, col + 1, word, wordIndex + 1)) /*right*/ return true;
            if (DfsExists(board, row, col - 1, word, wordIndex + 1)) /*left*/ return true;

            // unchoose
            visited[row, col] = false;
            return false;
        }
    }
}