namespace Graphs
{
    public class ConnectedComponents0
    {
        /*
         *   This is taken from the Algorithms.4th.Edition.2011_sedgewick book pg 543
         *
         *  Will find the connected components given the adjacency list
                0: 6 2 1 5
                1: 0
                2: 0
                3: 5 4
                4: 5 6 3
                5: 3 4 0
                6: 0 4
                7: 8
                8: 7
                9: 11 10 12
                10: 9
                11: 9 12
                12: 11 9
         */
        private readonly int[] componentId;
        private readonly bool[] visited;

        public ConnectedComponents0(Graph graph)
        {
            visited = new bool[graph.VertexCount];
            componentId = new int[graph.VertexCount];

            for (int i = 0; i < graph.VertexCount; i++)
            {
                if (!visited[i])
                {
                    DfsConnectedComponents0(graph, i);
                    ComponentCount++;
                }
            }
        }

        public int ComponentCount { get; set; }

        public void DfsConnectedComponents0(Graph graph, int node)
        {
            visited[node] = true;
            componentId[node] = ComponentCount;
            for (int i = 0; i < graph.GetAdjacencyList(node).Count; i++)
            {
                int currentNode = graph.GetAdjacencyList(node)[i];
                if (!visited[currentNode]) DfsConnectedComponents0(graph, currentNode);
            }
        }
    }
}