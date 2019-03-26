using System.Collections.Generic;

namespace InterviewTests
{
    public class BishopStrategyGeneration : NumberGenerationStrategy
    {
        private readonly char[,] baseList;
        private readonly HashSet<char> nonStartingSet;
        private readonly NumberLength numLength;
        private readonly HashSet<string> results;
        private readonly bool[,] visited;

        public BishopStrategyGeneration(char[,] baseList, HashSet<char> exclusionSet, HashSet<char> nonStartingSet, bool[,] visited, NumberLength numLength, HashSet<string> results) : base(baseList, exclusionSet, visited)
        {
            this.baseList = baseList;
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
}