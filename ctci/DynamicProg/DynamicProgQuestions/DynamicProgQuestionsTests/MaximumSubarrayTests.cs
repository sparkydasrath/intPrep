using DynamicProgQuestions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DynamicProgQuestionsTests
{
    [TestFixture]
    public class MaximumSubarrayTests
    {
        [Test]
        public void ShouldReturnMaximumSubarray()
        {
            MaximumSubarray ms = new MaximumSubarray();
            int[] test = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            MaximumSubarray.MaximumSubarrayResult result = ms.GetMaxSubarray(test);
            Assert.That(result.MaxSum, Is.EqualTo(6));
        }
    }
}