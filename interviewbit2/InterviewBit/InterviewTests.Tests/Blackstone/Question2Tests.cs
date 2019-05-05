using InterviewTests.Blackstone;
using NUnit.Framework;

namespace InterviewTests.Tests.Blackstone
{
    [TestFixture]
    public class Question2Tests
    {
        [TestCase("1,2,3,4,5;2", ExpectedResult = "2,1,4,3,5")]
        [TestCase("1,2,3,4,5;3", ExpectedResult = "3,2,1,4,5")]
        [TestCase("1,2,3,4,5;5", ExpectedResult = "5,4,3,2,1")]
        [TestCase("1,2,3,4,5;4", ExpectedResult = "4,3,2,1,5")]
        [TestCase("1,2,3,4,5,6;3", ExpectedResult = "3,2,1,6,5,4")]
        [TestCase("1,2;3", ExpectedResult = "1,2")]
        public string ShouldReturnReversedList(string numsAndk)
        {
            Question2 r = new Question2();
            string results = r.ReverseKth(numsAndk);
            return results;
        }
    }
}