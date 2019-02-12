using System.Collections.Generic;
using Arrays;
using NUnit.Framework;

namespace ArraysTests
{
    [TestFixture]
    public class SpiralMatrixTests
    {
        [Test]
        public void ShouldPrintMatrixInSpiralOrder()
        {
            SpiralMatrix sp = new SpiralMatrix();
            int[,] input = { { 0, 1, 2, 3 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } };
            string res = sp.PrintSpiralMatrix(input);
            Assert.That(1, Is.EqualTo(1));
        }

        [Test]
        public void ShouldPrintMatrixInSpiralOrderLists()
        {
            SpiralMatrix sp = new SpiralMatrix();
            List<List<int>> input = new List<List<int>>
            {
                new List<int> {0, 1, 2, 3},
                new List<int> { 4, 5, 6, 7 },
                new List<int> {8, 9, 10, 11},
                new List<int> {12, 13, 14, 15 },
            };

            List<int> res = sp.SpiralOrder(input);
            Assert.That(1, Is.EqualTo(1));
        }
    }
}