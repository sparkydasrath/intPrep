using DynamicProgQuestions;
using NUnit.Framework;

namespace DynamicProgQuestionsTests
{
    [TestFixture]
    public class KnapsackProblemTests
    {
        [Test]
        public void ShouldReturnTheOptimalSolutionToKnapsackProblem()
        {
            KnapsackProblem kp = new KnapsackProblem();
            int[] cost = { 0, 1, 2, 5, 6 };
            int[] weight = { 0, 2, 3, 4, 5 };
            int bagCapacity = 8;
            int[] result = kp.GetOptimal(cost, weight, bagCapacity);
            int[] expected = { };
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}