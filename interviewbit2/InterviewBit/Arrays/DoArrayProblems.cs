using System;
using Utils;

namespace Arrays
{
    public class DoArrayProblems
    {
        private readonly int[,] seedMatrix = MatrixUtils.BuildMatrixGeneric<int>(4, 5);

        public void PrintRotateMatrixClockwise()
        {
            SpiralMatrixFb sfb = new SpiralMatrixFb();
            int[,] seed = MatrixUtils.BuildSquareMatrix(4);

            Console.WriteLine($"Seed matrix \n");
            MatrixUtils.PrintMatrixGeneric(seed);
            Console.WriteLine($"\n Result \n");
            sfb.RotateMatrix90Clockwise(seed);
        }

        public void PrintZigZag()
        {
            SpiralMatrixFb sfb = new SpiralMatrixFb();
            int[,] seed = MatrixUtils.BuildSquareMatrix(4);

            Console.WriteLine($"Seed matrix \n");
            MatrixUtils.PrintMatrixGeneric(seed);
            Console.WriteLine($"\n Result \n");
            sfb.PrintMatrixInZigZagForm(seed);
        }
    }
}