using Arrays;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ArraysTests
{
    [TestFixture]
    public class FindTheTownJudgeTests
    {
        [Test]
        public void ShouldFindJudge1()
        {
            int n = 3;
            int[][] trust = new int[2][];
            trust[0] = new[] { 1, 2 };
            trust[1] = new[] { 2, 3 };

            FindTheTownJudge j = new FindTheTownJudge();
            int index = j.FindJudge(n, trust);
            Assert.That(index, Is.EqualTo(-1));
        }

        [Test]
        public void ShouldFindJudge3()
        {
            int n = 4;
            int[][] trust = new int[5][];
            trust[0] = new[] { 1, 3 };
            trust[1] = new[] { 1, 4 };
            trust[2] = new[] { 2, 3 };
            trust[3] = new[] { 2, 4 };
            trust[4] = new[] { 4, 3 };

            FindTheTownJudge j = new FindTheTownJudge();
            int index = j.FindJudge(n, trust);
            Assert.That(index, Is.EqualTo(3));
        }
    }
}