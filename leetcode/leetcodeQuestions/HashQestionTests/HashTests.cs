using HashQuestions;
using NUnit.Framework;

namespace HashQestionsTests
{
    [TestFixture]
    public class HashTests
    {
        [Test]
        public void ShouldFindFirstUniqueChar()
        {
            HashOps ho = new HashOps();
            string test = "loveleetcode";
            int exp = 3;
            int res = ho.FirstUniqChar(test);
            Assert.That(res, Is.EqualTo(exp));
        }

        [Test]
        public void ShouldReturnCorrectIndexOfSingleNumber()
        {
            HashOps ho = new HashOps();
            int[] test = { 4, 1, 2, 1, 2 };
            int res = ho.SingleNumber(test);
            Assert.That(res, Is.EqualTo(4));
        }

        [Test]
        public void ShouldReturnIntersect()
        {
            HashOps ho = new HashOps();
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] exp = { 2, 2 };
            int[] res = ho.Intersect(nums1, nums2);
            Assert.That(res, Is.EqualTo(exp));
        }

        [Test]
        public void ShouldSumTwoNumbers()
        {
            HashOps ho = new HashOps();
            int[] test = { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 };
            int[] res = ho.TwoSum(test, 542);
            int[] exp = { 1, 2 };
            Assert.That(res, Is.EqualTo(exp));
        }
    }
}