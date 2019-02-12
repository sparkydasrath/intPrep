using NUnit.Framework;

namespace TwoPointers.Tests
{
    [TestFixture]
    public class SquaresOfSortedArraysTests
    {
        [TestCase(new[] { -1 }, ExpectedResult = new[] { 1 })]
        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(new[] { -4, -1, 0, 3, 10 }, ExpectedResult = new[] { 0, 1, 9, 16, 100 })]
        [TestCase(new[] { -7, -3, 2, 3, 11 }, ExpectedResult = new[] { 4, 9, 9, 49, 121 })]
        public int[] ShouldReturnArrayOfSortedSquaresSimple(int[] input)
        {
            SquaresOfSortedArrays sa = new SquaresOfSortedArrays();
            int[] results = sa.SortedSquaresSimple(input);
            return results;
        }

        [TestCase(new[] { -1 }, ExpectedResult = new[] { 1 })]
        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(new[] { -4, -1, 0, 3, 10 }, ExpectedResult = new[] { 0, 1, 9, 16, 100 })]
        [TestCase(new[] { -7, -3, 2, 3, 11 }, ExpectedResult = new[] { 4, 9, 9, 49, 121 })]
        public int[] ShouldReturnArrayOfSortedSquaresTwoPointer(int[] input)
        {
            SquaresOfSortedArrays sa = new SquaresOfSortedArrays();
            int[] results = sa.SortedSquaresTwoPointer(input);
            return results;
        }
    }
}