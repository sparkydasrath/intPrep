using NUnit.Framework;
using System.Collections.Generic;

namespace Google.Tests
{
    [TestFixture]
    public class WordLadderTests
    {
        [TestCase("hit", "cog", new[] { "hot", "dot", "dog", "lot", "log", "cog" }, ExpectedResult = 5)]
        [TestCase("most", "miss", new[] { "most", "mist", "miss", "lost", "fist", "fish" }, ExpectedResult = 4)]
        [TestCase("leet", "code", new[] { "lest", "leet", "lose", "code", "lode", "robe", "lost" }, ExpectedResult = 6)]
        [TestCase("a", "c", new[] { "a", "b", "c" }, ExpectedResult = 2)]
        public int ShouldGetWordLadder(string begin, string end, IList<string> words)
        {
            WordLadder w = new WordLadder();
            int results = w.LadderLength(begin, end, words);
            return results;
        }
    }
}