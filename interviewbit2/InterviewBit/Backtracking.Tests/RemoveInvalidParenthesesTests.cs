using NUnit.Framework;
using System.Collections.Generic;

namespace Backtracking.Tests
{
    [TestFixture]
    public class RemoveInvalidParenthesesTests
    {
        [Test]
        public void ShouldRemoveInvalidParentheses()
        {
            RemoveInvalidParentheses r = new RemoveInvalidParentheses();
            List<string> results = r.RemoveInvalidParenthesesBfs("()())()");
            Assert.That(results.Count, Is.EqualTo(2));
        }
    }
}