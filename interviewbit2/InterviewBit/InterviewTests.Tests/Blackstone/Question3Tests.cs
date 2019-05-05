using InterviewTests.Blackstone;
using NUnit.Framework;

namespace InterviewTests.Tests.Blackstone
{
    [TestFixture]
    public class Question3Tests
    {
        [TestCase("15.94;16.00", ExpectedResult = "NICKEL,PENNY")]
        [TestCase("17;16", ExpectedResult = "ERROR")]
        [TestCase("35;35", ExpectedResult = "ZERO")]
        [TestCase("45;50", ExpectedResult = "FIVE")]
        public string ShouldReturnCorrectChange(string input)
        {
            Question3 cr = new Question3();
            string result = cr.GetChange(input);
            return result;
        }
    }
}