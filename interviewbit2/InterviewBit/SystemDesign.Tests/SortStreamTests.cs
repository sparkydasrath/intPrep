using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SystemDesign.Tests
{
    [TestFixture]
    public class SortStreamTests
    {
        [Test]
        public void ShouldCreateOutputStreamUsingSortedFiles()
        {
            SortStream st = new SortStream();
            List<string> outStream = st.OutputStreamGenerateStream();
            Assert.That(outStream.First(), Is.EqualTo("AAPL-5"));
            Assert.That(outStream.Last(), Is.EqualTo("TSLA-12"));
        }

        [Test]
        public void ShouldCreateTextFilesWithSymbolNames()
        {
            SortStream st = new SortStream();
            st.CleanDirectory();
            for (int i = 0; i < st.EntityCount; i++)
            {
                Entity e1 = st.InputStreamGetCompressedEntity();
                st.AppendTickerToFile(e1);
            }
        }
    }
}