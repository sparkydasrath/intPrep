﻿using NUnit.Framework;

namespace Backtracking.Tests
{
    [TestFixture]
    public class WildcardMatchingTests
    {
        [TestCase("aa", "a", ExpectedResult = false)/*Explanation: "a" does not match the entire string "aa".*/]
        [TestCase("aa", "*", ExpectedResult = true)/*Explanation: '*' matches any sequence.*/]
        [TestCase("cb", "?a", ExpectedResult = false)/*Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'.*/]
        [TestCase("adceb", "*a*b", ExpectedResult = true)/*Explanation: The first '*' matches the empty sequence, while the second '*' matches the substring "dce".*/]
        [TestCase("acdcb", "a*c?b", ExpectedResult = false)]
        public bool IsMatch(string s, string p)
        {
            WildcardMatching wc = new WildcardMatching();
            bool result = wc.IsMatch(s, p);
            return result;
        }
    }
}