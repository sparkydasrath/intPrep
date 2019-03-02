using NUnit.Framework;
using System.Collections.Generic;

namespace Backtracking.Tests
{
    [TestFixture]
    public class RestoreIpAddressesTests
    {
        [Test]
        public void ShouldGetValidIpAddressed1()
        {
            RestoreIpAddresses ip = new RestoreIpAddresses();
            List<string> results = ip.RestoreIpAddressesImpl("25525511135");
            Assert.That(results.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldGetValidIpAddressed2()
        {
            RestoreIpAddresses ip = new RestoreIpAddresses();
            List<string> results = ip.RestoreIpAddressesImpl("010010");
            Assert.That(results.Count, Is.EqualTo(2));
        }
    }
}