using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class UniqueBinarySearchTreesTests
    {
        [TestCase(3, ExpectedResult = 5)]
        [TestCase(4, ExpectedResult = 14)]
        [TestCase(5, ExpectedResult = 42)]
        public int ShouldReturnCorrectCountOfUniqueBstForGivenInput(int input)
        {
            UniqueBinarySearchTrees ubst = new UniqueBinarySearchTrees();
            int result = ubst.CountUniqueBst(input);
            return result;
        }
    }
}