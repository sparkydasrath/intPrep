using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace InterviewTests.Tests
{
    [TestFixture]
    public class CenterbridgeTests
    {
        [Test]
        public void ShouldHaveSampleNumberInResultSet()
        {
            Centerbridge cb = new Centerbridge(GetSampleData(), new[] { '*', '#' }, string.Empty, 7);
            List<string> results = cb.GeneratePhoneNumbers();
            Assert.That(results.Contains("3145289"));
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfInputCannotGenerateDesiredPhoneNumberLength()
        {
            Centerbridge cb;
            Assert.Throws<ArgumentException>(() => cb = new Centerbridge(new char[2, 2], null, string.Empty, 7));
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfInputIsNull()
        {
            Centerbridge cb;
            Assert.Throws<ArgumentNullException>(() => cb = new Centerbridge(null, null, string.Empty, 7));
        }

        private char[,] GetSampleData()
        {
            char[,] data =
            {
                { '1','2','3'},
                { '4','5','6'},
                { '7','8','9'},
                { '*','0','#'},
            };

            return data;
        }
    }
}