using System.Collections.Generic;

namespace Graphs
{
    public class DetectCycle
    {
        private readonly HashSet<int> visited;

        public DetectCycle() => visited = new HashSet<int>();

        public bool HasCycle { get; private set; }

        public void DfsUndirectedIsCyclic(Dictionary<int, List<int>> adjList)
        {
            // This is taken from the Algorithms.4th.Edition.2011_sedgewick book pg 547
            Graph graph = new Graph(adjList);
            for (int i = 0; i < graph.VertexCount; i++)
            {
                if (!visited.Contains(i))
                {
                    // pass -1 as the parent to kick things off
                    DfsUndirectedIsCyclicHelper(graph, i, -1);
                }
            }
        }

        public bool IsDirectedGraphCyclicWithAdjList(Dictionary<int, List<int>> adjList)
        {
            Graph graph = new Graph(adjList);
            HashSet<int> recursionStack = new HashSet<int>();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                bool isCyclic = IsDirectedGraphCyclicWithAdjListHelper(graph, recursionStack, i);
                if (isCyclic) return true;
            }

            return false;
        }

        public bool IsUndirectedGraphCyclicWithAdjList(Dictionary<int, List<int>> adjList)
        {
            Graph graph = new Graph(adjList);
            for (int i = 0; i < graph.VertexCount; i++)
            {
                if (!visited.Contains(i))
                {
                    bool isCyclic = IsUndirectedGraphCyclicWithAdjListHelper(graph, i, -1);
                    if (isCyclic) return true;
                }
            }

            return false;
        }

        public bool UnionFindUndirectedIsCyclic(Graph g, UnionFind uf)
        {
            int[] parent = new int[g.VertexCount];
            uf.InitializeParentArray(parent);

            // Iterate through all edges of graph, find subset of both vertices of every edge, if
            // both subsets are same, then there is cycle in graph.
            for (int i = 0; i < uf.NumberOfEdges; ++i)
            {
                int x = uf.Find(parent, uf.Edges[i].SourceVertex);
                int y = uf.Find(parent, uf.Edges[i].DestinationVertex);

                if (x == y)
                    return true;

                uf.Union(parent, x, y);
            }
            return false;
        }

        private void DfsUndirectedIsCyclicHelper(Graph graph, int current, int parent)
        {
            /* This is taken from the Algorithms.4th.Edition.2011_sedgewick book pg 547
             https://www.geeksforgeeks.org/detect-cycle-undirected-graph/
             */
            visited.Add(current);
            for (int i = 0; i < graph.GetAdjacencyList(current).Count; i++)
            {
                List<int> adjList = graph.GetAdjacencyList(current);
                int adjacentOfCurrentNode = adjList[i];
                if (!visited.Contains(adjacentOfCurrentNode))
                    DfsUndirectedIsCyclicHelper(graph, adjacentOfCurrentNode, current);
                else if (adjacentOfCurrentNode != parent)
                {
                    HasCycle = true;

                    /* If an adjacent node is visited and not parent of current vertex, then there is
                     a cycle

                    Ok for a while I didn't get wtf was happening but now I get it:
                    1. At each step, find an unvisited node and visit it
                    2. When you visit a new unvisited node, mark yourself as the parent - this is
                        keeping a history of where you come from
                    3. In the example below, there is a the 2-3-4-2 cycle
                    4. Will explore from 2, then when you recur, pick 3
                        Since the adj list for 3 is {2,4} we will not explore 2 again since it was already visited
                    5. Pick 4 with adjList {2,3}
                        If we visit 3, we will see that it is visited AND the parent of 4, so don't bother
                        If we visit 2, we will see that is is visited but 2 is NOT the parent of 4
                            If there was no cycle, then the parent of 4 would be fixed and always be 3 AND
                            you can only go from node to parent.
                        Since we were able to navigate to a visited node which was not the parent of the current node
                        then this is only possible in a cycle

                          0
                         / \
                        1   2
                           / \
                          3---4
                     */
                }
            }
        }

        private bool IsDirectedGraphCyclicWithAdjListHelper(Graph graph, HashSet<int> recursionStack, int current)
        {
            if (visited.Contains(current)) return false;
            if (recursionStack.Contains(current)) return true;

            // Mark the current node as visited and part of recursion stack
            visited.Add(current);
            recursionStack.Add(current);

            List<int> childrenOfCurrent = graph.GetAdjacencyList(current);
            for (int i = 0; i < childrenOfCurrent.Count; i++)
            {
                int nextVertex = childrenOfCurrent[i];
                if (IsDirectedGraphCyclicWithAdjListHelper(graph, recursionStack, nextVertex)) return true;
            }

            // once we have fully explored a node and it's neighbors and there is no cycle, remove
            // from the stack
            recursionStack.Remove(current);

            return false;
        }

        private bool IsUndirectedGraphCyclicWithAdjListHelper(Graph graph, int currentNode, int parentNode)
        {
            visited.Add(currentNode);

            List<int> adjList = graph.GetAdjacencyList(currentNode);
            for (int i = 0; i < adjList.Count; i++)
            {
                int next = adjList[i];
                if (!visited.Contains(next))
                {
                    if (IsUndirectedGraphCyclicWithAdjListHelper(graph, next, currentNode))
                        return true;
                }
                else if (next != parentNode) return true;
            }

            return false;
        }
    }
}