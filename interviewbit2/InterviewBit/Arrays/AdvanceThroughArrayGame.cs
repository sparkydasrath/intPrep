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
    }
}