using NUnit.Framework;
using System.Collections.Generic;

namespace Arrays.Tests
{
    [TestFixture]
    public class AddOneTests
    {
        [Test]
        public void ShouldAddOne1()
        {
            List<int> given1 = new List<int> { 1, 2, 9 };
            List<int> expected1 = new List<int> { 1, 3, 0 };
            AddOne a = new AddOne();
            List<int> results = a.AddOneToDecimalNumberInAList(given1);
            CollectionAssert.AreEqual(results, expected1);
        }

        [Test]
        public void ShouldAddOne2()
        {
            List<int> expected2 = new List<int> { 1, 0, 0 };
            List<int> given2 = new List<int> { 9, 9 };
            AddOne a = new AddOne();
            List<int> results = a.AddOneToDecimalNumberInAList(given2);
            CollectionAssert.AreEqual(results, expected2);
        }

        [TestCase("1011", "1001", ExpectedResult = "10100")]
        [TestCase("1011", "10", ExpectedResult = "1101")]
        public string ShouldAddTwoBinaryNumbers1(string s, string t)
        {
            AddOne a = new AddOne();
            string result = a.AddTwoBinaryNumbersInAList(s, t);
            return result;
        }
    }
}