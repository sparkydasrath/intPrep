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

        private readonly IList<IList<string>> results;
        private int[,] baseBoard;
        private int size;

        public NQueens() => results = new List<IList<string>>();

        public bool IsBoardValid(int[,] board, int row, int col)
        {
            int n = board.GetLength(0);
            int i, j;

            for (i = 0; i < col; i++)
            {
                // row is fixed and check if there are any queens for each column on this row
                if (board[row, i] == 1) return false;
            }

            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                // for the current row,col position, iterate left and up (diagonal) looking for a spot
                if (board[i, j] == 1) return false;
            }

            for (i = row, j = col; i < n && j >= 0; i++, j--)
            {
                // for the current row,col position, iterate left and down (diagonal) looking for a spot
                if (board[i, j] == 1) return false;
            }

            return true;
        }

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

        public IList<IList<string>> SolveNQueens(int n)
        {
            if (n < 4) return results;

            size = n;
            baseBoard = new int[n, n];

            SolveNQueensDfs(baseBoard, 0);

            PrintBoard(baseBoard);

            return results;
        }

        private bool IsBoardValid2(int[,] board, int row, int col)
        {
            bool isBoundaryValid = false;
            bool isColumnValid = false;
            bool isDiagonalValid = false;

            // boundary checks
            if (row >= 0 || row < size || col >= 0 || col < size)
                isBoundaryValid = true;

            // valid if there are no queens in the same column
            for (int c = 0; c < size; c++)
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

            for (i = row, j = col; i < size && j >= 0; i++, j--)
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

            if (row >= size) return;
            for (int col = 0; col < board.GetLength(0); col++)
            {
                // place queen
                board[row, col] = 1;

                bool isValid = IsBoardValid2(board, row, col);

                if (isValid)
                {
                    Console.Write("After is valid check  1========\n");
                    PrintBoard(board);
                    Console.Write("After is valid check  2========\n");

                    // if the board is valid for that row and columns move to next row
                    SolveNQueensDfs(board, row + 1);
                }

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