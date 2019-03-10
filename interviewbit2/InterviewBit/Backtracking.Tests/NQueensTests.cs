using NUnit.Framework;
using System.Collections.Generic;

namespace Backtracking.Tests
{
    [TestFixture]
    public class NQueensTests
    {
        [Test]
        public void ShouldGetValidNQueensSolution()
        {
            NQueens nq = new NQueens();
            IList<IList<string>> results = nq.SolveNQueens(4);
            Assert.That(results.Count, Is.Not.Zero);
        }
    }
}