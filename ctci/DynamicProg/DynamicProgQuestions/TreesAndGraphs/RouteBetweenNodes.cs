using System.Collections.Generic;
using System.Diagnostics;

namespace TreesAndGraphs
{
    public class RouteBetweenNodes
    {
        /*
         * Route Between Nodes: Given a directed graph, design an algorithm to find out whether there is a
            route between two nodes.
            Hints: #127
         */

        // BFS
        public bool IsPath(GraphNode n, int v)
        {
            if (n == null) return false;
            if (n.GraphNodes == null)
            {
                if (n.Val == v) return true;
                return false;
            }

            Queue<GraphNode> q = new Queue<GraphNode>();
            q.Enqueue(n);
            while (q.Count != 0)
            {
                GraphNode gn = q.Dequeue();
                Debug.WriteLine(gn.Val);
                if (gn.Val == v)
                {
                    return true;
                }
                if (gn.GraphNodes == null) continue;
                foreach (GraphNode node in gn.GraphNodes)
                {
                    q.Enqueue(node);
                }
            }

            return false;
        }
    }
}