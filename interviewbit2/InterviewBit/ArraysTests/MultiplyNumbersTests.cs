using System.Collections.Generic;
using Arrays;
using NUnit.Framework;

namespace ArraysTests
{
    [TestFixture]
    public class MultiplyNumbersTests
    {
        [Test]
        public void ShouldMultiplyNumbers1()
        {
            MultiplyNumbers mn = new MultiplyNumbers();
            List<int> num1 = new List<int> { 1, 2, 3 };
            List<int> num2 = new List<int> { 9, 7 };
            List<int> expected = new List<int> { 1, 2, 1, 4, 0, 1 };
            List<int> results = mn.MultipleTwoNumbers(num1, num2);
            CollectionAssert.AreEqual(expected, results);
        }
    }
}