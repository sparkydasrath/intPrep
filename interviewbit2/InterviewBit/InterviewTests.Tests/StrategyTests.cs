using InterviewTests.centerbridge;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTests.Tests
{
    [TestFixture]
    public class NumberGenerationStrategyTests
    {
        [Test]
        public void ResultsShouldBeEmptyIfAccumulatorIsNotTheCorrectLength()
        {
            NumberGenerationStrategyMock mock = new NumberGenerationStrategyMock(new char[,] { }, null, null, null, new HashSet<string>());
            int result = mock.GetResultWhenBaseCaseIsInvalid();
            Assert.That(result, Is.Zero);
        }

        [Test]
        public void ResultsShouldNotBeEmptyIfAccumulatorIsNotTheCorrectLength()
        {
            NumberGenerationStrategyMock mock = new NumberGenerationStrategyMock(new char[,] { }, null, null, null, new HashSet<string>());
            int result = mock.GetResultWhenBaseCaseIsValid();
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void ShouldReturnTrueIfMoveIsNotValid()
        {
            NumberGenerationStrategyMock mock = new NumberGenerationStrategyMock(new char[,] { }, null, null, null, new HashSet<string>());
            bool result = mock.GetResultWhenMoveIsInvalid();
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnTrueIsNotAllowedToStartWith()
        {
            char[,] baseList = {
                {'*', 'a' },
                {'b', 'a' }
            };
            NumberGenerationStrategyMock mock = new NumberGenerationStrategyMock(baseList, null, new HashSet<char> { '*' }, null, new HashSet<string>());
            bool result = mock.GetResultWhenNonStartingCharIsEncountered();
            Assert.IsTrue(result);
        }
    }

    [TestFixture]
    public class StrategyTests
    {
        [Test]
        public void ShouldHaveNineDigitNumberInResultSet()
        {
            Centerbridge cb = new Centerbridge(GetSampleData(), new[] { '1', '0' }, new[] { '*', '#' });
            HashSet<string> results = cb.GeneratePhoneNumbers(ChessPiece.Rook, NumberLength.Nine);
            Assert.That(results.Count, Is.GreaterThan(0));
            Assert.That(results.First().Length, Is.EqualTo(11)); // taking two dashes into consideration
        }

        [Test]
        public void ShouldHaveNoResultsForBishop()
        {
            Centerbridge cb = new Centerbridge(GetSampleData(), new[] { '1', '0' }, new[] { '*', '#' });
            HashSet<string> results = cb.GeneratePhoneNumbers(ChessPiece.Bishop, NumberLength.Seven);
            Assert.That(results.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldHaveNoResultsForPawn()
        {
            Centerbridge cb = new Centerbridge(GetSampleData(), new[] { '1', '0' }, new[] { '*', '#' });
            HashSet<string> results = cb.GeneratePhoneNumbers(ChessPiece.Pawn, NumberLength.Seven);
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
        public void ShouldHaveResultsForKnight()
        {
            Centerbridge cb = new Centerbridge(GetSampleData(), new[] { '1', '0' }, new[] { '*', '#' });
            HashSet<string> results = cb.GeneratePhoneNumbers(ChessPiece.Knight, NumberLength.Seven);
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
        public void ShouldHaveSevenDigitNumberInResultSet()
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