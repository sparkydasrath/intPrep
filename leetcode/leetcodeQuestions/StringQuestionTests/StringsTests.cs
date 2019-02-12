using NUnit.Framework;
using StringQuestions;

namespace StringQuestionTests
{
    [TestFixture]
    public class StringsTests
    {
        [Test]
        public void ShouldReturnCorrectIndexForRepeatingSubstrings1()
        {
            StringManipulation sp = new StringManipulation();
            string a = "mississippi";
            string b = "issi";
            int res1 = sp.StrStr(a, b);
            int res2 = sp.GetIndextOfSubstring(a, b);
            // Assert.That(res1, Is.EqualTo(1));
            Assert.That(res2, Is.EqualTo(1));
        }

        [Test]
        public void ShouldReturnCorrectIndexForRepeatingSubstrings2()
        {
            StringManipulation sp = new StringManipulation();
            string a = "mississippi";
            string b = "issip";
            int result = sp.StrStr(a, b);
            int result2 = sp.GetIndextOfSubstring(a, b);
            // Assert.That(result, Is.EqualTo(4));
            Assert.That(result2, Is.EqualTo(4));
        }

        [Test]
        public void ShouldReturnCorrectIndexForRepeatingSubstrings3()
        {
            StringManipulation sp = new StringManipulation();
            string a = "mississippi";
            string b = "pi";
            int result = sp.StrStr(a, b);
            int result2 = sp.GetIndextOfSubstring(a, b);
            // Assert.That(result, Is.EqualTo(9));
            Assert.That(result2, Is.EqualTo(9));
        }

        [Test]
        public void ShouldReturnIndexIfHaystackAndNeedleAreEqual()
        {
            StringManipulation sp = new StringManipulation();
            string a = "a";
            string b = "a";
            int result = sp.StrStr(a, b);
            int result2 = sp.GetIndextOfSubstring(a, b);
            // Assert.That(result, Is.EqualTo(0));
            Assert.That(result2, Is.EqualTo(0));
        }

        [Test]
        public void ShouldReturnIndexOfSubstring()
        {
            StringManipulation sp = new StringManipulation();
            string a = "hello";
            string b = "ll";
            int result = sp.StrStr(a, b);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void ShouldReturnNegativeOneForNoSubstring()
        {
            StringManipulation sp = new StringManipulation();
            string a = "aaaaa";
            string b = "baa";
            int result = sp.StrStr(a, b);
            int result2 = sp.GetIndextOfSubstring(a, b);
            // Assert.That(result, Is.EqualTo(-1));
            Assert.That(result2, Is.EqualTo(-1));
        }

        [Test]
        public void ShouldReturnNegativeOneIfNeedleIsEmptyString()
        {
            StringManipulation sp = new StringManipulation();
            string a = "a";
            string b = string.Empty;
            int result = sp.StrStr(a, b);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}