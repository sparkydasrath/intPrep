using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TwoPointers.Tests
{
    [TestFixture]
    public class FruitIntoBasketsTests
    {
        [TestCase(new int[] { }, ExpectedResult = 0)]
        [TestCase(new[] { 1 }, ExpectedResult = 1)]
        [TestCase(new[] { 1, 2 }, ExpectedResult = 2)]
        [TestCase(new[] { 1, 2, 1 }, ExpectedResult = 3)]
        [TestCase(new[] { 1, 2, 3, 2, 2 }, ExpectedResult = 4)]
        [TestCase(new[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 }, ExpectedResult = 5)]

        // [TestCase(new[] { 1, 0, 1, 4, 1, 4, 1, 2, 3 }, ExpectedResult = 5)]
        public int GetLargestSubarray(int[] arr)
        {
            FruitIntoBaskets fb = new FruitIntoBaskets();
            int result = fb.TotalFruitMine(arr);
            return result;
        }

        [TestCase(new int[] { }, ExpectedResult = 0)]
        [TestCase(new[] { 1 }, ExpectedResult = 1)]
        [TestCase(new[] { 1, 2 }, ExpectedResult = 2)]
        [TestCase(new[] { 1, 2, 1 }, ExpectedResult = 3)]
        [TestCase(new[] { 1, 2, 3, 2, 2 }, ExpectedResult = 4)]
        [TestCase(new[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 }, ExpectedResult = 5)]
        [TestCase(new[] { 1, 0, 1, 4, 1, 4, 1, 2, 3 }, ExpectedResult = 5)]
        public int GetLargestSubarray2(int[] arr)
        {
            List<int> l1 = new List<int> { 1, 2, 3 };
            List<int> l2 = new List<int> { 1, 3, 2 };

            HashSet<List<int>> s = new HashSet<List<int>>
            {
                l1,
                l2
            };

            List<int> x = l1.Union(l2).ToList();
            List<int> y = l1.Intersect(l2).ToList();

            FruitIntoBaskets fb = new FruitIntoBaskets();
            int result = fb.TotalFruit(arr);
            return result;
        }
    }
}