using NUnit.Framework;
using System.Collections.Generic;

namespace Backtracking.Tests
{
    [TestFixture]
    public class LetterPhoneNumbersTests
    {
        [Test]
        public void ShouldPrintLetterPhoneNumbers()
        {
            LetterPhoneNumbers lp = new LetterPhoneNumbers();
            List<string> results = lp.LetterCombinations("23");
            Assert.That(results.Count, Is.EqualTo(10));
        }
    }
}