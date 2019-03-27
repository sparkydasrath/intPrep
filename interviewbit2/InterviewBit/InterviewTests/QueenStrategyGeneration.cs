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

        public QueenStrategyGeneration(char[,] baseList, HashSet<char> exclusionSet, HashSet<char> nonStartingSet, bool[,] visited, NumberLength numLength, HashSet<string> results) :
            base(baseList, exclusionSet, nonStartingSet, visited)
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

            for (int i = row; i < baseList.GetLength(0); i++)
            {
                for (int j = col; j < baseList.GetLength(1); j++)
                {
                    DfsHelper(row + i, col + j, new List<char>(accumulator)); // down + right
                    DfsHelper(row + i, col - j, new List<char>(accumulator)); // down + left
                    DfsHelper(row - i, col + j, new List<char>(accumulator)); // up + right
                    DfsHelper(row - i, col - j, new List<char>(accumulator)); // up + left
                }
            }

            // backtrack
            accumulator.RemoveAt(accumulator.Count - 1);
            visited[row, col] = false;
        }
    }
}