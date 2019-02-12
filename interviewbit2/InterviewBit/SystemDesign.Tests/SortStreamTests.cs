using NUnit.Framework;

namespace SystemDesign.Tests
{
    [TestFixture]
    public class SortStreamTests
    {
        [Test]
        public void ShouldCreateTextFilesWithSymbolNames()
        {
            SortStream st = new SortStream();
            st.CleanDirectory();
            for (int i = 0; i < st.EntityCount; i++)
            {
                Entity e1 = st.GetCompressedEntityFromStream();
                st.AppendTickerToFile(e1);
            }
        }
    }
}