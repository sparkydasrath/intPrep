using DynamicProgQuestions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DynamicProgQuestionsTests
{
    [TestFixture]
    public class LongestCommonSubsequenceTests
    {
        [Test]
        public void ShouldReturnListOfSubsequencesNaive()
        {
            LongestCommonSubsequence lcs = new LongestCommonSubsequence();
            string one = "abdace";
            string two = "babce";
            System.Collections.Generic.List<string> result = lcs.GetAllSubsequencesNaive(one, two);
            Assert.That(result.Count, Is.Not.EqualTo(0));
        }

        [Test]
        public void ShouldReturnListOfSubsequencesRecursive()
        {
            LongestCommonSubsequence lcs = new LongestCommonSubsequence();
            int result = lcs.GetLcsRecursive(0, 0);
            Assert.That(result, Is.EqualTo(4));
        }
    }
}