using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class IntegerToEnglishWordsTests
    {
        [TestCase(12, ExpectedResult = "Twelve")]
        /* [TestCase(23, ExpectedResult = "Twenty Three")]
         [TestCase(123, ExpectedResult = "One Hundred Twenty Three")]
         [TestCase(12345, ExpectedResult = "Twelve Thousand Three Hundred Forty Five")]
         [TestCase(1234567, ExpectedResult = "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven")]
         [TestCase(1234567891, ExpectedResult = "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One")]*/
        public string GetIntegerToEnglishWords(int num)
        {
            IntegerToEnglishWords iw = new IntegerToEnglishWords();
            string result = iw.NumberToWords(num);
            return result;
        }
    }
}