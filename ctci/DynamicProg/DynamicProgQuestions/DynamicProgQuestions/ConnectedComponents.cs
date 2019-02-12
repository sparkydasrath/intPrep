namespace DynamicProgQuestions
{
    public class ConnectedComponents
    {
        // count number of islands type problem
        public int GetNumberOfIslands(int[,] matrix)
        {
            if (matrix == null) return 0;
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int islandCount = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        islandCount++;
                        ZeroOutNearbySibling(matrix, i, j);
                    }
                }
            }

            return islandCount;
        }

        private void ZeroOutNearbySibling(int[,] m, int row, int col)
        {
            if (row < 0
                || col < 0
                || row >= m.GetLength(0)
                || col >= m.GetLength(1)
                || m[row, col] == 0) return;
            // change the passed in 'land' slot to water
            m[row, col] = 0;

            // change all connected neighbors to water (0) connections clockwise starting at up:
            //
            // up, ne diag, right, se diag, down, sw diag, left, nw diag
            ZeroOutNearbySibling(m, row - 1, col); // up
            ZeroOutNearbySibling(m, row - 1, col + 1); //   ne diag
            ZeroOutNearbySibling(m, row, col + 1); //   right
            ZeroOutNearbySibling(m, row + 1, col + 1); //   se diag
            ZeroOutNearbySibling(m, row + 1, col); //   down
            ZeroOutNearbySibling(m, row + 1, col - 1); //   sw diag
            ZeroOutNearbySibling(m, row, col - 1); //   left
            ZeroOutNearbySibling(m, row - 1, col - 1); //   nw diag
        }
    }
}