using NUnit.Framework;
using System.Collections.Generic;

namespace Backtracking.Tests
{
    [TestFixture]
    public class GenerateParenthesesTests
    {
        [Test]
        public void ShouldGenerateMatchingParenthesesPairs()
        {
            GenerateParentheses generateParentheses = new GenerateParentheses();
            List<string> result = generateParentheses.GenerateParenthesis(3);
            List<string> expected = new List<string>
            {
                "((()))",
                "(()())",
                "(())()",
                "()(())",
                "()()()"
            };
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}