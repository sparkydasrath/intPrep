using System;

namespace General
{
    public class BacktrackingNQueensProblem
    {
        /*https://www.youtube.com/watch?v=xFv_Hl4B83A&index=61&list=PLDN4rrl48XKpZkf03iYFl-O29szjTrs_O
         https://www.c-sharpcorner.com/article/fun-with-backtracking-the-n-queen-problem/
        constraints - queens cannot be in the same row, column, or diagonal
                */

        public bool IsBoardValid(int[,] board, int col)
        {
            // base case
            if (col >= board.GetLength(0)) return true; // found a solution
            for (int row = 0; row < board.GetLength(0); row++)
            {
                if (IsMoveAllowed(board, row, col))
                {
                    board[row, col] = 1;
                    PrintBoard(board);
                    Console.Write("========\n");
                    if (IsBoardValid(board, col + 1)) return true;
                    board[row, col] = 0;
                }
            }

            return false;
        }

        public bool IsMoveAllowed(int[,] board, int row, int col)
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

        public bool IsMoveAllowedLessReadable(int[,] board, int col, int row)
        {
            for (int i = 0; i <= col; i++)
            {
                if (board[i, row] == 1 || (i <= row && board[col - i, row - i] == 1) || (row + i < board.GetLength(0) && board[col - i, row + i] == 1))
                {
                    return false;
                }
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
    }
}