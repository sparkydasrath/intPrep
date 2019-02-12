namespace Trees
{
    public class ConstructTrees
    {
        public TreeNode FromPreOrderAndInOrder(int[] preorder, int[] inorder)
        {
            /*
             * https://leetcode.com/explore/learn/card/data-structure-tree/133/conclusion/943/
             *
             * Given preorder and inorder traversal of a tree, construct the binary tree.

                Note:
                You may assume that duplicates do not exist in the tree.

                For example, given

                preorder = [3,9,20,15,7]
                inorder = [9,3,15,20,7]

                Return the following binary tree:

                    3
                   / \
                  9  20
                    /  \
                   15   7

            https://leetcode.com/explore/learn/card/data-structure-tree/133/conclusion/943/discuss/34538/My-Accepted-Java-Solution
             */

            TreeNode root = FromPreOrderAndInOrderHelper(preorder, inorder, 0, 0, inorder.Length - 1);
            return root;
        }

        private TreeNode FromPreOrderAndInOrderHelper(int[] preorder, int[] inorder, int preStart, int inStart, int inEnd)
        {
            if (preStart > preorder.Length - 1 || inStart > inEnd) return null;

            /* from left to right want to pick nodes off the preorder as they will be stored root first
            ex:
                preorder = [3,9,20,15,7]
                inorder = [9,3,15,20,7]

                from the preorder, the root is 3

            */
            TreeNode root = new TreeNode(preorder[preStart]); // get the root from the preorder

            /* then find that potential root in the inorder list
                everything to the left will be in the current root's left subtree, etc
             */

            int inIndex = 0;
            for (int i = inStart; i < inEnd; i++)
            {
                // find the index of the root extracted from the preorder in the inorder array
                if (root.Val == inorder[i]) // ex: for root 3, the index found will be 1
                    inIndex = i;
            }
            // divide up the array and keep searching through until you exhaust the preorder array length

            // set the current root's left to be everything to the left of index i
            root.Left = FromPreOrderAndInOrderHelper(preorder, inorder, preStart + 1, inStart, inIndex - 1);

            // set the current root's right to be everything to the right of index 1
            int prenext = preStart + inIndex - inStart + 1;
            root.Right = FromPreOrderAndInOrderHelper(preorder, inorder, prenext, inIndex + 1, inEnd);
            return root;
        }
    }
}