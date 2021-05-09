namespace lc_2021_01
{
    public static class DynamicIterative
    {
        // given 2D grid, start at the top left, can only move DOWN or RIGHT
        // how many ways can you get to the end
        public static int GridTraveler(int rows, int cols)
        {
            int[,] grid = new int[rows + 1, cols + 1];

            // the base case is that in a 1 x 1 grid, there is only 1 way you can move within that space
            // so in the matrix, use that as the seeding value
            // after that, just loop through the matrix starting at 0,0  and since you can
            // only move RIGHT or DOWN, just add the current cell value to it's right and down neighbors

            grid[1, 1] = 1;

            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    int current = grid[i, j];

                    if (i + 1 <= rows) grid[i + 1, j] += current; // move down
                    if (j + 1 <= cols) grid[i, j + 1] += current; // move right
                }
            }

            PrettyPrint.Print(grid);

            return grid[rows, cols];
        }
    }
}