using System;
using System.Collections.Generic;

namespace InterviewTests
{
    public static class ValidateParameters
    {
        public static void Input(char[,] input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input), "Input is null - please enter a valid matrix");
            if (input.GetLength(0) == 0 || input.GetLength(1) == 0) throw new ArgumentException("Input is not properly formed - one of the dimensions is zero", nameof(input));
        }

        public static void LengthOfDesiredPhoneNumber(char[,] input, int lengthOfPhoneNumber)
        {
            if (input.GetLength(0) * input.GetLength(1) < lengthOfPhoneNumber)
                throw new ArgumentException($"Input size too small to generate numbers of length {lengthOfPhoneNumber}", nameof(lengthOfPhoneNumber));
        }
    }

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
        private readonly HashSet<char> invalidCharsHashSet;
        private readonly int lengthOfPhoneNumber;
        private readonly List<string> results;
        private readonly int rows;
        private readonly bool[,] visited;

        public Centerbridge(char[,] input, char[] invalidChars, string chessPiece, int lengthOfPhoneNumber)
        {
            this.input = input;
            this.lengthOfPhoneNumber = lengthOfPhoneNumber;
            ValidateParameters.Input(input);

            invalidCharsHashSet = new HashSet<char>();
            CreateInvalidCharsHashSet(invalidChars);

            rows = this.input.GetLength(0);
            cols = this.input.GetLength(1);

            ValidateParameters.LengthOfDesiredPhoneNumber(input, lengthOfPhoneNumber);

            results = new List<string>();
            visited = new bool[rows, cols];
        }

        public List<string> GeneratePhoneNumbers()
        {
            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                    if (!visited[row, col]) GeneratePhoneNumbersHelper(row, col, new List<char>());

            foreach (string r in results)
            {
                string num = string.Join("", r);
                Console.WriteLine(num);
            }

            return results;
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
            for (int i = row; i < rows; i++)
            {
                // for lop to allow exploration in more than 1 cell increments
                GeneratePhoneNumbersHelper(row + i, col, new List<char>(accumulator)); // up
                GeneratePhoneNumbersHelper(row - i, col, new List<char>(accumulator)); // down
            }

            for (int i = col; i < cols; i++)
            {
                // for lop to allow exploration in more than 1 cell increments
                GeneratePhoneNumbersHelper(row, col + i, new List<char>(accumulator)); // right
                GeneratePhoneNumbersHelper(row, col - i, new List<char>(accumulator)); // left
            }

            // backtrack
            accumulator.RemoveAt(accumulator.Count - 1);
            visited[row, col] = false;
        }

        private bool CheckBoundaryConditions(int row, int col)
        {
            bool boundaryCheck = row < 0 || row >= rows || col < 0 || col >= cols ||
                                 invalidCharsHashSet.Contains(input[row, col]) ||
                                 visited[row, col];

            return boundaryCheck;
        }

        private void CreateInvalidCharsHashSet(char[] invalidChars)
        {
            if (invalidChars == null || invalidChars.Length == 0) return;

            foreach (char invalidChar in invalidChars)
            {
                if (!invalidCharsHashSet.Contains(invalidChar))
                    invalidCharsHashSet.Add(invalidChar);
            }
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