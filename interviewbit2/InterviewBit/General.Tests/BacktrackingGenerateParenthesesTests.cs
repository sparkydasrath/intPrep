using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace General.Tests
{
    [TestFixture]
    public class BacktrackingGenerateParenthesesTests
    {
        [Test]
        public void ShouldGenerateMatchingParenthesesPairs()
        {
            BacktrackingGenerateParentheses backtrackingGenerateParentheses = new BacktrackingGenerateParentheses();
            List<string> result = backtrackingGenerateParentheses.GenerateParenthesis(3);
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