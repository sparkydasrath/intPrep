using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Graphs.Tests
{
    [TestFixture]
    public class ConnectedComponentsTests
    {
        [Test]
        public void ShouldCountConnectedComponents0()
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

            ConnectedComponents0 cc0 = new ConnectedComponents0(g);
            Assert.That(cc0.ComponentCount, Is.EqualTo(3));
        }

        [Test]
        public void ShouldCountConnectedComponents1()
        {
            /*
              *  Input:
                 11000
                 11000
                 00100
                 00011

                 Output: 3
              */
            ConnectedComponents1 cc1 = new ConnectedComponents1();
            // int[,] grid = { { 1, 1, 0, 0, 0 }, { 1, 1, 0, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 0, 1,
            // 1 } };
            int[,] grid = { { 1 }, { 1 } };
            int result = cc1.FindConnectedIslands(grid);
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void ShouldCountConnectedComponents2()
        {
            /*
             *  Input:
                11000
                11000
                00100
                00011

                Output: 3
             */

            ConnectedComponents2 cc2 = new ConnectedComponents2();
            int[,] grid =
            {
                { 1, 1, 0, 0, 0 },
                { 1, 1, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 1, 1 }
            };
            int result = cc2.FindConnectedIslands(grid);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void ShouldCountConnectedComponents3()
        {
            /*
             *  Input:
                11000
                11000
                00100
                00011

                Output: List: { 0,0; 0,1; 1,0; 1,1 }, {2,2}, {3,3; 3,4}
             */

            ConnectedComponents3 cc2 = new ConnectedComponents3();
            int[,] grid =
            {
                { 1, 1, 0, 0, 0 },
                { 1, 1, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 1, 1 }
            };

            int[,] grid2 =
                {
                    {1,1,0,0,0},
                    {1,1,0,0,0},
                    {0,0,0,1,1},
                    {0,0,0,1,1}
    };
            List<List<NodePosition>> result1 = cc2.FindConnectedIslands(grid);
            Assert.That(result1.Count, Is.EqualTo(3));
            Assert.That(result1[0].Count, Is.EqualTo(4));
            Assert.That(result1[1].Count, Is.EqualTo(1));
            Assert.That(result1[2].Count, Is.EqualTo(2));

            List<List<NodePosition>> result2 = cc2.FindConnectedIslands(grid2);
            Assert.That(result2.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldCountConnectedComponents4()
        {
            /*
             *  Input:
                11000
                11000
                00100
                00011

                Output: List: { 0,0; 0,1; 1,0; 1,1 }, {2,2}, {3,3; 3,4}
             */

            ConnectedComponents4 cc4 = new ConnectedComponents4();
            int[,] grid =
            {
                { 6,3,7},
                { 9,2,1 },
                { 4,5,8 }
            };
            List<List<NodePosition>> result = cc4.FindConsecutiveNumbers(grid);

            int max = 0;

            foreach (List<NodePosition> r in result)
            {
                max = Math.Max(max, r.Count);
            }

            Assert.That(max, Is.EqualTo(3));
        }

        [Test]
        public void ShouldCountConnectedComponents5()
        {
            /*
             *  11000
                11000
                00011
                00011

                Given the above grid map, return 1.
             */

            ConnectedComponents5 cc5 = new ConnectedComponents5();
            ConnectedComponents5V2 cc5v2 = new ConnectedComponents5V2();
            int[,] grid =
            {
                { 1,1,0,0,0},
                { 1,1,0,0,0 },
                { 0,0,0,1,1},
                { 0,0,0,1,1},
            };
            int resultV1 = cc5.FindNumberOfDistinctIslands(grid);

            Assert.That(resultV1, Is.EqualTo(2));

            int resultV2 = cc5v2.FindNumberOfDistinctIslands(grid);
            Assert.That(resultV2, Is.EqualTo(1));
        }
    }
}