using System;
using System.Collections.Generic;

namespace Backtracking
{
    internal class Program
    {
        private bool exits = false;

        public bool Exist(char[,] board, string word)
        {
            bool[,] visited = new bool[board.GetLength(0), board.GetLength(1)];
            List<string> accumulator = new List<string>();
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (!visited[row, col])
                    {
                        ExistDfs(board, word, visited, accumulator, row, col);
                    }
                }

                return exits;
            }

            return false;
        }

        private static void Main(string[] args)
        {
            Program p = new Program();
            char[,] board = new char[3, 4];
            board[0, 0] = 'a';
            board[0, 1] = 'b';
            board[0, 2] = 'c';
            board[0, 3] = 'e';
            board[1, 0] = 's';
            board[1, 1] = 'f';
            board[1, 2] = 'c';
            board[1, 3] = 's';
            board[2, 0] = 'a';
            board[2, 1] = 'd';
            board[2, 2] = 'e';
            board[2, 3] = 'e';

            bool results = p.Exist(board, "see");

            Console.ReadLine();
        }

        private bool CanMove(char[,] board, int row, int col)
        {
            bool canMove = row >= 0 || row < board.GetLength(0) || col >= 0 || col < board.GetLength(1);
            return canMove;
        }

        private void ExistDfs(char[,] board, string word, bool[,] visited, List<string> accumulator, int row, int col)
        {
            if (accumulator.Count == word.Length && string.Join("", accumulator) == word)
            {
                exits = true;
                return;
            }

            if (!CanMove(board, row, col) || visited[row, col] || accumulator.Count == word.Length && string.Join("", accumulator) != word)
            {
                accumulator.RemoveAt(accumulator.Count - 1);
                // return;
            }

            visited[row, col] = true;
            accumulator.Add(board[row, col].ToString());

            // move in 4 directions
            ExistDfs(board, word, visited, accumulator, row, col + 1); // move right
            ExistDfs(board, word, visited, accumulator, row, col - 1); // move left
            ExistDfs(board, word, visited, accumulator, row + 1, col); // move down
            ExistDfs(board, word, visited, accumulator, row - 1, col); // move up

            // backtrack
            visited[row, col] = false;
            accumulator.RemoveAt(accumulator.Count - 1);
        }
    }
}