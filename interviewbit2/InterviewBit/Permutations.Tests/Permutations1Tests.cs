using NUnit.Framework;
using System.Collections.Generic;

namespace Permutations.Tests
{
    [TestFixture]
    public class Permutations1Tests
    {
        [Test]
        public void ShouldReturnAllPermutations()
        {
            Permutations1 p1 = new Permutations1();
            int[] nums = new int[] { 1, 2, 3 };
            List<List<int>> result = p1.Permute(nums);
            Assert.That(result.Count, Is.EqualTo(6));
        }
    }
}