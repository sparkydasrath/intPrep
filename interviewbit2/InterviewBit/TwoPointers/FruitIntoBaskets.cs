using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoPointers
{
    public class FruitIntoBaskets
    {
        /*
         *904. Fruit Into Baskets https://leetcode.com/problems/fruit-into-baskets/
        Medium

        In a row of trees, the i-th tree produces fruit with type tree[i].

        You start at any tree of your choice, then repeatedly perform the following steps:

        Add one piece of fruit from this tree to your baskets.  If you cannot, stop.
        Move to the next tree to the right of the current tree.  If there is no tree to the right, stop.

        Note that you do not have any choice after the initial choice of starting tree: you must perform step 1, then step 2, then back to step 1, then step 2, and so on until you stop.

        You have two baskets, and each basket can carry any quantity of fruit, but you want each basket to only carry one type of fruit each.

        What is the total amount of fruit you can collect with this procedure?

        Example 1:

        Input: [1,2,1]
        Output: 3
        Explanation: We can collect [1,2,1].

        Example 2:

        Input: [0,1,2,2]
        Output: 3
        Explanation: We can collect [1,2,2].
        If we started at the first tree, we would only collect [0, 1].

        Example 3:

        Input: [1,2,3,2,2]
        Output: 4
        Explanation: We can collect [2,3,2,2].
        If we started at the first tree, we would only collect [1, 2].

        Example 4:

        Input: [3,3,3,1,2,1,1,2,3,3,4]
        Output: 5
        Explanation: We can collect [1,2,1,1,2].
        If we started at the first tree or the eighth tree, we would only collect 4 fruits.

        better explanation https://www.youtube.com/watch?v=za2YuucS0tw

         *
         */

        /*
         * Take away:
         * Input: [1,2,3,2,2] means we have 3 types of fruits
         *
         *  1   2   3   2   2
         * ---------------------
         *  t1  t2  t3  t2  t2
         *
         * And we have to pick fruits CONSECUTIVELY, meaning if we start from the left
         *
         * Basket 1 can have t1 * 1
         * Basket 2 can have t2 * 1
         * then we encounter a 3rd type of fruit - need to make a decision about which basket to dump
         * since this is type of 'largest sub-array' problem, we need to abandon the
         *  earliest chosen tree
         * So far we have collected 2 types of fruits
         *
         * That means, we toss whatever was in basket 1 and add t3 to it
         * Continuing,
         *  Basket 2 will have t2 * 2
         *  Basket 2 will have t2 * 3
         *
         * Now we hit the end and we have
         *
         * Basket 1 with 1 t3
         * Basket 2 with 3 t2
         * so total is 4
         */

        /*
         * UPDATE: This is a fucked up worded version of the LongestSubstringWithAtMostKDistinctCharacters problem
         */

        public int SumOfFruits(Dictionary<int, int> baskets) => baskets.Values.Sum();

        public int TotalFruit(int[] tree)
        {
            /*
             * I knew there was an easier way but as I do, I fucking complicated the solution
             *
             * Based on this asshole https://www.youtube.com/watch?v=KUY_f8jxWoU all you want to do
             * is keep a reference to the index of the fruit you have seen rather than a count
             *
             * The main idea is to use the Dictionary data structure to your advantage
             *
             */

            int max = 0;
            int head = 0;
            int tail = 0;
            Dictionary<int, int> baskets = new Dictionary<int, int>();

            if (tree == null || tree.Length == 0) return 0;

            while (tail < tree.Length)
            {
                // as long as we have less than 2 items in the dictionary we can add a fruit

                if (baskets.Count <= 2)
                {
                    baskets[tree[tail]] = tail;
                    tail++; // can safely put a fruit, now advance
                }

                if (baskets.Count > 2)
                {
                    // need to exclude the first fruit since we are storing indices, it will be the
                    // item with the smallest index
                    int indexOfOldestFruit = tree.Length - 1; // the min can't get any bigger than this

                    /*find the min index need to loop through all the results because they are not
                     stored in order in the dictionary
                    */
                    foreach (int val in baskets.Values)
                        indexOfOldestFruit = Math.Min(indexOfOldestFruit, val);

                    // remove it from the dictionary
                    baskets.Remove(tree[indexOfOldestFruit]);

                    // update the head
                    head = indexOfOldestFruit + 1;
                }

                max = Math.Max(max, tail - head);
            }

            return max;
        }

        public int TotalFruitMine(int[] tree)
        {
            // OVERLY FUCKING COMPLICATED

            if (tree.Length == 0) return 0;
            if (tree.Length == 1) return 1;

            // setup state
            int head = 0;
            int tail = 0;
            int max = 0;
            Dictionary<int, int> baskets = new Dictionary<int, int>();
            Queue<int> queue = new Queue<int>();

            while (tail < tree.Length)
            {
                if (!baskets.ContainsKey(tree[tail]))
                {
                    // current tree not in basket

                    // check how many baskets we have used
                    if (baskets.Keys.Count != 2)
                    {
                        // if we haven't used both baskets yet, then just add this tree and move tail forward
                        baskets.Add(tree[tail], 1);
                        // enqueue the index of the last added tree
                        queue.Enqueue(tail);
                        tail++;

                        max = UpdateMax(baskets, max);
                    }
                    else
                    {
                        // clear the basket with the oldest tree which will be the first item in the queue
                        int toRemove = queue.Dequeue();
                        baskets.Remove(tree[toRemove]);

                        // make head the value just before the tail since this is the point where a
                        // different type of tree was found and the baskets are full
                        if (queue.Count != 0)
                            head = queue.Peek(); // index of new head

                        // add the next tree
                        baskets.Add(tree[tail], 1);
                        queue.Enqueue(tail);

                        // advance tail
                        tail++;

                        // if we used both, then we need to deal with the new tree type get the sum
                        // of fruits in the baskets
                        max = UpdateMax(baskets, max);
                    }
                }
                else
                {
                    // at this point the tree is in the basket already update the existing tree count
                    UpdateBasketCount(tree[tail], baskets);
                    max = UpdateMax(baskets, max);

                    // move the tail forward
                    tail++;
                }
            }

            return max;
        }

        public void UpdateBasketCount(int key, Dictionary<int, int> baskets)
        {
            int val = baskets[key];
            val += 1;
            baskets[key] = val;
        }

        public int UpdateMax(Dictionary<int, int> baskets, int max)
        {
            int currentSum = SumOfFruits(baskets);
            return Math.Max(max, currentSum);
        }
    }
}