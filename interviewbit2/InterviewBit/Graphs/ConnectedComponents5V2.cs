using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    public class ConnectedComponents5V2
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
            HashSet<string> directions = new HashSet<string>();
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
                        StringBuilder sb = new StringBuilder();
                        List<NodePosition> position = Dfs(grid, row, col, visited, islandChain, sb, 0);
                        totalIslands.Add(position);

                        /* need to do a bit of a hack here to check the lists that contain
                            the same elements because in the HashSet two lists with the same
                            elements are not equal so two lists, {1,2} and {1,2} will be considered
                            different keys and be added to the Set

                        Instead of storing directionTaken as a list, I will just concat all the directions to a string
                        and use that as the key to to the hashset
                        */

                        if (!directions.Contains(sb.ToString()))
                            directions.Add(sb.ToString());
                    }
                }
            }

            return directions.Count;
        }

        private List<NodePosition> Dfs(int[,] grid, int row, int col, bool[,] visited, List<NodePosition> positions, StringBuilder sb, int dir)
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

            sb.Append(dir);

            Dfs(grid, row + 1, col, visited, positions, sb, 1); // down
            Dfs(grid, row - 1, col, visited, positions, sb, 2); // up
            Dfs(grid, row, col + 1, visited, positions, sb, 3); // right
            Dfs(grid, row, col - 1, visited, positions, sb, 4); // left

            // at end of all recursions, add back in 0 to restart the directionTaken logger for the
            // next element in the grid
            sb.Append(0);

            return positions;
        }
    }
}