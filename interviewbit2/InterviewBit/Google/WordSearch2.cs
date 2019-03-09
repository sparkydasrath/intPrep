using System.Collections.Generic;

namespace Google
{
    public class TrieNode
    {
        public TrieNode() => Next = new TrieNode[26];

        public TrieNode[] Next { get; }
        public string Word { get; set; }
    }

    public class WordSearch2
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

        Solution: Using Trie
        https://leetcode.com/problems/word-search-ii/discuss/59780/Java-15ms-Easiest-Solution-(100.00)
        https://leetcode.com/problems/word-search-ii/discuss/59784/My-simple-and-clean-Java-code-using-DFS-and-Trie
         */

        private readonly List<string> results = new List<string>();
        private int cols = 0;
        private int rows = 0;
        private bool[,] visited;

        public TrieNode BuildTrie(string[] words)
        {
            TrieNode root = new TrieNode();

            foreach (string word in words)
            {
                TrieNode p = root;
                foreach (char c in word)
                {
                    int i = c - 'a';
                    if (p.Next[i] == null) p.Next[i] = new TrieNode();
                    p = p.Next[i];
                }
                p.Word = word;
            }
            return root;
        }

        public IList<string> FindWords(char[,] board, string[] words)
        {
            TrieNode trie = BuildTrie(words);
            rows = board.GetLength(0);
            cols = board.GetLength(1);
            visited = new bool[rows, cols];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    FindWordsHelper(board, trie, row, col);
                }
            }

            return results;
        }

        private void FindWordsHelper(char[,] board, TrieNode p, int row, int col)
        {
            if (row < 0 ||
                row >= rows ||
                col < 0 ||
                col >= cols ||
                visited[row, col]) return;

            char c = board[row, col];
            if (p.Next[c - 'a'] == null) return;

            p = p.Next[c - 'a'];
            if (p.Word != null)
            {   // found one
                results.Add(p.Word);
                p.Word = null;     // de-duplicate
            }

            visited[row, col] = true;
            FindWordsHelper(board, p, row, col + 1); // right
            FindWordsHelper(board, p, row, col - 1); // left
            FindWordsHelper(board, p, row + 1, col); // down
            FindWordsHelper(board, p, row - 1, col); // up
            visited[row, col] = false;
        }
    }
}