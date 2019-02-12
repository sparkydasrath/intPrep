namespace Graphs
{
    public class Edge
    {
        public int DestinationVertex { get; set; }
        public int SourceVertex { get; set; }
    }

    public class UnionFind
    {
        // https://www.geeksforgeeks.org/union-find/

        private readonly Graph graph;

        public UnionFind(Graph graph, int numberOfEdges)
        {
            this.graph = graph;
            NumberOfEdges = numberOfEdges;
            Edges = new Edge[numberOfEdges];
            InitializeEdges(numberOfEdges);
        }

        public Edge[] Edges { get; set; }
        public int NumberOfEdges { get; set; }

        public int Find(int[] parent, int node)
        {
            // A utility function to find the subset of an element 'node'
            if (parent[node] == -1) return node;
            return Find(parent, parent[node]);
        }

        public void InitializeParentArray(int[] parent)
        {
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }
        }

        public void Union(int[] parent, int source, int destination)
        {
            // A utility function to do union of two subsets
            int sourceSet = Find(parent, source);
            int destinationSet = Find(parent, destination);
            parent[sourceSet] = destinationSet;
        }

        private void InitializeEdges(int index)
        {
            for (int i = 0; i < NumberOfEdges; i++)
            {
                Edges[i] = new Edge();
            }
        }
    }
}