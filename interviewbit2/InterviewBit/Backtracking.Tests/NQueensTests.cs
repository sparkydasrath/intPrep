using NUnit.Framework;

namespace Backtracking.Tests
{
    [TestFixture]
    public class NQueensTests
    {
        [Test]
        public void ShouldGetValidNQueensSolution()
        {
            NQueens nq = new NQueens();
            System.Collections.Generic.List<System.Collections.Generic.List<string>> results = nq.SolveNQueens(4);
            Assert.That(results.Count, Is.Not.Zero);
        }
    }
}