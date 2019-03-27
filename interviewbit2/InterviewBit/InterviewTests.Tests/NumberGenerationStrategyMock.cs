using System.Collections.Generic;

namespace InterviewTests.Tests
{
    public class NumberGenerationStrategyMock : NumberGenerationStrategy
    {
        private readonly char[,] baseList;
        private readonly HashSet<char> exclusionSet;
        private readonly HashSet<char> nonStartingSet;
        private readonly HashSet<string> results;
        private readonly bool[,] visited;

        public NumberGenerationStrategyMock(char[,] baseList, HashSet<char> exclusionSet, HashSet<char> nonStartingSet, bool[,] visited, HashSet<string> results) : base(baseList, exclusionSet, nonStartingSet, visited)
        {
            this.baseList = baseList;
            this.exclusionSet = exclusionSet;
            this.nonStartingSet = nonStartingSet;
            this.visited = visited;
            this.results = results;
        }

        public override void DfsHelper(int row, int col, List<char> accumulator) => throw new System.NotImplementedException();

        public int GetResultWhenBaseCaseIsInvalid()
        {
            CheckBaseCase(new List<char>(), NumberLength.Seven, results);
            return results.Count;
        }

        public int GetResultWhenBaseCaseIsValid()
        {
            CheckBaseCase(new List<char> { 'a', 'a', 'a', 'a', 'a', 'a', 'a' }, NumberLength.Seven, results);
            return results.Count;
        }

        public bool GetResultWhenMoveIsInvalid()
        {
            bool result = IsNotValidMove(-1, 0);
            return result;
        }

        public bool GetResultWhenNonStartingCharIsEncountered()
        {
            bool result = IsNotAllowedToStartWith(0, 0, new List<char>());
            return result;
        }
    }
}