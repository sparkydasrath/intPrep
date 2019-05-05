using InterviewTests.Blackstone;
using NUnit.Framework;

namespace InterviewTests.Tests.Blackstone
{
    [TestFixture]
    public class ReverseKthNumbersTests
    {
        [TestCase("1,2,3,4,5;2", ExpectedResult = "2,1,4,3,5")]
        [TestCase("1,2,3,4,5;3", ExpectedResult = "3,2,1,4,5")]
        [TestCase("1,2,3,4,5;5", ExpectedResult = "5,4,3,2,1")]
        [TestCase("1,2,3,4,5;4", ExpectedResult = "4,3,2,1,5")]
        public string SholdReturnReversedList(string numsAndk)
        {
            ReverseKthNumbers r = new ReverseKthNumbers();
            string results = r.ReverseKth(numsAndk);
            return results;
        }

        // !in case I need to deal with ints
        /*[TestCase("1,2,3,4,5;2", ExpectedResult = new[] { 2, 1, 4, 3, 5 })]
        public int[] SholdReturnReversedListxx(string numsAndk)
        {
            ReverseKthNumbers r = new ReverseKthNumbers();
            int[] results = r.ReverseKth(numsAndk);
            return results;
        }*/
    }
}