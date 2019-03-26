using System.Collections.Generic;

namespace InterviewTests
{
    public class RookStrategyGeneration : NumberGenerationStrategy
    {
        private readonly char[,] baseList;
        private readonly HashSet<char> exclusionSet;
        private readonly HashSet<char> nonStartingSet;
        private readonly NumberLength numLength;
        private readonly HashSet<string> results;
        private readonly bool[,] visited;

        public RookStrategyGeneration(char[,] baseList, HashSet<char> exclusionSet, HashSet<char> nonStartingSet, bool[,] visited, NumberLength numLength, HashSet<string> results) :
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
            /*if (accumulator.Count == (int)numLength)
            {
                string validNumber = FormatNumber(accumulator, numLength);
                if (!results.Contains(validNumber))
                    results.Add(validNumber);
                return;
            }*/

            CheckBaseCase(accumulator, numLength, results);

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