using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class ZigZagConversionTests
    {
        [TestCase("PAYPALISHIRING", 2, ExpectedResult = "PYAIHRNAPLSIIG")]
        [TestCase("PAYPALISHIRING", 3, ExpectedResult = "PAHNAPLSIIGYIR")]
        [TestCase("PAYPALISHIRING", 4, ExpectedResult = "PINALSIGYAHRPI")]
        public string ShouldPrintInZigZagFormat(string s, int noOfRows)
        {
            ZigZagConversion zzc = new ZigZagConversion();
            // string c = zzc.ConvertMine(s, noOfRows);
            string c = zzc.ConvertLc(s, noOfRows);
            return c;
        }
    }
}