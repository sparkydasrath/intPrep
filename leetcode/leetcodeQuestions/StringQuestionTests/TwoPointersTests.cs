using NUnit.Framework;
using NUnit.Framework.Internal;
using StringQuestions;

namespace StringQuestionTests
{
    [TestFixture]
    public class TwoPointersTests
    {
        [Test]
        public void ShouldFindConsecutiveOnes()
        {
            TwoPointers tp = new TwoPointers();
            int[] test = { 1, 1, 0, 1, 1, 1 };
            int result = tp.FindMaxConsecutiveOnes(test);
            int exp = 3;
            Assert.That(result, Is.EqualTo(exp));
        }

        [Test]
        public void ShouldRemoveElementAndGetNewLength()
        {
            TwoPointers tp = new TwoPointers();
            int[] test = { 1, 3, 2, 4, 5 };
            int result = tp.RemoveElement(test, 2);
            int[] exp = { 1, 2 };
            Assert.That(result, Is.EqualTo(exp));
        }

        [Test]
        public void ShouldReturnCorrectSum()
        {
            TwoPointers tp = new TwoPointers();
            int[] test = { 3, 6, 0, 1 };
            int result = tp.ArrayPairSum(test);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void ShouldReturnCorrectTwoSumIndices()
        {
            TwoPointers tp = new TwoPointers();
            int[] test = { -1, 0 };
            int[] result = tp.TwoSum(test, -1);
            int[] exp = { 1, 2 };
            Assert.That(result, Is.EqualTo(exp));
        }
    }
}