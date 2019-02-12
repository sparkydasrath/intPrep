using NUnit.Framework;

namespace General.Tests
{
    [TestFixture]
    public class DpSubsetSumProblemBaseTests
    {
        [TestCase(new int[] { 2, 3, 7, 8, 10 }, 10, ExpectedResult = true)]
        public bool IsSubsetSum(int[] n, int givenSum)
        {
            DpSubsetSumProblemBase ssp = new DpSubsetSumProblemBase();
            bool result = ssp.IsSubsetSumEqualToGivenSum(n, givenSum);
            return result;
        }
    }
}