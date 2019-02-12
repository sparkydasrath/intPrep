namespace BinarySearchTree
{
    public class SortedArrayToBst
    {
        /*
            108. Convert Sorted Array to Binary Search Tree
            Easy
         * https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/143/appendix-height-balanced-bst/1015/

            Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

            For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.

            Example:

            Given the sorted array: [-10,-3,0,5,9],

            One possible answer is: [0,-3,9,-10,null,5], which represents the following height balanced BST:

                  0
                 / \
               -3   9
               /   /
             -10  5

         	The overall strategy is to use divide and conquer to create the tree
           Solution:
           1: Initialize start = 0, end = length of the array – 1
           2: mid = (start+end)/2
           3: Create a tree node with mid as root (lets call it A).
           4: Recursively do following steps:
           5: Calculate mid of left subarray and make it root of left subtree of A.
           6: Calculate mid of right subarray and make it root of right subtree of A.
           https://www.youtube.com/watch?v=VCTP81Ij-EM
         */

        public TreeNode GetBstFromSortedArray(int[] nums) => GetBstFromSortedArrayHelper(nums, 0, nums.Length - 1);

        public TreeNode GetBstFromSortedArrayHelper(int[] nums, int start, int end)
        {
            if (start > end) return null;
            int mid = (start + end) / 2;

            TreeNode root = new TreeNode(nums[mid])
            {
                Left = GetBstFromSortedArrayHelper(nums, start, mid - 1),
                Right = GetBstFromSortedArrayHelper(nums, mid + 1, end)
            };

            return root;
        }
    }
}