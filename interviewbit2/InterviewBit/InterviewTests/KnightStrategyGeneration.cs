using System.Collections.Generic;

namespace InterviewTests
{
    public class KnightStrategyGeneration : NumberGenerationStrategy
    {
        private readonly char[,] baseList;
        private readonly HashSet<char> nonStartingSet;
        private readonly NumberLength numLength;
        private readonly HashSet<string> results;
        private readonly bool[,] visited;

        public KnightStrategyGeneration(char[,] baseList, HashSet<char> exclusionSet, HashSet<char> nonStartingSet, bool[,] visited, NumberLength numLength, HashSet<string> results) : base(baseList, exclusionSet, nonStartingSet, visited)
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

            // down 2 + left & right 1
            DfsHelper(row + 2, col + 1, new List<char>(accumulator)); // down + down + right
            DfsHelper(row + 2, col - 1, new List<char>(accumulator)); // down down + left

            // down 1 + left & right 2
            DfsHelper(row + 1, col + 2, new List<char>(accumulator)); // down + right + right
            DfsHelper(row + 1, col - 2, new List<char>(accumulator)); // down + left + left

            // up 2 + left & right 1
            DfsHelper(row - 2, col + 1, new List<char>(accumulator)); // up + up + right
            DfsHelper(row - 2, col - 1, new List<char>(accumulator)); // up up + left

            // up 1 + left & right 2
            DfsHelper(row - 1, col + 2, new List<char>(accumulator)); // down + right + right
            DfsHelper(row - 1, col - 2, new List<char>(accumulator)); // down + left + left

            // backtrack
            accumulator.RemoveAt(accumulator.Count - 1);
            visited[row, col] = false;
        }
    }
}