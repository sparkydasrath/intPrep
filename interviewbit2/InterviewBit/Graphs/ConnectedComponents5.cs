using System.Collections.Generic;

namespace Graphs
{
    public class ConnectedComponents5
    {
        /*
            694. Number of Distinct Islands
            https://leetcode.com/problems/number-of-distinct-islands/

            Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.

            Count the number of distinct islands. An island is considered to be the same as another if and only if one island can be translated (and not rotated or reflected) to equal the other.

            Example 1:

            11000
            11000
            00011
            00011

            Given the above grid map, return 1.

            Example 2:

            11011
            10000
            00001
            11011

            Given the above grid map, return 3.

            Notice that:

            11
            1

            and

             1
            11

            are considered different island shapes, because we do not consider reflection / rotation.

            Note: The length of each dimension in the given grid does not exceed 50.

         */

        public int FindNumberOfDistinctIslands(int[,] grid)
        {
            List<List<NodePosition>> totalIslands = new List<List<NodePosition>>();
            HashSet<List<int>> directions = new HashSet<List<int>>();
            bool[,] visited = new bool[grid.GetLength(0), grid.GetLength(1)];

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] == 1 && !visited[row, col])
                    {
                        // add a directionTaken parameter
                        /* From LC:
                         *
                         * When we start a depth-first search on the top-left square of some island,
                         * the path taken by our depth-first search will be the same if and only if the shape is the same.
                         * We can exploit this by recording the path we take as our shape - keeping in mind to record both
                         * when we enter and when we exit the function.
                         */
                        List<NodePosition> islandChain = new List<NodePosition>();
                        List<int> directionTaken = new List<int>();
                        List<NodePosition> position = Dfs(grid, row, col, visited, islandChain, directionTaken, 0);
                        totalIslands.Add(position);

                        if (!directions.Contains(directionTaken))
                            directions.Add(directionTaken);
                    }
                }
            }

            return totalIslands.Count;
        }

        private List<NodePosition> Dfs(int[,] grid, int row, int col, bool[,] visited, List<NodePosition> positions, List<int> directionTaken, int dir)
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

            directionTaken.Add(dir);

            Dfs(grid, row + 1, col, visited, positions, directionTaken, 1); // down
            Dfs(grid, row - 1, col, visited, positions, directionTaken, 2); // up
            Dfs(grid, row, col + 1, visited, positions, directionTaken, 3); // right
            Dfs(grid, row, col - 1, visited, positions, directionTaken, 4); // left

            // at end of all recursions, add back in 0 to restart the directionTaken logger for the
            // next element in the grid
            directionTaken.Add(0);

            return positions;
        }
    }
}