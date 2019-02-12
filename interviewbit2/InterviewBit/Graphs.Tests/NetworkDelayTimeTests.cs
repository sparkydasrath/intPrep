using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace Graphs.Tests
{
    [TestFixture]
    public class NetworkDelayTimeTests
    {
        public int[,] BuildAdjacencyMatrix(int size, int maxWeight)
        {
            int[,] matrix = new int[size, size];

            Random r = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 0;
                        continue;
                    }
                    matrix[i, j] = r.Next(maxWeight);
                }
            }
            return matrix;
        }

        [Test]
        public void ShouldReturnSumOfTimesItTakesToTraverseNetwork()
        {
            NetworkDelayTime ndt = new NetworkDelayTime();
            int size = 10;
            int maxWeight = 100;
            int[,] matrix = BuildAdjacencyMatrix(size, maxWeight);
            int sum = ndt.GetNetworkDelayTime(matrix, size, maxWeight);
            Assert.That(sum, Is.Not.EqualTo(0));
        }
    }
}