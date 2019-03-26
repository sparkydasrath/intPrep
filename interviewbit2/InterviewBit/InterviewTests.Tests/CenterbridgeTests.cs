using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace InterviewTests.Tests
{
    [TestFixture]
    public class CenterbridgeTests
    {
        [Test]
        public void ShouldHaveNoResultsForBishop()
        {
            Centerbridge cb = new Centerbridge(GetSampleData(), new[] { '1', '0' }, new[] { '*', '#' });
            HashSet<string> results = cb.GeneratePhoneNumbers(ChessPiece.Bishop, NumberLength.Seven);
            Assert.That(results.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldHaveResultsForKing()
        {
            Centerbridge cb = new Centerbridge(GetSampleData(), new[] { '1', '0' }, new[] { '*', '#' });
            HashSet<string> results = cb.GeneratePhoneNumbers(ChessPiece.King, NumberLength.Seven);
            Assert.That(results.Count, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldHaveResultsForQueen()
        {
            Centerbridge cb = new Centerbridge(GetSampleData(), new[] { '1', '0' }, new[] { '*', '#' });
            HashSet<string> results = cb.GeneratePhoneNumbers(ChessPiece.Queen, NumberLength.Seven);
            Assert.That(results.Count, Is.GreaterThan(0));
            Assert.That(results.Contains("314-5289"));
        }

        [Test]
        public void ShouldHaveSampleNumberInResultSet()
        {
            Centerbridge cb = new Centerbridge(GetSampleData(), new[] { '1', '0' }, new[] { '*', '#' });
            HashSet<string> results = cb.GeneratePhoneNumbers(ChessPiece.Rook, NumberLength.Seven);
            Assert.That(results.Contains("314-5289"));
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfInputCannotGenerateDesiredPhoneNumberLength()
        {
            Centerbridge cb = new Centerbridge(new char[2, 2], null, null);
            Assert.Throws<ArgumentException>(() => cb.GeneratePhoneNumbers(ChessPiece.Rook, NumberLength.Seven));
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfInputIsNull()
        {
            Centerbridge cb;
            Assert.Throws<ArgumentNullException>(() => cb = new Centerbridge(null, null, null));
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