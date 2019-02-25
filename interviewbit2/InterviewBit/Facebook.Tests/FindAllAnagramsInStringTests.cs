using NUnit.Framework;
using System.Collections.Generic;

namespace Facebook.Tests
{
    [TestFixture()]
    public class FindAllAnagramsInStringTests
    {
        [Test]
        public void ShouldReturnMinimumWindowSubstring()
        {
            FindAllAnagramsInString m = new FindAllAnagramsInString();
            List<int> result = m.FindAnagrams("cbaebabacd", "abc");
            Assert.That(result.Count, Is.EqualTo(2)); //{0,6}
        }
    }
}