using NUnit.Framework;
using System.Collections.Generic;

namespace Trees.Tests
{
    [TestFixture]
    public class PrintAllNodesFromRootToLeafTests
    {
        [Test]
        public void ShouldPrintAllNodesFromRootToLeaf()
        {
            PrintAllNodesFromRootToLeaf print = new PrintAllNodesFromRootToLeaf();
            TreeBuilder tb = new TreeBuilder();
            List<List<int>> results = new List<List<int>>();
            print.PrintRootToLeaf(tb.BuildBinaryTree(), results);
            CollectionAssert.AreEqual(results[0], new List<int> { 10, 11, 15 });
        }
    }
}