using System;
using System.Collections.Generic;

namespace Arrays
{
    public class AdvanceThroughArrayGame
    {
        /*
         In a particular board game, a player has to try to advance through a sequence of
        positions. Each position has a nonnegative integer associated with it, representing
        the maximum you can advance from that position in one move. You begin at the first
        position, and win by getting to the last position.

        For example, let A = (3,3,1,0, 2, 0,1}
        represent the board game, i.e., the ith entry in A is the maximum we can advance
        from i. Then the game can be won by the following sequence of advances through
        A: take 1 step from A[0] to A[1], then 3 steps from A[l] to A[4], then 2 steps from
        A[4] to A[6], which is the last position. Note that A[0] = 3 > 1, A[l] = 3 > 3, and
        A[4] = 2 > 2, so all moves are valid.

        If A instead was (3, 2, 0,0, 2, 0,1), it would not possible to advance past position 3, so the game cannot be won.

        Write a program which takes an array of n integers, where A[i] denotes the maximum
        you can advance from index i, and returns whether it is possible to advance to the
        last index starting from the beginning of the array.

        Hint: Analyze each location, starting from the beginning.
         */

        public bool CanReachEnd(List<int> nums)
        {
            /*
            The idea is that at each index, we count how far we can get from it (i + nums[i]) and keep a
            track of the max we have hit so far
            This is saying that @ index i, we can reach index = i + nums[i]
            If this is equal or beyond the length of the array, it's legit
            As long as we hit the last item or beyond, then return true

             */

            int furthestReachSoFar = 0;
            int lastIndex = nums.Count - 1;
            for (int i = 0; i <= furthestReachSoFar && furthestReachSoFar < lastIndex; i++)
            {
                int val = i + nums[i];
                furthestReachSoFar = Math.Max(furthestReachSoFar, val);
            }
            return furthestReachSoFar >= lastIndex;
        }

        public int MinimumJumpsToGetToEndOfList(List<int> nums)
        {
            /*
             https://www.geeksforgeeks.org/minimum-number-jumps-reach-endset-2on-solution/

            Minimum number of jumps to reach end | Set 2 (O(n) solution)

            Given an array of integers where each element represents the max number of steps that can be made forward from that element.
            Write a function to return the minimum number of jumps to reach the end of the array (starting from the first element).
            If an element is 0, then we cannot move through that element.

            Examples:

            Input :  arr[] = {1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9}
            Output :  3 (1-> 3 -> 8 -> 9)

            */

            if (nums.Count <= 1)
                return 0;

            // Return -1 if not possible to jump
            if (nums[0] == 0)
                return -1;

            List<int> results = new List<int>
            {
                // nums[0]
            };
            int max = nums[0];
            int steps = nums[0];
            int jumps = nums[0];
            for (int i = 1; i < nums.Count; i++)
            {
                /*
                 First we test whether we have reached the end of the array, in that case
                 we just need to return the jump variable.
                 */
                if (i == nums.Count - 1)
                {
                    return jumps;
                }

                /*
                 Next we update the maxReach. This is equal to the maximum of maxReach and i+arr[i]
                 (the number of steps we can take from the current position).
                 */
                int val = i + nums[i];
                max = Math.Max(max, val);

                // We used up a step to get to the current index, so steps has to be decreased.
                steps--;

                // If no further steps left
                if (steps == 0)
                {
                    // we must have used a jump
                    jumps++;

                    // Check if the current index/position or lesser index is the maximum reach point
                    // from the previous indexes
                    if (i >= max) return -1;

                    // re-initialize the steps to the amount of steps to reach maxReach from position i.
                    steps = max - i;
                }
            }

            Console.WriteLine(string.Join(" ", results));

            return -1;
        }
    }
}