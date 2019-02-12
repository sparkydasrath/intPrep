namespace TreesAndGraphs
{
    public class CheckSubtree
    {
        /*
         * 4.10 Check Subtree: Tl and T2 are two very large binary trees, with Tl much bigger than T2. Create an
           algorithm to determine if T2 is a subtree of Tl.
           A tree T2 is a subtree ofTi if there exists a node n in Ti such that the subtree of n is identical to T2.
           That is, if you cut off the tree at node n, the two trees would be identical.
           Hints: #4, #11, #18, #31, #37
         */

        public bool AreIdenticalTrees(TreeNode n1, TreeNode n2)
        {
            if (n1 == null && n2 == null) return true;
            if (n1 != null && n2 != null)
            {
                if (n1.Val == n2.Val && AreIdenticalTrees(n1.Left, n2.Left) &&
                    AreIdenticalTrees(n1.Right, n2.Right)) return true;
            }

            return false;
        }

        public bool IsSubtree(TreeNode n1, TreeNode n2)
        {
            // check if n2 is a subtree of n1

            if (n2 == null) return true; // a null tree is always a subtree of any tree
            if (n1 == null) return false;

            // identical trees are subtrees of themselves
            if (AreIdenticalTrees(n1, n2)) return true;

            // otherwise, check if n2 is a subtree of n1's left branch OR it's right branch
            return IsSubtree(n1.Left, n2) || IsSubtree(n1.Right, n2);
        }
    }
}