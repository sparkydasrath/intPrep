using NUnit.Framework;
using StringQuestions;

namespace StringQuestionTests
{
    [TestFixture]
    public class LongestPrefixTests
    {
        [Test]
        public void ShouldReturnCorrectPrefix()
        {
            LongestPrefix lp = new LongestPrefix();
            string[] test = { "dog", "racecar", "car" };
            string exp = "";
            string result = lp.LongestCommonPrefix(test);
            Assert.That(result, Is.EqualTo(exp));
        }

        [Test]
        public void ShouldReturnCorrectPrefix2()
        {
            LongestPrefix lp = new LongestPrefix();
            string[] test = { "flower", "flow", "flight" };
            string exp = "fl";
            string result = lp.LongestCommonPrefix(test);
            Assert.That(result, Is.EqualTo(exp));
        }

        [Test]
        public void ShouldReturnCorrectPrefix3()
        {
            LongestPrefix lp = new LongestPrefix();
            string[] test = { "aca", "cba" };
            string exp = "";
            string result = lp.LongestCommonPrefix(test);
            Assert.That(result, Is.EqualTo(exp));
        }
    }
}