using System.Collections.Generic;

namespace InterviewTests.centerbridge
{
    public abstract class NumberGenerationStrategy
    {
        private readonly char[,] baseList;
        private readonly int cols;
        private readonly HashSet<char> exclusionSet;
        private readonly HashSet<char> nonStartingSet;
        private readonly int rows;
        private readonly bool[,] visited;

        protected NumberGenerationStrategy(char[,] baseList, HashSet<char> exclusionSet, HashSet<char> nonStartingSet, bool[,] visited)
        {
            this.baseList = baseList;
            this.exclusionSet = exclusionSet;
            this.nonStartingSet = nonStartingSet;
            this.visited = visited;
            rows = baseList.GetLength(0);
            cols = baseList.GetLength(1);
        }

        public abstract void DfsHelper(int row, int col, List<char> accumulator);

        protected void CheckBaseCase(List<char> accumulator, NumberLength numLength, HashSet<string> results)
        {
            if (accumulator.Count != (int)numLength) return;
            string validNumber = FormatNumber(accumulator, numLength);
            if (!results.Contains(validNumber))
                results.Add(validNumber);
        }

        protected bool IsNotAllowedToStartWith(int row, int col, List<char> accumulator) => accumulator.Count == 0 && nonStartingSet.Contains(baseList[row, col]);

        protected bool IsNotValidMove(int row, int col)
        {
            bool boundaryCheck = row < 0 || row >= rows || col < 0 || col >= cols ||
                                 exclusionSet.Contains(baseList[row, col]) ||
                                 visited[row, col];

            return boundaryCheck;
        }

        private string FormatNumber(List<char> numbers, NumberLength numberLength)
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
}