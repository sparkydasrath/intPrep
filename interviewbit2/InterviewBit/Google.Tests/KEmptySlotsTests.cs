using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Google.Tests
{
    [TestFixture]
    public class KEmptySlotsTests
    {
        /*        [TestCase(new int[] { 1, 3, 2 }, 1, ExpectedResult = 2)]
                [TestCase(new int[] { 1, 2, 3 }, 1, ExpectedResult = -1)]*/

        [TestCase(new int[] { 6, 5, 8, 9, 7, 1, 10, 2, 3, 4 }, 2, ExpectedResult = 8)]
        public int ShouldReturnCorrectDay(int[] flowers, int k)
        {
            KEmptySlots slots = new KEmptySlots();
            int day = slots.KEmptySlotsMinev2(flowers, k);
            return day;
        }
    }
}