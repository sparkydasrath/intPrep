using System.Collections.Generic;

namespace Google
{
    public class GraphCourseSchedule
    {
        /*
         *
         * 207. Course Schedule https://leetcode.com/problems/course-schedule/
        Medium

        There are a total of n courses you have to take, labeled from 0 to n-1.

        Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]

        Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?

        Example 1:

        Input: 2, [[1,0]]
        Output: true
        Explanation: There are a total of 2 courses to take.
                     To take course 1 you should have finished course 0. So it is possible.

        Example 2:

        Input: 2, [[1,0],[0,1]]
        Output: false
        Explanation: There are a total of 2 courses to take.
                     To take course 1 you should have finished course 0, and to take course 0 you should
                     also have finished course 1. So it is impossible.

        Note:

            The input prerequisites is a graph represented by a list of edges, not adjacency matrices. Read more about how a graph is represented.
            You may assume that there are no duplicate edges in the input prerequisites.

         */

        public void BuildGraph(Dictionary<int, List<int>> adjList, int numCourses, int[,] prerequisites)
        {
            // https://leetcode.com/problems/course-schedule/discuss/225970/Easy-C-implementation-using-DFS
            // https://leetcode.com/problems/course-schedule/discuss/58633/C-DFS-Solution https://leetcode.com/problems/course-schedule/discuss/58664/Java-DFS-solution-beats-90-easy-understanding
            for (int i = 0; i < numCourses; i++)
                adjList.Add(i, new List<int>());

            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                int pre0 = prerequisites[i, 0];
                int pre1 = prerequisites[i, 1];

                // go in the reverse order of each course/prereq
                // given: course, prereq - we will store the adj list as [prerrq, course]
                /*
                 *      int[,] pre = new int[,]
                   {
                       {1,0 },
                       {2,0 },
                       {2,1 },
                   };

                   this becomes:
                 *
                 *  0 => 1, 2
                 *  1 => 2
                 *  2 => {}
                 */
                adjList[pre1].Add(pre0);
            }
        }

        public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            Dictionary<int, List<int>> graphAsAdjacencyList = new Dictionary<int, List<int>>();
            BuildGraph(graphAsAdjacencyList, numCourses, prerequisites);
            HashSet<int> visited = new HashSet<int>();

            for (int i = 0; i < numCourses; i++)
            {
                bool isCyclic = DfsContainsCycle(graphAsAdjacencyList, visited, new HashSet<int>(), i);
                if (isCyclic) return false;
            }

            return true;
        }

        private bool DfsContainsCycle(Dictionary<int, List<int>> graph, HashSet<int> visited, HashSet<int> visiting, int vertex)
        {
            visited.Add(vertex);
            visiting.Add(vertex);

            /* given a vertex, we now want to iterate all it's connected neighbors
                In our graph representation, the key is the vertex and the value is the list of connected neighbors
            */

            for (int descendantOfVertex = 0; descendantOfVertex < graph[vertex].Count; descendantOfVertex++)
            {
                if (!visited.Contains(graph[vertex][descendantOfVertex]) && DfsContainsCycle(graph, visited, visiting, graph[vertex][descendantOfVertex]) ||
                    visiting.Contains(graph[vertex][descendantOfVertex]))
                    return true;
            }

            visiting.Remove(vertex);
            return false;
        }
    }
}