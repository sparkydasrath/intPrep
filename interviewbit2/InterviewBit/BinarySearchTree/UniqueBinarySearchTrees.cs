using System;

namespace BinarySearchTree
{
    public class UniqueBinarySearchTrees
    {
        /*https://leetcode.com/problems/unique-binary-search-trees/
         DISCUSSION: https://leetcode.com/articles/unique-binary-search-trees/#
         *
         * Given n, how many structurally unique BST's (binary search trees) that store values 1 ... n?

           Example:

           Input: 3
           Output: 5
           Explanation:
           Given n = 3, there are a total of 5 unique BST's:

        This is a catalan number problem
        https://www.youtube.com/watch?v=m9Khxn2g-6w
        https://www.youtube.com/watch?v=YDf982Lb84o

            similar to LongestIncreasingSequence in this solution

         */

        public int CountUniqueBst(int n)
        {
            int[] result = new int[n + 1];
            result[0] = 1;
            result[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    /*
                     * from tushar's explanation and pics, at each step
                     you will have trees on the left and right
                    if:      j is the number of elements on one side of the tree
                    then:    i - j - 1 will be the elements in the other tree

                    Ex 1: for n=5 and input = {10 11 12 13 14 15}

                    root = 10
                        10
                          \
                          {11 12 13 14}

                    root = 11
                        11
                       /  \
                    {10}  {12 13 14} => total trees is BST for 1 element * BST for 3 elements

                     */

                    /* https://www.youtube.com/watch?v=kT_VabdscHk ~13 in
                        does a good explanation of how the sum & product works in this formula

                    IMPORTANT: The reason for the cartesian product below ( T[j] * T[i-j-1] is best explained at
                        https://www.youtube.com/watch?v=JrTKVvYhT_k

                    Ex 2: given n = {1 2 3 4 5 6} and we are using 3 as the root so we have

                                 3
                               /   \
                            {1 2}  {4 5 6}

                    we know for {1 2} we can get 2 unique BST and for  {4 5 6} we can get 5 unique BST
                        this means that any of the 2 subtrees on the left can be combined with any of
                        the subtrees on the right. Hence to combine:
                        2 * 5 = 10
                    */

                    result[i] += result[j] * result[i - j - 1];
                }
            }

            return result[n];
        }

        private int[] ResizeCache(int[] cache)
        {
            int[] newCache = new int[cache.Length << 1]; // double capacity
            Array.Copy(cache, newCache, cache.Length);
            return newCache;
        }
    }
}