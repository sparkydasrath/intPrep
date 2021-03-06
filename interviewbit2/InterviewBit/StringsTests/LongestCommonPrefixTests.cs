﻿using System.Collections.Generic;
using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class LongestCommonPrefixTests
    {
        [Test]
        public void ShouldReturnLongestPrefix()
        {
            List<string> input = new List<string> { "abc", "ab", "abbc" };
            LongestCommonPrefix lcp = new LongestCommonPrefix();
            string result = lcp.GetLongestCommonPrefix(input);
            Assert.That(result, Is.EqualTo("ab"));
        }
    }
}