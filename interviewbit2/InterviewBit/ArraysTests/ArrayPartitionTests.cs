using Arrays;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ArraysTests
{
    [TestFixture]
    public class ArrayPartitionTests
    {
        [Test]
        public void GetSumOfPairsOfParitions()
        {
            int sum = new ArrayPartition().ArrayPairSum(new[] { 1, 4, 3, 2 });
            /*
             * sum = min(1,2) + min(3,4) = 1 + 3 = 4
             *
             */
            Assert.That(sum, Is.EqualTo(4));
        }
    }
}