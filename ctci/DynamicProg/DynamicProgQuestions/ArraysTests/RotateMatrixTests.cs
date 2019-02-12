using Arrays;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ArraysTests
{
    [TestFixture()]
    public class RotateMatrixTests
    {
        [Test]
        public void ShouldRotateMatrix()
        {
            RotateMatrix rm = new RotateMatrix();
            int[,] input = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            int[,] expected = { { 6, 3, 0 }, { 7, 4, 1 }, { 8, 5, 2 } };
            rm.Rotate(input);
        }
    }
}