namespace BinarySearchTree
{
    public class LowestCommonAncestorOfBst
    {
        /*

            235. Lowest Common Ancestor of a Binary Search Tree     https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
            Easy

            Given a binary search tree (BST), find the lowest common ancestor (LCA) of two given nodes in the BST.

            According to the definition of LCA on Wikipedia:
            “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants
                (where we allow a node to be a descendant of itself).”

            Given binary search tree:  root = [6,2,8,0,4,7,9,null,null,3,5]

            Example 1:

            Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
            Output: 6
            Explanation: The LCA of nodes 2 and 8 is 6.

            Example 2:

            Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 4
            Output: 2
            Explanation: The LCA of nodes 2 and 4 is 2, since a node can be a descendant of itself according to the LCA definition.

            Note:

                All of the nodes' values will be unique.
                p and q are different and both values will exist in the BST.

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