using InterviewTests.Blackstone;
using NUnit.Framework;

namespace InterviewTests.Tests.Blackstone
{
    [TestFixture]
    public class Question1Tests
    {
        [Test]
        public void ShouldReturnCorrectList()
        {
            Question1 q1 = new Question1();
            var results = q1.FindUncommonElements("10 4 5 7 9", "11 4 7 6 9 18");
            Assert.That(results, Is.EqualTo("11 6 18"));
        }
    }
}