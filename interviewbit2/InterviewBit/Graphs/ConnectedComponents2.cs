namespace Graphs
{
    public class ConnectedComponents2
    {
        /*
           Variation of 1 but using a separate matrix to hold the visited/not visited nodes
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

            I am aiming to redo this but using an auxiliary matrix to hold the truth values

         */

        public int FindConnectedIslands(int[,] grid)
        {
            int totalIslands = 0;
            bool[,] visited = new bool[grid.GetLength(0), grid.GetLength(1)];

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] == 1 && !visited[row, col])
                    {
                        int result = Dfs(grid, row, col, visited);
                        totalIslands += result;
                    }
                }
            }

            return totalIslands;
        }

        private int Dfs(int[,] grid, int row, int col, bool[,] visited)
        {
            if (row < 0 ||
                row >= grid.GetLength(0) ||
                col < 0 ||
                col >= grid.GetLength(1) ||
                grid[row, col] == 0 ||
                visited[row, col] // if visited, then ignore
            )
            {
                return 0;
            }

            /*
             * mark current location as visited
           */

            visited[row, col] = true;

            Dfs(grid, row + 1, col, visited); // down
            Dfs(grid, row - 1, col, visited); // up
            Dfs(grid, row, col + 1, visited); // right
            Dfs(grid, row, col - 1, visited); // left

            return 1;
        }
    }
}