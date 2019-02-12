using NUnit.Framework;

namespace SearchAndSort.Tests
{
    [TestFixture]
    public class SearchesTests
    {
        [TestCase(new int[] { 2, 5, 7, 11, 12, 15, 20, 30, 34, 36 }, 30, ExpectedResult = 7)]
        public int ShouldReturnIndexOfBinarySearchElement(int[] n, int k)
        {
            Searches bs = new Searches();
            int result = bs.BinarySearch(0, n.Length, n, k);
            return result;
        }

        [TestCase(new[] { 2, 5, 7, 11, 12, 15, 20, 30, 34, 36 }, 30, ExpectedResult = 7)]
        public int ShouldReturnIndexOfTernarySearchElement(int[] n, int k)
        {
            Searches bs = new Searches();
            int result = bs.TernarySearch(0, n.Length, n, k);
            return result;
        }
    }
}