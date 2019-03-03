using System;
using System.Collections.Generic;

namespace Backtracking
{
    public class NQueens
    {
        /*
         51. N-Queens
        Hard

        The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.

        Given an integer n, return all distinct solutions to the n-queens puzzle.

        Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space respectively.

        Example:

        Input: 4
        Output: [
         [".Q..",  // Solution 1
          "...Q",
          "Q...",
          "..Q."],

         ["..Q.",  // Solution 2
          "Q...",
          "...Q",
          ".Q.."]
        ]
        Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above.

         */

        private readonly List<List<string>> results;

        public NQueens() => results = new List<List<string>>();

        public void PrintBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.Write("\n");
            }
        }

        public List<List<string>> SolveNQueens(int n)
        {
            if (n < 4) return results;

            int[,] board = new int[n, n];
            SolveNQueensDfs(board, 0);

            return results;
        }

        private bool IsBoardValid(int[,] board, int row, int col)
        {
            bool isBoundaryValid = false;
            bool isColumnValid = false;
            bool isDiagonalValid = false;

            // boundary checks
            if (row >= 0 || row <= board.GetLength(0) - 1 || col >= 0 || col <= board.GetLength(1))
                isBoundaryValid = true;

            // valid if there are no queens in the same column
            for (int c = 0; c < board.GetLength(1); c++)
            {
                if (board[row, c] == 0)
                {
                    // check that all other columns except the one for this row is zeroed out
                    isColumnValid = true;
                }
            }
            int i, j;

            // valid if no queens on diagonal
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                // for the current row,col position, iterate left and up (diagonal) looking for a spot
                if (board[i, j] != 1)
                    isDiagonalValid = true;
            }

            for (i = row, j = col; i < board.GetLength(0) && j >= 0; i++, j--)
            {
                // for the current row,col position, iterate left and down (diagonal) looking for a spot
                if (board[i, j] != 1) isDiagonalValid = true;
            }

            bool isBoardValid = isBoundaryValid && isColumnValid && isDiagonalValid;

            return isBoardValid;
        }

        private void SolveNQueensDfs(int[,] board, int row)
        {
            PrintBoard(board);
            Console.Write("========\n");
            for (int col = 0; col < board.GetLength(0); col++)
            {
                // place queen
                board[row, col] = 1;

                // if the board is valid for that row and columns move to next row
                if (IsBoardValid(board, row, col))
                    SolveNQueensDfs(board, row + 1);

                // remove queen
                board[row, col] = 0;
            }
        }

        private class NqBoard
        {
            public int[,] Board { get; set; }
        }
    }
}