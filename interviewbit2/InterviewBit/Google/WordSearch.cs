using System.Runtime.Remoting.Messaging;

namespace Google
{
    public class WordSearch
    {
        /*
         * 79. Word Search https://leetcode.com/problems/word-search/
        Medium

        Given a 2D board and a word, find if the word exists in the grid.

        The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once.

        Example:

        board =
        [
          ['A','B','C','E'],
          ['S','F','C','S'],
          ['A','D','E','E']
        ]

        Given word = "ABCCED", return true.
        Given word = "SEE", return true.
        Given word = "ABCB", return false.


         */
        int rows = 0;
        int cols = 0;
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