using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BinarySearchTree.Tests
{
    [TestFixture()]
    public class LowestCommonAncestorOfBstTests
    {
        /*[TestCase(2, 8, ExpectedResult = 6)]*/

        [TestCase(2, 4, ExpectedResult = 2)]
        public int ShouldReturnLcaOfBst(int p, int q)
        {
            int[] nodes = { 6, 2, 8, 0, 4, 7, 9, 3, 5 };
            TreeNode root = BuildTree(nodes);
            LowestCommonAncestorOfBst lca = new LowestCommonAncestorOfBst();
            TreeNode result = lca.LowestCommonAncestor(root, new TreeNode(p), new TreeNode(q));
            return result.Val;
        }

        private TreeNode BuildTree(int[] nodes)
        {
            TreeNode root = null;
            BstOperations bst = new BstOperations();

            foreach (int node in nodes)
                root = bst.Insert(root, node);

            return root;
        }
    }
}