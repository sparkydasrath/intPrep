using DynamicProgQuestions;
using NUnit.Framework;

namespace DynamicProgQuestionsTests
{
    [TestFixture]
    public class MaxSizeSquareSubMatrixTests
    {
        public int[,] GetMatrix()
        {
            int[,] m =
            {
                {1,1,1,1,0},
                {0,1,1,1,1},
                {0,1,1,1,1},
                {1,0,1,1,1},
                {0,1,1,1,0},
            };

            return m;
        }

        [Test]
        public void ShouldReturnLargestSquareMatrix()
        {
            MaxSizeSquareSubMatrix ms = new MaxSizeSquareSubMatrix();
            int[,] matrix = GetMatrix();
            int result = ms.LargestSquareMatrix(matrix);
            Assert.That(result, Is.EqualTo(3));
        }
    }
}