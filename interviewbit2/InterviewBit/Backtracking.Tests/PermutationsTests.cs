using NUnit.Framework;
using System;

namespace Backtracking.Tests
{
    [TestFixture]
    public class PermutationsTests
    {
        [Test]
        public void ShouldPermuteWithRepeatedChars()
        {
            Permutations p = new Permutations();
            p.PermuteWithRepeatedChars("aabc");
            Console.ReadLine();
        }
    }
}