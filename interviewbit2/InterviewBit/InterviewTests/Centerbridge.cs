using System;
using System.Collections.Generic;

namespace InterviewTests
{
    public enum ChessPiece
    {
        Bishop,
        King,
        Knight,
        Pawn,
        Queen,
        Rook,
    }

    public enum NumberLength
    {
        Seven = 7,
        Nine = 9
    }

    public static class ValidateParameters
    {
        public static void Input(char[,] input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input), "Input is null - please enter a valid matrix");
            if (input.GetLength(0) == 0 || input.GetLength(1) == 0) throw new ArgumentException("Input is not properly formed - one of the dimensions is zero", nameof(input));
        }

        public static void LengthOfDesiredPhoneNumber(char[,] input, NumberLength numberLength)
        {
            if (input.GetLength(0) * input.GetLength(1) < (int)numberLength)
                throw new ArgumentException($"Input size too small to generate numbers of length {numberLength}", nameof(numberLength));
        }
    }

    public class BishopStrategyGeneration : NumberGenerationStrategy
    {
        private readonly char[,] baseList;
        private readonly HashSet<char> exclusionSet;
        private readonly HashSet<char> nonStartingSet;
        private readonly NumberLength numLength;
        private readonly List<string> results;
        private readonly bool[,] visited;

        public BishopStrategyGeneration(char[,] baseList, HashSet<char> exclusionSet, HashSet<char> nonStartingSet, bool[,] visited, NumberLength numLength, List<string> results) : base(baseList, exclusionSet, visited)
        {
            this.baseList = baseList;
            this.exclusionSet = exclusionSet;
            this.nonStartingSet = nonStartingSet;
            this.visited = visited;
            this.numLength = numLength;
            this.results = results;
        }

        public override void DfsHelper(int row, int col, List<char> accumulator)
        {
            if (accumulator.Count == (int)numLength)
            {
                results.Add(FormatNumber(accumulator, numLength));
                return;
            }

            if (CheckBoundaryConditions(row, col)) return;

            // anything in the nonStartingSet will not be used as the start of the phone number
            if (accumulator.Count == 0 && nonStartingSet.Contains(baseList[row, col])) return;

            // mark as visited
            visited[row, col] = true;
            accumulator.Add(baseList[row, col]);

            // explore in 4 diagonal directions for bishop
            DfsHelper(row + 1, col + 1, new List<char>(accumulator)); // up + right
            DfsHelper(row + 1, col - 1, new List<char>(accumulator)); // up + left
            DfsHelper(row - 1, col + 1, new List<char>(accumulator)); // down + right
            DfsHelper(row - 1, col - 1, new List<char>(accumulator)); // down + left

            // backtrack
            accumulator.RemoveAt(accumulator.Count - 1);
            visited[row, col] = false;
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

        private readonly char[,] baseList;
        private readonly int cols;
        private readonly HashSet<char> exclusionSet;
        private readonly HashSet<char> nonStartingSet;
        private readonly List<string> results;
        private readonly int rows;
        private NumberLength numLength;
        private ChessPiece piece;
        private readonly bool[,] visited;

        public Centerbridge(char[,] baseList, char[] exclusionList, char[] nonStartingList)
        {
            this.baseList = baseList;
            ValidateParameters.Input(baseList);

            exclusionSet = new HashSet<char>();
            nonStartingSet = new HashSet<char>();
            PopulateRestrictedSets(exclusionList, nonStartingList);

            rows = this.baseList.GetLength(0);
            cols = this.baseList.GetLength(1);

            results = new List<string>();
            visited = new bool[rows, cols];
        }

        public List<string> GeneratePhoneNumbers(ChessPiece chessPiece, NumberLength numberLength)
        {
            ValidateParameters.LengthOfDesiredPhoneNumber(baseList, numberLength);

            // set these to private fields so that you don't need to needlessly pass it as params in
            // the helper
            piece = chessPiece;
            numLength = numberLength;
            NumberGenerationStrategy strategy = null;

            // reset
            ResetVisitedAndResults();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (visited[row, col]) continue;
                    switch (chessPiece)
                    {
                        case ChessPiece.Rook:
                            {
                                if (strategy == null)
                                    strategy = new RookStrategyGeneration(baseList, exclusionSet, nonStartingSet, visited, numberLength, results);

                                strategy.DfsHelper(row, col, new List<char>());
                                break;
                            }
                        case ChessPiece.Bishop:
                            {
                                if (strategy == null)
                                    strategy = new BishopStrategyGeneration(baseList, exclusionSet, nonStartingSet, visited, numberLength, results);
                                strategy.DfsHelper(row, col, new List<char>());
                                break;
                            }

                        case ChessPiece.King:
                            break;

                        case ChessPiece.Knight:
                            break;

                        case ChessPiece.Pawn:
                            break;

                        case ChessPiece.Queen:
                            break;

                        default: break;
                    }
                }
            }

            foreach (string r in results)
            {
                string num = string.Join("", r);
                Console.WriteLine(num);
            }

            return results;
        }

        private bool CheckBoundaryConditions(int row, int col)
        {
            bool boundaryCheck = row < 0 || row >= rows || col < 0 || col >= cols ||
                                 exclusionSet.Contains(baseList[row, col]) ||
                                 visited[row, col];

            return boundaryCheck;
        }

        private void GeneratePhoneNumbersHelper(int row, int col, List<char> accumulator)
        {
            if (accumulator.Count == (int)numLength)
            {
                string numResult = new string(accumulator.ToArray());

                results.Add(new string(accumulator.ToArray()));
                return;
            }

            if (CheckBoundaryConditions(row, col)) return;

            // anything in the nonStartingSet will not be used as the start of the phone number
            if (accumulator.Count == 0 && nonStartingSet.Contains(baseList[row, col])) return;

            // mark as visited
            visited[row, col] = true;
            accumulator.Add(baseList[row, col]);

            // explore based on chess piece chosen can prob do a strategy pattern here

            // explore in 4 directions for rook
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

        private void PopulateRestrictedSets(char[] nonStartingChars, char[] excludedChars)
        {
            if (nonStartingChars != null)
            {
                foreach (char nonStartingChar in nonStartingChars)
                    if (!nonStartingSet.Contains(nonStartingChar)) nonStartingSet.Add(nonStartingChar);
            }

            if (excludedChars != null)
            {
                foreach (char excludedChar in excludedChars)
                    if (!exclusionSet.Contains(excludedChar)) exclusionSet.Add(excludedChar);
            }
        }

        private void ResetVisitedAndResults()
        {
            results.Clear();

            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                    visited[row, col] = false;
        }
    }

    public abstract class NumberGenerationStrategy
    {
        private readonly char[,] baseList;
        private readonly int cols;
        private readonly HashSet<char> exclusionSet;
        private readonly int rows;
        private readonly bool[,] visited;

        protected NumberGenerationStrategy(char[,] baseList, HashSet<char> exclusionSet, bool[,] visited)
        {
            this.baseList = baseList;
            this.exclusionSet = exclusionSet;
            this.visited = visited;
            rows = baseList.GetLength(0);
            cols = baseList.GetLength(1);
        }

        public abstract void DfsHelper(int row, int col, List<char> accumulator);

        protected bool CheckBoundaryConditions(int row, int col)
        {
            bool boundaryCheck = row < 0 || row >= rows || col < 0 || col >= cols ||
                                 exclusionSet.Contains(baseList[row, col]) ||
                                 visited[row, col];

            return boundaryCheck;
        }

        protected string FormatNumber(List<char> numbers, NumberLength numberLength)
        {
            List<char> temp = numbers;
            if (numberLength == NumberLength.Seven)
            {
                temp.Insert(3, '-');
            }
            else
            {
                temp.Insert(3, '-');
                temp.Insert(7, '-');
            }

            return new string(temp.ToArray());
        }
    }

    public class RookStrategyGeneration : NumberGenerationStrategy
    {
        private readonly char[,] baseList;
        private readonly HashSet<char> exclusionSet;
        private readonly HashSet<char> nonStartingSet;
        private readonly NumberLength numLength;
        private readonly List<string> results;
        private readonly bool[,] visited;

        public RookStrategyGeneration(char[,] baseList, HashSet<char> exclusionSet, HashSet<char> nonStartingSet, bool[,] visited, NumberLength numLength, List<string> results) :
            base(baseList, exclusionSet, visited)
        {
            this.baseList = baseList;
            this.exclusionSet = exclusionSet;
            this.nonStartingSet = nonStartingSet;
            this.visited = visited;
            this.numLength = numLength;
            this.results = results;
        }

        public override void DfsHelper(int row, int col, List<char> accumulator)
        {
            if (accumulator.Count == (int)numLength)
            {
                results.Add(FormatNumber(accumulator, numLength));
                return;
            }

            if (CheckBoundaryConditions(row, col)) return;

            // anything in the nonStartingSet will not be used as the start of the phone number
            if (accumulator.Count == 0 && nonStartingSet.Contains(baseList[row, col])) return;

            // mark as visited
            visited[row, col] = true;
            accumulator.Add(baseList[row, col]);

            // explore based on chess piece chosen can prob do a strategy pattern here

            // explore in 4 directions for rook
            for (int i = row; i < baseList.GetLength(0); i++)
            {
                // for lop to allow exploration in more than 1 cell increments
                DfsHelper(row + i, col, new List<char>(accumulator)); // up
                DfsHelper(row - i, col, new List<char>(accumulator)); // down
            }

            for (int i = col; i < baseList.GetLength(1); i++)
            {
                // for lop to allow exploration in more than 1 cell increments
                DfsHelper(row, col + i, new List<char>(accumulator)); // right
                DfsHelper(row, col - i, new List<char>(accumulator)); // left
            }

            // backtrack
            accumulator.RemoveAt(accumulator.Count - 1);
            visited[row, col] = false;
        }
    }
}