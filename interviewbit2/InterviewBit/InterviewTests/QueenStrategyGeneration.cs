using System.Collections.Generic;

namespace InterviewTests
{
    public class QueenStrategyGeneration : NumberGenerationStrategy
    {
        private readonly char[,] baseList;
        private readonly HashSet<char> nonStartingSet;
        private readonly NumberLength numLength;
        private readonly HashSet<string> results;
        private readonly bool[,] visited;

        public QueenStrategyGeneration(char[,] baseList, HashSet<char> exclusionSet, HashSet<char> nonStartingSet, bool[,] visited, NumberLength numLength, HashSet<string> results) : base(baseList, exclusionSet, visited)
        {
            this.baseList = baseList;
            this.nonStartingSet = nonStartingSet;
            this.visited = visited;
            this.numLength = numLength;
            this.results = results;
        }

        public override void DfsHelper(int row, int col, List<char> accumulator)
        {
            CheckBaseCase(accumulator, numLength, results);

            if (CheckBoundaryConditions(row, col)) return;

            // anything in the nonStartingSet will not be used as the start of the phone number
            if (accumulator.Count == 0 && nonStartingSet.Contains(baseList[row, col])) return;

            // mark as visited
            visited[row, col] = true;
            accumulator.Add(baseList[row, col]);

            // the queen can move in 8 directions and like the rook, can either move 1 or more
            // positions at a time

            // DfsHelper(row + 1, col, new List<char>(accumulator)); // up DfsHelper(row - 1, col,
            // new List<char>(accumulator)); // down DfsHelper(row, col + 1, new
            // List<char>(accumulator)); // right DfsHelper(row, col - 1, new
            // List<char>(accumulator)); // left
            //
            // DfsHelper(row + 1, col + 1, new List<char>(accumulator)); // up + right DfsHelper(row
            // + 1, col - 1, new List<char>(accumulator)); // up + left DfsHelper(row - 1, col + 1,
            // new List<char>(accumulator)); // down + right DfsHelper(row - 1, col - 1, new
            // List<char>(accumulator)); // down + left

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

            for (int i = row; i < baseList.GetLength(0); i++)
            {
                for (int j = col; j < baseList.GetLength(1); j++)
                {
                    DfsHelper(row + i, col + j, new List<char>(accumulator)); // up + right
                    DfsHelper(row + i, col - j, new List<char>(accumulator)); // up + left
                    DfsHelper(row - i, col + j, new List<char>(accumulator)); // down + right
                    DfsHelper(row - i, col - j, new List<char>(accumulator)); // down + left
                }
            }

            // backtrack
            accumulator.RemoveAt(accumulator.Count - 1);
            visited[row, col] = false;
        }
    }
}