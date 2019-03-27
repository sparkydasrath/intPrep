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

        public static void LengthOfDesiredPhoneNumber(char[,] input, NumberLength numberLength)
        {
            if (input.GetLength(0) * input.GetLength(1) < (int)numberLength)
                throw new ArgumentException($"Input size too small to generate numbers of length {numberLength}", nameof(numberLength));
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
        private readonly HashSet<string> results;
        private readonly int rows;
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

            results = new HashSet<string>();
            visited = new bool[rows, cols];
        }

        public HashSet<string> GeneratePhoneNumbers(ChessPiece chessPiece, NumberLength numberLength)
        {
            ValidateParameters.LengthOfDesiredPhoneNumber(baseList, numberLength);

            // set these to private fields so that you don't need to needlessly pass it as params in
            // the helper

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
                            {
                                if (strategy == null)
                                    strategy = new KingStrategyGeneration(baseList, exclusionSet, nonStartingSet, visited, numberLength, results);
                                strategy.DfsHelper(row, col, new List<char>());
                                break;
                            }

                        case ChessPiece.Knight:
                            if (strategy == null)
                                strategy = new KnightStrategyGeneration(baseList, exclusionSet, nonStartingSet, visited, numberLength, results);
                            strategy.DfsHelper(row, col, new List<char>());
                            break;

                        case ChessPiece.Pawn:
                            if (strategy == null)
                                strategy = new PawnStrategyGeneration(baseList, exclusionSet, nonStartingSet, visited, numberLength, results);
                            strategy.DfsHelper(row, col, new List<char>());
                            break;

                        case ChessPiece.Queen:
                            {
                                if (strategy == null)
                                    strategy = new QueenStrategyGeneration(baseList, exclusionSet, nonStartingSet, visited, numberLength, results);
                                strategy.DfsHelper(row, col, new List<char>());
                                break;
                            }
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
}