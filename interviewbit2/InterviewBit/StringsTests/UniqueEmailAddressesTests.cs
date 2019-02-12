using NUnit.Framework;

namespace Strings.Tests
{
    [TestFixture]
    public class UniqueEmailAddressesTests
    {
        [Test]
        public void ShouldReturnCorrectCount()
        {
            UniqueEmailAddresses uea = new UniqueEmailAddresses();
            int count = uea.NumUniqueEmails(new[]
            {
                "test.email+alex@leetcode.com",
                "test.e.mail+bob.cathy@leetcode.com",
                "testemail+david@lee.tcode.com"
            });

            Assert.That(count, Is.EqualTo(2));
        }
    }
}