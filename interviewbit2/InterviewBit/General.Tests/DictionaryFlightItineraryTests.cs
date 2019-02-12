using NUnit.Framework;
using System.Collections.Generic;

namespace General.Tests
{
    [TestFixture]
    public class DictionaryFlightItineraryTests
    {
        [Test]
        public void ShouldReturnValidItinerary()
        {
            DictionaryFlightItinerary dfi = new DictionaryFlightItinerary();
            List<string> result = dfi.FlightItineraryUsingDictionary(dfi.OrgDestPairs);
            List<string> expected = new List<string> { "yul", "ord", "sfo", "hnl", "akl" };
            CollectionAssert.AreEqual(result, expected);
        }
    }
}