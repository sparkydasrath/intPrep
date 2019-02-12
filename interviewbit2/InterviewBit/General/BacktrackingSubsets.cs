using System.Collections.Generic;

namespace General
{
    public class BacktrackingSubsets
    {
        /*
         * https://leetcode.com/problems/subsets/
         *
         *Given a set of distinct integers, input, return all possible subsets (the power set).

           Note: The solution set must not contain duplicate subsets.

           Example:

           Input: input = [1,2,3]
           Output:
           [
               [3],
               [1],
               [2],
               [1,2,3],
               [1,3],
               [2,3],
               [1,2],
               []
           ]
         *
         */

        public List<List<int>> Subsets(int[] nums)
        {
            List<List<int>> results = new List<List<int>>();

            if (nums.Length == 0) return results;

            List<int> accumulator = new List<int>();
            SubsetsHelper(accumulator, results, nums, 0);

            return results;
        }

        public void SubsetsHelper(List<int> accumulator, List<List<int>> results, int[] input, int position)
        {
            /*
                this guy has a good drawing (explanation is shit)
                https://www.youtube.com/watch?v=rxitBSy8pZ0
            */

            if (position == input.Length)
            {
                results.Add(new List<int>(accumulator));
            }
            else
            {
                // explore without item
                SubsetsHelper(accumulator, results, input, position + 1);

                // explore with item
                accumulator.Add(input[position]);
                SubsetsHelper(accumulator, results, input, position + 1);

                // unchoose item
                accumulator.RemoveAt(accumulator.Count - 1);
            }
        }
    }
}