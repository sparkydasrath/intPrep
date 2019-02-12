using DynamicProgQuestions;
using NUnit.Framework;

namespace DynamicProgQuestionsTests
{
    [TestFixture]
    public class ConnectedComponentsTests
    {
        public int[,] GetMatrix()
        {
            int[,] m =
            {
                {0,0,0,1,1,0},
                {0,1,0,0,1,1},
                {1,1,0,0,0,0},
                {0,0,0,0,1,0},
            };

            return m;
        }

        [Test]
        public void ShouldReturnCorrectNumberOfIslands()
        {
            ConnectedComponents cc = new ConnectedComponents();
            int[,] matrix = GetMatrix();
            int count = cc.GetNumberOfIslands(matrix);
            Assert.That(count, Is.EqualTo(3));
        }
    }
}