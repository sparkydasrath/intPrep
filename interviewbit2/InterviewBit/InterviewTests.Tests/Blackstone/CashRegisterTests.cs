using InterviewTests.Blackstone;
using NUnit.Framework;

namespace InterviewTests.Tests.Blackstone
{
    [TestFixture]
    public class CashRegisterTests
    {
        [Test]
        public void ShouldReturnCorrectChange()
        {
            CashRegister cr = new CashRegister();
            string result = cr.GetChange("15.94;16.00");
            Assert.That(result, Is.EqualTo("NICKEL,PENNY"));
        }
    }
}