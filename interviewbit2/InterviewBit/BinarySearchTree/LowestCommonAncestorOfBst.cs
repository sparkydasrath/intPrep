namespace BinarySearchTree
{
    public class LowestCommonAncestorOfBst
    {
        /*
         * https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/142/conclusion/1012/
            (tushar) https://www.youtube.com/watch?v=13m9ZCB8gjw
            (vivek) https://www.youtube.com/watch?v=F-_1sbnPbWQ [best explanation]

          */

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;

            if (root.Val == p.Val || root.Val == q.Val) return root;

            // in order traversal
            TreeNode left = LowestCommonAncestor(root.Left, p, q);
            TreeNode right = LowestCommonAncestor(root.Right, p, q);

            if (left != null && right != null) return root;
            /*  if left == null, return right
                otherwise return left
                basically return whatever is not null
             */
            return left ?? right;
        }
    }
}