using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class InOrderSuccessorInBstTests
    {
        [Test]
        public void VerifyInOrderSuccessorNotPresent()
        {
            TreeNode root = BuildFailTree();
            TreeNode searchNode = new TreeNode(6);
            InOrderSuccessorInBst inOrderSuccessorInBst = new InOrderSuccessorInBst();
            TreeNode result = inOrderSuccessorInBst.InOderSuccessor(root, searchNode);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void VerifyInOrderSuccessorPresent()
        {
            TreeNode root = BuildPassTree2();
            TreeNode searchNode = new TreeNode(3);
            InOrderSuccessorInBst inOrderSuccessorInBst = new InOrderSuccessorInBst();
            TreeNode result = inOrderSuccessorInBst.InOderSuccessor(root, searchNode);
            Assert.That(result, Is.Null);
        }

        private TreeNode BuildFailTree()
        {
            TreeNode root = new TreeNode(5)
            {
                Left = new TreeNode(3),
                Right = new TreeNode(6)
            };

            root.Left.Left = new TreeNode(2)
            {
                Left = new TreeNode(1)
            };

            root.Left.Right = new TreeNode(4);
            return root;
        }

        private TreeNode BuildPassTree()
        {
            TreeNode root = new TreeNode(2)
            {
                Left = new TreeNode(1),
                Right = new TreeNode(3)
            };
            return root;
        }

        private TreeNode BuildPassTree2()
        {
            TreeNode root = new TreeNode(2)
            {
                Left = null,
                Right = new TreeNode(3)
            };
            return root;
        }
    }
}