using InterviewTests.Pivotal;
using NUnit.Framework;

namespace InterviewTests.Tests.Pivotal
{
    [TestFixture]
    public class MySetTests
    {
        [Test(Description = "Should be able to Add a key to the set")]
        public void ShouldAddItemToSet()
        {
            MySet<int> mySet = new MySet<int>();
            mySet.Add(2);
            Assert.That(mySet.Contains(2));
        }

        [Test(Description = "Should be able to remove a key if present")]
        public void ShouldRemoveItemFromSetIfPresent()
        {
            MySet<int> mySet = new MySet<int>();
            mySet.Add(3);
            Assert.IsTrue(mySet.Contains(3));
            mySet.Remove(3);
            Assert.IsFalse(mySet.Contains(3));
        }

        [Test(Description = "Check if the set contains the given key")]
        public void ShouldReturnTrueIfSetContainsKey()
        {
            MySet<int> mySet = new MySet<int>();
            bool result = mySet.Contains(1);
            Assert.IsFalse(result);
        }

        [Test(Description = "Verify that you can create a default instance of MySet")]
        public void VerifyThatYouCanCreateANewInstanceOfMySet()
        {
            MySet<int> mySet = new MySet<int>();
            Assert.That(mySet, Is.Not.Null);
        }
    }
}