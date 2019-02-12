namespace BinarySearchTree
{
    public class KthLargestElementInStream
    {
        /*
         * https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/142/conclusion/1018/
         * Design a class to find the kth largest element in a stream. Note that it is the kth largest element in the sorted order,
         *  not the kth distinct element.
         */

        /**
         * Your KthLargest object will be instantiated and called as such:
         * KthLargest obj = new KthLargest(k, nums);
         * int param_1 = obj.Add(val);
         *
         * Example:

           int k = 3;
           int[] arr = [4,5,8,2];
           KthLargest kthLargest = new KthLargest(3, arr);
           kthLargest.add(3);   // returns 4
           kthLargest.add(5);   // returns 5
           kthLargest.add(10);  // returns 5
           kthLargest.add(9);   // returns 8
           kthLargest.add(4);   // returns 8

           Note:
           You may assume that nums' length ≥ k-1 and k ≥ 1.
         */

        /*
         *  STEPS:
         *  1. build bst from nums array calling the Insert method from BstOperations
         *  2. in Add, call Insert again
         *  3.
         */

        private readonly BstOperations bstOperations;
        private readonly int mk;
        private TreeNode root = null;

        public KthLargestElementInStream(int k, int[] nums)
        {
            bstOperations = new BstOperations();
            BuildBst(nums);
            mk = k;
        }

        public int Add(int val)
        {
            root = bstOperations.InsertWithCount(root, val);
            return SearchKth(root, mk);
        }

        public int SearchKth(TreeNode root, int k)
        {
            // m = the size of right subtree there m+1 is the (m + 1)th largest

            int m = root.Right?.Count ?? 0;

            // if the kth is the same as the m+1, then we are at root
            if (k == m + 1)
                return root.Val;

            // if k <= m, we are in the right subtree
            if (k <= m) return SearchKth(root.Right, k);

            // if k > m, we have exceeded the size of the root + right subtree and are now in the
            // left subtree almost saying kth smallest here
            return SearchKth(root.Left, k - m - 1);
        }

        private void BuildBst(int[] nums)
        {
            foreach (int val in nums)
            {
                root = bstOperations.InsertWithCount(root, val);
            }
        }
    }
}