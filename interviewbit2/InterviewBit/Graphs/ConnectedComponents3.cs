using System.Collections.Generic;

namespace Graphs
{
    public class ConnectedComponents3
    {
        /*
           Variation of 1 but using a separate matrix to hold the visited/not visited nodes
           and returning a list of all the positions of the islands
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

        public List<List<NodePosition>> FindConnectedIslands(int[,] grid)
        {
            List<List<NodePosition>> totalIslands = new List<List<NodePosition>>();
            bool[,] visited = new bool[grid.GetLength(0), grid.GetLength(1)];

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] == 1 && !visited[row, col])
                    {
                        List<NodePosition> islandChain = new List<NodePosition>();
                        List<NodePosition> position = Dfs(grid, row, col, visited, islandChain);
                        totalIslands.Add(position);
                    }
                }
            }

            return totalIslands;
        }

        private List<NodePosition> Dfs(int[,] grid, int row, int col, bool[,] visited, List<NodePosition> positions)
        {
            if (row < 0 ||
                row >= grid.GetLength(0) ||
                col < 0 ||
                col >= grid.GetLength(1) ||
                grid[row, col] == 0 ||
                visited[row, col] // if visited, then ignore
            )
            {
                return null;
            }

            /*
             * mark current location as visited
           */

            visited[row, col] = true;
            NodePosition np = new NodePosition { Row = row, Col = col };
            positions.Add(np);

            Dfs(grid, row + 1, col, visited, positions); // down
            Dfs(grid, row - 1, col, visited, positions); // up
            Dfs(grid, row, col + 1, visited, positions); // right
            Dfs(grid, row, col - 1, visited, positions); // left

            return positions;
        }
    }
}