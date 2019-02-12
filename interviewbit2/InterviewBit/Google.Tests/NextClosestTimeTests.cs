using NUnit.Framework;

namespace Google.Tests
{
    [TestFixture]
    public class NextClosestTimeTests
    {
        [TestCase("19:34", ExpectedResult = "19:39")]
        [TestCase("23:59", ExpectedResult = "22:22")]
        public string ShouldGetNextTime(string time)
        {
            NextClosestTime nt = new NextClosestTime();
            string t = nt.NextClosestTimeImplementation(time);
            return t;
        }
    }
}