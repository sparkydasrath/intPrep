using System.Collections.Generic;
using System.Linq;

namespace Trees
{
    /*
         105. Construct Binary Tree from Preorder and Inorder Traversal https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
        Medium

        Given preorder and inorder traversal of a tree, construct the binary tree.

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

         */

    public class ConstructBtFromPreorderAndInorder
    {
        private readonly Dictionary<int, int> indexMap = new Dictionary<int, int>();
        private int index = 0;
        private int[] inorder;
        private int[] preorder;

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            this.preorder = preorder;
            this.inorder = inorder;
            // build dictionary
            for (int j = 0; j < inorder.Length; j++)
                indexMap[inorder[j]] = j;

            return BuildTreeHelper(0, inorder.Length);
        }

        private TreeNode BuildTreeHelper(int leftIndex, int rightIndex)
        {
            // if there is no elements to construct subtrees
            if (leftIndex == rightIndex) return null;

            // get the root from the preoder array
            int rootVal = preorder[index];
            TreeNode root = new TreeNode(rootVal);

            // root splits inorder list into left and right subtrees
            int pivot = indexMap[rootVal];

            // increment index
            index++;

            // build left
            root.Left = BuildTreeHelper(leftIndex, pivot);

            // build right
            root.Right = BuildTreeHelper(pivot + 1, rightIndex);

            return root;
        }

        private TreeNode BuildTreeHelper2(TreeNode root, List<int> preorderList, List<int> inorderList, int start, int end)
        {
            //MINE - close but no dice
            // we will be removing items from this list so once it is empty we are done
            if (preorderList.Count == 0 || inorderList.Count == 0)
            {
                return root;
            }

            int pivot = preorderList.First();
            int pivotIndex = inorderList.IndexOf(pivot);
            root = new TreeNode(pivot);
            preorderList.RemoveAt(0);

            List<int> io = inorderList.GetRange(start, end - start);

            root.Left = BuildTreeHelper2(root, preorderList, io, 0, pivotIndex);
            root.Right = BuildTreeHelper2(root, preorderList, io, pivotIndex + 1, inorderList.Count);

            return root;
        }
    }
}