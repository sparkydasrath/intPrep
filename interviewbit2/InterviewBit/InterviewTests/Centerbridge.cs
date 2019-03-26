using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace InterviewTests
{
    public class Centerbridge
    {
        /*

        Problem:
        The following diagram is of a standard telephone keypad. It consists of a 4x3 grid of buttons.
        Using the valid moves of a piece from the game of chess, varying combinations of 7-digit phone
        numbers can be derived. For example, starting in the upper-right corner (the “3” key) using a rook
        (which moves any number of spaces horizontally or vertically), one valid number is: 314-5289.

            1   2   3
            4   5   6
            7   8   9
            *   0   #

        Write a program that will count the number of valid 7-digit phone numbers that can be traced
        out on the keypad for a given chess piece. The following rules define a valid phone number:
        • Seven digits in length
        • Cannot start with a 0 or 1
        • Cannot contain a * or #
        Design goals:
        • Object-oriented design concepts should be used where ever they make sense
        • The program should be flexible enough so that it is easy to use with any chess piece.
            Note that it is possible that some pieces may not have any valid phone numbers.
        • It should be easy for the user to select the type of piece to use at runtime
            (no recompile or source code change required).
        • I should be easy to extend the program for new requirements, for example a new
            keypad layout or different rules for a valid phone number.

         */

        private readonly int cols;
        private readonly char[,] input;
        private readonly char[] invalidChars;
        private readonly List<string> results;
        private readonly int rows;
        private readonly bool[,] visited;

        public Centerbridge(char[,] input, char[] invalidChars)
        {
            this.input = GetSampleData() ?? throw new InvalidEnumArgumentException("Please provide a valid matrix");
            rows = this.input.GetLength(0);
            cols = this.input.GetLength(1);

            // deal with some checking here such as the min elements needed to make phone numbers

            this.invalidChars = invalidChars;
            results = new List<string>();
            visited = new bool[rows, cols];
        }

        public void GeneratePhoneNumbers()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!visited[row, col])
                        GeneratePhoneNumbersHelper(row, col, new List<char>());
                }
            }

            foreach (string r in results)
            {
                string num = string.Join("", r);
                if (num == "3145289") Console.ReadLine();
                Console.WriteLine(num);
            }
        }

        public void GeneratePhoneNumbersHelper(int row, int col, List<char> accumulator)
        {
            if (accumulator.Count == 7)
            {
                results.Add(new string(accumulator.ToArray()));
                return;
            }

            if (CheckBoundaryConditions(row, col)) return;

            if (accumulator.Count == 0 && (input[row, col] == '0' || input[row, col] == '1')) return;

            // mark as visited
            visited[row, col] = true;
            accumulator.Add(input[row, col]);

            // explore in 4 directions
            GeneratePhoneNumbersHelper(row, col + 1, new List<char>(accumulator)); // right
            GeneratePhoneNumbersHelper(row, col - 1, new List<char>(accumulator)); // left
            GeneratePhoneNumbersHelper(row + 1, col, new List<char>(accumulator)); // up
            GeneratePhoneNumbersHelper(row - 1, col, new List<char>(accumulator)); // down

            // backtrack

            accumulator.RemoveAt(accumulator.Count - 1);
            visited[row, col] = false;
        }

        private bool CheckBoundaryConditions(int row, int col)
        {
            bool boundaryCheck = row < 0 || row >= rows || col < 0 || col >= cols ||
                                 input[row, col] == '*' || input[row, col] == '#' ||
                                 visited[row, col];

            return boundaryCheck;
        }

        private char[,] GetSampleData()
        {
            char[,] data =
            {
                { '1','2','3'},
                { '4','5','6'},
                { '7','8','9'},
                { '*','0','#'},
            };

            return data;
        }
    }
}