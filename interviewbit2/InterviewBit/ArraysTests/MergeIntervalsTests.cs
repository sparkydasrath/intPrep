using Arrays;
using NUnit.Framework;
using System.Collections.Generic;

namespace ArraysTests
{
    [TestFixture]
    public class MergeIntervalsTests
    {
        [Test]
        public void ShouldReturnMergedIntervals1()
        {
            MergeIntervals mi = new MergeIntervals();
            List<Interval> input = new List<Interval>
            {
                new Interval(1,4),
                new Interval(4,5)
            };
            List<Interval> results = mi.Merge(input);
            Assert.That(results.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldReturnMergedIntervals2()
        {
            MergeIntervals mi = new MergeIntervals();
            List<Interval> input = new List<Interval>
            {
                new Interval(1,3),
                new Interval(2,6),
                new Interval(8,10),
                new Interval(15,18),
            };
            List<Interval> results = mi.Merge(input);
            Assert.That(results.Count, Is.EqualTo(3));
        }

        [Test]
        public void ShouldReturnMergedIntervals3()
        {
            MergeIntervals mi = new MergeIntervals();
            List<Interval> input = new List<Interval>
            {
                new Interval(1,3),
            };
            List<Interval> results = mi.Merge(input);
            Assert.That(results.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldReturnMergedIntervals4()
        {
            MergeIntervals mi = new MergeIntervals();
            List<Interval> input = new List<Interval>
            {
                new Interval(1,4),
                new Interval(0,4),
            };
            List<Interval> results = mi.Merge(input);
            Assert.That(results.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldReturnMergedIntervals5()
        {
            MergeIntervals mi = new MergeIntervals();
            List<Interval> input = new List<Interval>
            {
                new Interval(1,4),
                new Interval(2,3),
            };
            List<Interval> results = mi.Merge(input);
            Assert.That(results.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldReturnMergedIntervals6()
        {
            MergeIntervals mi = new MergeIntervals();
            List<Interval> input = new List<Interval>
            {
                new Interval(2,3),
                new Interval(4,5),
                new Interval(6,7),
                new Interval(8,9),
                new Interval(1,10),
            };
            List<Interval> results = mi.Merge(input);
            Assert.That(results.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldReturnMergedIntervalsWithSimplifiedSort1()
        {
            MergeIntervalsBetter mi = new MergeIntervalsBetter();
            List<Interval> input = new List<Interval>
            {
                new Interval(2,3),
                new Interval(4,5),
                new Interval(6,7),
                new Interval(8,9),
                new Interval(1,10),
            };
            List<Interval> results = mi.Merge(input);
            Assert.That(results.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldReturnMergedIntervalsWithSimplifiedSort2()
        {
            MergeIntervalsBetter mi = new MergeIntervalsBetter();
            List<Interval> input = new List<Interval>
            {
                new Interval(2,3),
            };
            List<Interval> results = mi.Merge(input);
            Assert.That(results.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldReturnMergedIntervalsWithSimplifiedSort3()
        {
            MergeIntervalsBetter mi = new MergeIntervalsBetter();
            List<Interval> input = new List<Interval>
            {
                new Interval(1,3),
                new Interval(2,6),
                new Interval(8,10),
                new Interval(15,18),
            };
            List<Interval> results = mi.Merge(input);
            Assert.That(results.Count, Is.EqualTo(3));
        }
    }
}