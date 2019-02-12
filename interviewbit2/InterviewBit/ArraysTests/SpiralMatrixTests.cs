using Arrays;
using NUnit.Framework;
using System.Collections.Generic;
using Utils;

namespace ArraysTests
{
    [TestFixture]
    public class SpiralMatrixTests
    {
        [Test]
        public void ShouldPrintTwoDimensionalArraryInSpiralOrder()
        {
            int[,] testArray = MatrixUtils.BuildSquareMatrix(3);
            List<int> expected = new List<int> { 0, 1, 2, 5, 8, 7, 6, 3, 4 };

            List<int> results = new SpiralMatrix().PrintInSpiralOrder(testArray);
            CollectionAssert.AreEqual(expected, results);
        }
    }
}