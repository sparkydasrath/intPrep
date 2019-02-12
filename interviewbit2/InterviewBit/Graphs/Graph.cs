using System.Collections.Generic;

namespace Graphs
{
    public class Graph
    {
        private readonly Dictionary<int, List<int>> adjacencyList;
        private readonly bool isDirected;
        private readonly int[,] nodes;

        public Graph(int[,] nodes, int vertexCount, bool isDirected = false)
        {
            // assuming we are given nodes in the form [ [1,2], [3,4], [1,3] ...]
            this.nodes = nodes;
            this.isDirected = isDirected;
            adjacencyList = new Dictionary<int, List<int>>();
            if (vertexCount == 0)
                vertexCount = nodes.GetLength(0);
            VertexCount = vertexCount;
            InitializeAdjacencyLists(vertexCount);
            BuildGraph(nodes);
        }

        public Graph(Dictionary<int, List<int>> adjcList)
        {
            // assuming we are given nodes in the form [ {1,2,3,4}, {5,6}, {7,8,9} ...] basically
            // given the adjacency list and each index in the array is the source node of that list
            adjacencyList = adjcList;
            VertexCount = adjcList.Count;
        }

        public int VertexCount { get; set; }

        public List<int> GetAdjacencyList(int node)
        {
            if (!adjacencyList.ContainsKey(node)) return new List<int> { };
            return adjacencyList[node];
        }

        private void AddEdge(int v, int w)
        {
            // since this is undirected, we need to
            adjacencyList[v].Add(w);
            // if it is undirected, need to add nodes v -> w and v <- w
            if (!isDirected) adjacencyList[w].Add(v);
        }

        private void BuildGraph(int[,] givenNodes)
        {
            // assuming we are given nodes in the form [ [1,2], [3,4], [1,3] ...] the first dimension
            // will give the number of items we need to iterate
            for (int i = 0; i < givenNodes.GetLength(0); i++)
                AddEdge(nodes[i, 0], nodes[i, 1]);
        }

        private void InitializeAdjacencyLists(int vertexCount)
        {
            for (int i = 0; i < vertexCount; i++)
            {
                // create adjacency lists for each node (assuming nodes come in as 0 1 2 3 ... n
                adjacencyList[i] = new List<int>();
            }
        }
    }
}