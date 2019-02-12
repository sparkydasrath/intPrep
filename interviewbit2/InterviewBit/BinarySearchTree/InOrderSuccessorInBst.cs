namespace BinarySearchTree
{
    public class InOrderSuccessorInBst
    {
        // todo CANT GET THIS SHIT TO FUCKING WORK

        /*
         *
         * https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/140/introduction-to-a-bst/998/
         *
         * Given a binary search tree and a node in it, find the in-order successor of that node in the BST.
           Note: If the given node has no in-order successor in the tree, return null.

           Example 1:
           Input: root = [2,1,3], p = 1

                2
               / \
              1   3

           Output: 2

           Example 2:
           Input: root = [5,3,6,2,4,null,null,1], p = 6

                5
               / \
               3   6
              / \
             2   4
            /
           1

           Output: null

         */

        /* THIS IS ALL WRONG!!!!!!!!!!!!
         * In order means the left node is visited first then root then right. Based on the example
         * if the search node is in the right half of the BST, we can ignore it since that would indicate a
         * post order traversal
         *
         * The idea would be to search the left side only and recurse down.
         * At each level, see if the next left is not null and check it's node to see if it matches what you are looking for
         *  If match, you are done and return the node you are currently on
         *  If not match keep going down
         *  If you hit the end of the tree and didn't find it, return null

        public TreeNode InOderSuccessor(TreeNode root, TreeNode p)
        {
            // base case
            if (root == null) return null;

            if (p.Val > root.Val) return null; // skip the right half

            if (root.Left == null) return null;

            if (root.Left != null && root.Left.Val == p.Val) return root;
            return InOderSuccessor(root.Left, p);
        }

        */

        /*
         *  Explanation: https://www.youtube.com/watch?v=JdmAYw5h3G8 (vivek)
         *  I completely misunderstood what in-order successor  means in this context
         *
         *  In order successor means that for the given node, find the next node in increasing order
         *  ex: given a node with value 16 and the right tree of it has a bunch of nodes of values like
         *      40  35  45  32  36  30  37 - then the value that comes after/successeds 16 is 30
         *
         *  Important: The in order traversal of a binary tree represents the sorted order of a binary tree
         *  ex: 5 10 14 15 16 30 32 35 36 37 40 45 50 ....
                           -----
                                        50
                                     /      \
                                    16      90
                                   /  \
                                 14     40
                                /  \    |
                               10   15  |
                                        |
                                      /   \
                                    35     45
                                   /   \
                                 32    36
                                 /
                                30

            So if we were just given this array and the node, we would know that the next index
            would be the in order successor

            in this case, need to actually explore the right side of the tree
         */

        public TreeNode InOderSuccessor(TreeNode root, TreeNode p)
        {
            /* Steps (given the node to look deal with)
             *
             *  1. If node.Right != null, return the smallest node in the right subtree
             *  2. If node.Right == null, need to return the parent node
             *
             */

            if (root == null) return null;

            // case 1: if the right subtree is not null, find the least valued node in it

            if (p.Right != null)
            {
                TreeNode temp = p.Right;
                while (temp.Left != null)
                {
                    temp = temp.Left;
                }

                return temp;
            }

            /* case 2: if the right subtree is null, then the next successor would be some ancestor of the node
             The main point: if the node does not have a right subtree
                1. first find the node starting at the root
                2. store the node that you take left turns from
                3. when the loop exits, the last value stored, which is the last left turn made in
                    the search is the ancestor you need

             */

            TreeNode s = root;
            TreeNode store = null;
            while (s.Val != p.Val)
            {
                if (p.Val < s.Val)
                {
                    store = s;
                    s = s.Left;
                }
                else
                    s = s.Right;
            }
            return store;
        }
    }
}