using NUnit.Framework;
using System.Collections.Generic;

namespace Trees.Tests
{
    [TestFixture]
    public class PathSumTests
    {
        public TreeNode BuildTree1()
        {
            TreeNode root = new TreeNode(5);

            TreeNode left = new TreeNode(4)
            {
                Left = new TreeNode(11)
                {
                    Left = new TreeNode(7),
                    Right = new TreeNode(2)
                },
            };

            TreeNode right = new TreeNode(8)
            {
                Left = new TreeNode(13),
                Right = new TreeNode(4)
                {
                    Right = new TreeNode(1)
                }
            };

            root.Left = left;
            root.Right = null;
            return root;
        }

        public TreeNode BuildTree2()
        {
            TreeNode root = new TreeNode(5)
            {
                Left = new TreeNode(4),
                Right = new TreeNode(8)
            };

            root.Left.Left = new TreeNode(11)
            {
                Left = new TreeNode(7),
                Right = new TreeNode(2)
            };

            root.Right.Left = new TreeNode(13);
            root.Right.Right = new TreeNode(4)
            {
                Left = new TreeNode(5),
                Right = new TreeNode(1)
            };

            return root;
        }

        [Test]
        public void ShouldReturnListOfAllPathsFormingSum()
        {
            TreeNode root = BuildTree2();
            PathSum2 ps = new PathSum2();
            int sum = 22;
            List<List<int>> resultDfs = ps.PathSumDfs(root, sum);
            List<List<int>> resultIterative = ps.PathSumIterative(root, sum);
            Assert.That(resultDfs.Count, Is.EqualTo(2));
            CollectionAssert.AreEqual(resultDfs[0], new List<int> { 5, 4, 11, 2 });

            Assert.That(resultIterative.Count, Is.EqualTo(2));
            CollectionAssert.AreEqual(resultIterative[0], new List<int> { 5, 4, 11, 2 });
        }

        [Test]
        public void ShouldReturnTrueIfPathExistsForSum()
        {
            TreeNode root = BuildTree1();
            PathSum ps = new PathSum();
            int sum = 22;
            List<int> results = new List<int>();
            bool result = ps.HasPathSum(root, sum, results);
            Assert.IsTrue(result);
            CollectionAssert.AreEqual(results, new List<int> { 2, 11, 4, 5 });
        }
    }
}