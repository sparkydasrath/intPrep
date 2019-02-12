using System.Collections.Generic;
using BinTreesQuestions;
using NUnit.Framework;

namespace BinTreesTests
{
    [TestFixture]
    public class TraveralTests
    {
        public TreeNode GetRoot()
        {
            TreeNode root = new TreeNode(1)
            {
                left = new TreeNode(10)
                {
                    left = new TreeNode(11)
                    {
                        left = new TreeNode(13)
                    },
                    right = new TreeNode(12)
                },

                right = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(4)
                }
            };

            return root;
        }

        public TreeNode GetSymmetric()
        {
            TreeNode root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(4)
                },

                right = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(3)
                }
            };

            return root;
        }

        [Test]
        public void ShouldBeSymmetric()
        {
            BinTrees bt = new BinTrees();
            TreeNode root = GetSymmetric();
            bool res = bt.IsSymmetric(root);
            Assert.That(res, Is.True);
        }

        [Test]
        public void ShouldPrintInPreorder()
        {
            BinTrees bt = new BinTrees();
            TreeNode root = GetRoot();
            IList<int> res = bt.PreorderTraversal(root);
            List<int> exp = new List<int> { 1, 10, 11, 13, 12, 2, 3, 4 };
            Assert.That(res, Is.EqualTo(exp));
        }

        [Test]
        public void ShouldPrintLevelOrder()
        {
            BinTrees bt = new BinTrees();
            TreeNode root = GetRoot();
            IList<IList<int>> res = bt.LevelOrder(root);
            List<int> exp = new List<int> { 1, 10, 11, 13, 12, 2, 3, 4 };
            bt.MaximumDepth(root, 1);

            int maxD = bt.MaxDepth(root);

            Assert.That(res, Is.EqualTo(exp));
        }
    }
}