namespace Graphs
{
    public class ConnectedComponents1
    {
        /*
         200. Number of Islands

         * https://leetcode.com/problems/number-of-islands/
           https://www.youtube.com/watch?v=R4Nh-EgWjyQ&t=11s
           https://www.youtube.com/watch?v=o8S2bO3pmO4
            Example 1:

            Input:
            11110
            11010
            11000
            00000

            Output: 1

            Example 2:

            Input:
            11000
            11000
            00100
            00011

            Output: 3

        STEPS:
        1. recognize that this is a connected components problem with it's own constraints rather than just the islands problem
        2. Depth First Search is ALWAYS used in these problems

        the basic setup is always

        for (int row = ...)
          for (int column = ...)
          {
            dfs(...)
          }

        In this particular case, it seems most of the solutions require you to modify the original matrix
        meaning, when you visit an island '1', sink (make it '0') then recurse from that so you don't double
        count it

        This is how they handle the visited/not visited situation

         */

        public int FindConnectedIslands(int[,] grid)
        {
            int totalIslands = 0;

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] == 1)
                    {
                        int result = Dfs(grid, row, col);
                        totalIslands += result;
                    }
                }
            }

            return totalIslands;
        }

        private int Dfs(int[,] grid, int row, int col)
        {
            if (row < 0 ||
                row >= grid.GetLength(0) ||
                col < 0 ||
                col >= grid.GetLength(1) ||
                grid[row, col] == 0 // if its not an island we can ignore it
            )
            {
                return 0;
            }

            /* sink each found island as you expand your search
            same as marking it as visited
           */
            grid[row, col] = 0;

            Dfs(grid, row + 1, col); // down
            Dfs(grid, row - 1, col); // up
            Dfs(grid, row, col + 1); // right
            Dfs(grid, row, col - 1); // left

            /* this is the confusing part
             after visiting and sinking successive islands, this just means
             that we are still part of the component originally found in
             the "if (grid[row, col] == 1)" statement in FindConnectedIslands()
             */
            return 1;
        }
    }
}