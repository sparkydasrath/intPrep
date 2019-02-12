namespace Arrays
{
    public class RotateMatrix
    {
        public void Rotate(int[,] m)
        {
            int last = m.GetLength(0) - 1;
            int level = 0;
            int totalLevels = m.GetLength(0) / 2;

            while (level < totalLevels)
            {
                for (int i = level; i < last; i++)
                {
                    Swap(ref m[level, i], ref m[i, last]);
                    Swap(ref m[level, i], ref m[last, last - i + level]);
                    Swap(ref m[level, i], ref m[last - i + level, level]);
                }

                level++;
                last--;
            }

            MatrixUtils.Print(m);
        }

        public void Swap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
    }
}