using System.Collections.Generic;

namespace InterviewTests
{
    public class KingStrategyGeneration : NumberGenerationStrategy
    {
        private readonly char[,] baseList;
        private readonly HashSet<char> nonStartingSet;
        private readonly NumberLength numLength;
        private readonly HashSet<string> results;
        private readonly bool[,] visited;

        public KingStrategyGeneration(char[,] baseList, HashSet<char> exclusionSet, HashSet<char> nonStartingSet, bool[,] visited, NumberLength numLength, HashSet<string> results) : base(baseList, exclusionSet, nonStartingSet, visited)
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

            if (IsNotValidMove(row, col)) return;

            if (IsNotAllowedToStartWith(row, col, accumulator)) return;

            // mark as visited
            visited[row, col] = true;
            accumulator.Add(baseList[row, col]);

            // explore in 4 directions for king
            DfsHelper(row + 1, col, new List<char>(accumulator)); // down
            DfsHelper(row - 1, col, new List<char>(accumulator)); // up
            DfsHelper(row, col + 1, new List<char>(accumulator)); // right
            DfsHelper(row, col - 1, new List<char>(accumulator)); // left

            // explore in 4 diagonals for king
            DfsHelper(row + 1, col + 1, new List<char>(accumulator)); // up + right
            DfsHelper(row + 1, col - 1, new List<char>(accumulator)); // up + left
            DfsHelper(row - 1, col + 1, new List<char>(accumulator)); // down + right
            DfsHelper(row - 1, col - 1, new List<char>(accumulator)); // down + left

            // backtrack
            accumulator.RemoveAt(accumulator.Count - 1);
            visited[row, col] = false;
        }
    }
}