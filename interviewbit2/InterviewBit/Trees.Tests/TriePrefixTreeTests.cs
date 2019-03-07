using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Trees.Tests
{
    [TestFixture]
    public class TriePrefixTreeTests
    {
        [Test]
        public void LeetCodeTestCase1()
        {
            /*

            Input: ["Trie","insert","search","search","startsWith","insert","search"]
            [          [],["apple"],["apple"],["app"],["app"],["app"],["app"]]

            Output: [null,null,true,false,true,null,false]
            Expected: [null,null,true,false,true,null,true]

             */

            TriePrefixTree pt = new TriePrefixTree(26);
            pt.Insert("apple");

            bool r1 = pt.Search("apple");
            Assert.That(r1, Is.True);

            bool r2 = pt.Search("app");
            Assert.That(r2, Is.False);

            bool r3 = pt.StartsWith("app");
            Assert.That(r3, Is.True);

            pt.Insert("app");
            bool r4 = pt.Search("app");
            Assert.That(r4, Is.True);
        }

        [Test]
        public void ShouldCreateTriePrefixTree()
        {
            TriePrefixTree pt = new TriePrefixTree(26);
            Assert.That(pt, Is.Not.Null);
        }

        [Test]
        public void ShouldInsertIntoTriePrefixTree()
        {
            TriePrefixTree pt = new TriePrefixTree(26);
            pt.Insert("hello");
            Assert.That(pt, Is.Not.Null);
        }

        [Test]
        public void ShouldNotInsertIfWordAlreadyExists()
        {
            TriePrefixTree pt = new TriePrefixTree(26);
            pt.Insert("apl");
            pt.Insert("ap");
            Assert.That(pt, Is.Not.Null);
        }

        [Test]
        public void ShouldReturnFalseIfTheWordDoesNotExists()
        {
            TriePrefixTree pt = new TriePrefixTree(26);
            pt.Insert("apple");

            bool r1 = pt.Search("app");
            Assert.That(r1, Is.False);
        }

        [Test]
        public void ShouldReturnTrueIfInsertAndSearchIsDone()
        {
            TriePrefixTree pt = new TriePrefixTree(26);
            pt.Insert("app");

            bool r1 = pt.Search("app");
            Assert.That(r1, Is.True);
        }

        [Test]
        public void ShouldReturnTrueIfTheWordExists()
        {
            TriePrefixTree pt = new TriePrefixTree(26);
            pt.Insert("apple");

            bool r1 = pt.Search("apple");
            Assert.That(r1, Is.True);
        }

        [Test]
        public void ShouldReturnTrueIfTheWordStartsWith()
        {
            TriePrefixTree pt = new TriePrefixTree(26);
            pt.Insert("apple");

            bool r1 = pt.StartsWith("app");
            Assert.That(r1, Is.True);

            bool r2 = pt.StartsWith("ac");
            Assert.That(r2, Is.False);
        }
    }
}