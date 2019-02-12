using System;
using System.Collections.Generic;

namespace Graphs
{
    public class ConnectedComponents4
    {
        /*
         * Google onsite interview
         * Given a matrix with numbers 1-9 that are jumbled, find the longest consecutively increasing sequence (or something like that)

        ex:

            6   3   7
            9   2   1
            4   5   8

        4-5 is one sequence
        3-2-1 is another sequence

        STEPS:
        1. recognize that this is a connected components problem with it's own constraints rather than just the islands problem
        2. Depth First Search is ALWAYS used in these problems

        the basic setup is always

        for (int row = ...)
          for (int column = ...)
          {
            dfs(...)
          }

         */

        public List<List<NodePosition>> FindConsecutiveNumbers(int[,] grid)
        {
            bool[,] visited = new bool[grid.GetLength(0), grid.GetLength(1)];
            List<List<NodePosition>> nodePositions = new List<List<NodePosition>>();

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (!visited[row, col])
                    {
                        List<NodePosition> currentPositions = new List<NodePosition>();
                        List<NodePosition> position = Dfs(grid, row, col, visited, currentPositions);
                        nodePositions.Add(position);
                    }
                }
            }

            /*foreach (List<NodePosition> nodePosition in nodePositions)
            {
                Console.WriteLine("----------------");
                foreach (NodePosition position in nodePosition)
                {
                    Console.WriteLine(position.ToString());
                }
            }*/

            return nodePositions;
        }

        private List<NodePosition> Dfs(int[,] grid, int row, int col, bool[,] visited, List<NodePosition> currentNodePositions)
        {
            if (IsBoundary(grid, row, col, visited) == false) return null;

            // mark as visited
            visited[row, col] = true;
            NodePosition np = new NodePosition { Row = row, Col = col, Val = grid[row, col] };
            currentNodePositions.Add(np);

            if (row - 1 >= 0 && !visited[row - 1, col] && IsOneApart(grid[row, col], grid[row - 1, col]))
            {
                // see if going up is possible
                Dfs(grid, row - 1, col, visited, currentNodePositions);
            }
            else if (row + 1 <= grid.GetLength(0) - 1 && !visited[row + 1, col] && IsOneApart(grid[row, col], grid[row + 1, col]))
            {
                // try to go down
                Dfs(grid, row + 1, col, visited, currentNodePositions);
            }
            else if (col - 1 >= 0 && !visited[row, col - 1] && IsOneApart(grid[row, col], grid[row, col - 1]))
            {
                // try go left
                Dfs(grid, row, col - 1, visited, currentNodePositions);
            }
            else if (col + 1 <= grid.GetLength(1) - 1 && !visited[row, col + 1] && IsOneApart(grid[row, col], grid[row, col + 1]))
            {
                // try go right
                Dfs(grid, row, col + 1, visited, currentNodePositions);
            }

            return currentNodePositions;
        }

        private bool IsBoundary(int[,] grid, int row, int col, bool[,] visited)
        {
            if (row < 0 ||
                row >= grid.GetLength(0) ||
                col < 0 ||
                col >= grid.GetLength(1) ||
                visited[row, col]

            )
            {
                return false;
            }

            // need to explore in 4 directions with specific conditions
            return true;
        }

        private bool IsOneApart(int a, int b)
        {
            bool result = Math.Abs(a - b) == 1;
            return result;
        }
    }
}