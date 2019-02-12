using NUnit.Framework;

namespace TwoPointers.Tests
{
    [TestFixture]
    public class BoatsToSavePeopleTests
    {
        [TestCase(new[] { 1, 2 }, 3, ExpectedResult = 1)]
        [TestCase(new[] { 3, 2, 2, 1 }, 3,
        ExpectedResult = 3)]
        [TestCase(new[] { 3, 5, 3, 4 }, 5, ExpectedResult = 4)]
        public int GetBoatCount(int[] people, int limit)
        {
            BoatsToSavePeople boats = new BoatsToSavePeople();
            int count = boats.NumRescueBoats(people, limit);
            return count;
        }
    }
}