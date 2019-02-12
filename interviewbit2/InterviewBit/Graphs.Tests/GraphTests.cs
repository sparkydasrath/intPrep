using NUnit.Framework;
using System.Collections.Generic;

namespace Graphs.Tests
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
        public void ShouldBuildGraph()
        {
            int[,] nodes = new int[,]
            {
                {1, 0},
                {0, 2},
                {2, 0},
                {0, 3},
                {3, 4},
        };

            Graph g = new Graph(nodes, 0);
            System.Collections.Generic.List<int> adjList = g.GetAdjacencyList(0);
            Assert.That(adjList.Count, Is.EqualTo(4));
        }

        [Test]
        public void ShouldBuildGraphGivenAdjacencyList()
        {
            // assuming we are given nodes in the form [ {1,2,3,4}, {5,6}, {7,8,9} ...] basically
            // given the adjacency list and each index in the array is the source node of that list

            // This is taken from the Algorithms.4th.Edition.2011_sedgewick book pg 543
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>
            {
                [0] = new List<int> { 6, 2, 1, 5 },
                [1] = new List<int> { 0 },
                [2] = new List<int> { 0 },
                [3] = new List<int> { 5, 4 },
                [4] = new List<int> { 5, 6, 3 },
                [5] = new List<int> { 3, 4, 0 },
                [6] = new List<int> { 0, 4 },
                [7] = new List<int> { 8 },
                [8] = new List<int> { 7 },
                [9] = new List<int> { 11, 10, 12 },
                [10] = new List<int> { 9 },
                [11] = new List<int> { 9, 12 },
                [12] = new List<int> { 11, 9 },
            };

            Graph g = new Graph(adjList);
            Assert.That(g.GetAdjacencyList(0).Count, Is.EqualTo(4));
        }
    }
}