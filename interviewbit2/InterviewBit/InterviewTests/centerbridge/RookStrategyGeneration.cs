using System.Collections.Generic;

namespace InterviewTests.centerbridge
{
    public class RookStrategyGeneration : NumberGenerationStrategy
    {
        private readonly char[,] baseList;
        private readonly NumberLength numLength;
        private readonly HashSet<string> results;
        private readonly bool[,] visited;

        public RookStrategyGeneration(char[,] baseList, HashSet<char> exclusionSet, HashSet<char> nonStartingSet, bool[,] visited, NumberLength numLength, HashSet<string> results) :
            base(baseList, exclusionSet, nonStartingSet, visited)
        {
            this.baseList = baseList;
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

            // explore in 4 directions for rook
            for (int i = row; i < baseList.GetLength(0); i++)
            {
                // for lop to allow exploration in more than 1 cell increments
                DfsHelper(row + i, col, new List<char>(accumulator)); // down
                DfsHelper(row - i, col, new List<char>(accumulator)); // up
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