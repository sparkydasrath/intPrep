using NUnit.Framework;
using System.Collections.Generic;

namespace Graphs.Tests
{
    [TestFixture]
    public class DetectCycleTests
    {
        [Test]
        public void ShouldReturnTrueIfCycleExitsDfsUndirected()
        {
            // assuming we are given nodes in the form [ {1,2,3,4}, {5,6}, {7,8,9} ...] basically
            // given the adjacency list and each index in the array is the source node of that list

            // This example is taken from https://www.youtube.com/watch?v=6ZRhq2oFCuo https://www.geeksforgeeks.org/detect-cycle-undirected-graph/

            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>
            {
                [0] = new List<int> { 1, 2 },
                [1] = new List<int> { },
                [2] = new List<int> { 3, 4 },
                [3] = new List<int> { 2, 4 },
                [4] = new List<int> { 2, 3 },
            };

            DetectCycle dc1 = new DetectCycle();
            dc1.DfsUndirectedIsCyclic(adjList);
            Assert.IsTrue(dc1.HasCycle);
        }

        [Test]
        public void ShouldReturnTrueIfCycleExitsUnionFind()
        {
            // assuming we are given nodes in the form [ {1,2,3,4}, {5,6}, {7,8,9} ...] basically
            // given the adjacency list and each index in the array is the source node of that list

            // This example is taken from https://www.youtube.com/watch?v=6ZRhq2oFCuo https://www.geeksforgeeks.org/detect-cycle-undirected-graph/

            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>
            {
                [0] = new List<int> { 1, 2 },
                [1] = new List<int> { },
                [2] = new List<int> { 3, 4 },
                [3] = new List<int> { 2, 4 },
                [4] = new List<int> { 2, 3 },
            };

            Edge[] edges = new Edge[]
            {
                new Edge {SourceVertex = 0, DestinationVertex = 1},
                new Edge {SourceVertex = 0, DestinationVertex = 2},
                new Edge {SourceVertex = 2, DestinationVertex = 3},
                new Edge {SourceVertex = 2, DestinationVertex = 4},
                new Edge {SourceVertex = 3, DestinationVertex = 4},
            };

            DetectCycle dc1 = new DetectCycle();
            Graph g = new Graph(adjList);
            UnionFind uf = new UnionFind(g, 5)
            {
                Edges = edges
            };
            bool result = dc1.UnionFindUndirectedIsCyclic(g, uf);
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnTrueIfCycleExitsWithBoolReturnForUndirected()
        {
            // assuming we are given nodes in the form [ {1,2,3,4}, {5,6}, {7,8,9} ...] basically
            // given the adjacency list and each index in the array is the source node of that list

            // This example is taken from https://www.youtube.com/watch?v=6ZRhq2oFCuo https://www.geeksforgeeks.org/detect-cycle-undirected-graph/

            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>
            {
                [0] = new List<int> { 1, 2 },
                [1] = new List<int> { },
                [2] = new List<int> { 3, 4 },
                [3] = new List<int> { 2, 4 },
                [4] = new List<int> { 2, 3 },
            };

            DetectCycle dc1 = new DetectCycle();
            bool result = dc1.IsUndirectedGraphCyclicWithAdjList(adjList);
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnTrueIfCycleShouldReturnTrueIfCycleExitsWithBoolReturnForDirectedExitsDfsDirected()
        {
            // assuming we are given nodes in the form [ {1,2,3,4}, {5,6}, {7,8,9} ...] basically
            // given the adjacency list and each index in the array is the source node of that list

            // This example is taken from https://www.youtube.com/watch?v=6ZRhq2oFCuo https://www.geeksforgeeks.org/detect-cycle-undirected-graph/

            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>
            {
                [0] = new List<int> { 1, 2 },
                [1] = new List<int> { 2 },
                [2] = new List<int> { 0, 3 },
            };

            DetectCycle dc1 = new DetectCycle();
            bool result = dc1.IsDirectedGraphCyclicWithAdjList(adjList);
            Assert.IsTrue(result);
        }
    }
}