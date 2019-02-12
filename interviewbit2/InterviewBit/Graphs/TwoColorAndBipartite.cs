using System.Collections.Generic;

namespace Graphs
{
    public class TwoColorAndBipartite
    {
        /*
         * This is taken from the Algorithms.4th.Edition.2011 pg 546
         * The idea is to use dfs and just like you mark a vertex as visited,
         * you introduce another array to store coloring of verticies
         */

        private readonly bool[] colors;
        private readonly bool[] visited;

        public TwoColorAndBipartite(int vertexCount)
        {
            visited = new bool[vertexCount];
            colors = new bool[vertexCount];
        }

        public bool IsBipartite => IsTwoColorable;

        public bool IsTwoColorable { get; set; }

        public void DfsIsTwoColor(Dictionary<int, List<int>> adjList)
        {
            Graph graph = new Graph(adjList);
            IsTwoColorable = true;
            for (int i = 0; i < graph.GetAdjacencyList(i).Count; i++)
            {
                if (!visited[i])
                    DfsIsTwoColorHelper(graph, i);
            }
        }

        private void DfsIsTwoColorHelper(Graph graph, int current)
        {
            visited[current] = true;
            List<int> adjList = graph.GetAdjacencyList(current);
            for (int i = 0; i < adjList.Count; i++)
            {
                int childOfCurrent = adjList[i];
                if (!visited[childOfCurrent])
                {
                    colors[childOfCurrent] = !colors[current]; // change from the detect cycle/base case
                    DfsIsTwoColorHelper(graph, childOfCurrent);
                }
                else if (colors[childOfCurrent] != colors[current])
                {
                    // change from the detect cycle/base case
                    IsTwoColorable = false;
                }
            }
        }
    }
}