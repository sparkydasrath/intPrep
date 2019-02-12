using System;
using arrays01;
using NUnit.Framework;

namespace Arrays01Tests
{
    [TestFixture]
    public class PivotIndexTests
    {
        [Test]
        public void ShouldReturnCorrectPivot()
        {
            PivotIndex pi = new PivotIndex();
            int[] nums = { 1, 7, 3, 6, 5, 6 };
            int pivot = pi.GetPivotIndex(nums);
            Assert.That(pivot, Is.EqualTo(3));
        }

        public void ShouldReturnCorrectPivotBetter()
        {
            PivotIndex pi = new PivotIndex();
            int[] nums = { 1, 7, 3, 6, 5, 6 };
            int pivot = pi.GetPivotIndexBetter(nums);
            Assert.That(pivot, Is.EqualTo(3));
        }

        [Test]
        public void ShouldReturnCorrectPivotWithLargerRange()
        {
            PivotIndex pi = new PivotIndex();
            int[] nums = BuildArray();
            int pivot = pi.GetPivotIndex(nums);
            //Assert.That(pivot, Is.EqualTo(3));
        }

        private int[] BuildArray()
        {
            int[] nums = new int[10001];
            Random r = new Random();
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = r.Next(-1000, 1000);
            }

            return nums;
        }
    }
}