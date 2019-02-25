using System.Collections.Generic;

namespace Graphs
{
    public class CourseSchedule2
    {
        // One of the cleanest DFS + Topological sort I have come across - need to remember how to
        // use it

        /* https://leetcode.com/problems/course-schedule-ii/
         210. Course Schedule II
        Medium

        There are a total of n courses you have to take, labeled from 0 to n-1.

        Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]

        Given the total number of courses and a list of prerequisite pairs, return the ordering of courses you should take to finish all courses.

        There may be multiple correct orders, you just need to return one of them. If it is impossible to finish all courses, return an empty array.

        Example 1:

        Input: 2, [[1,0]]
        Output: [0,1]
        Explanation: There are a total of 2 courses to take. To take course 1 you should have finished
                     course 0. So the correct course order is [0,1] .

        Example 2:

        Input: 4, [[1,0],[2,0],[3,1],[3,2]]
        Output: [0,1,2,3] or [0,2,1,3]
        Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both
                     courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
                     So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3] .

        Note:

            The input prerequisites is a graph represented by a list of edges, not adjacency matrices. Read more about how a graph is represented.
            You may assume that there are no duplicate edges in the input prerequisites.

        LC: https://leetcode.com/articles/course-schedule-ii/#

         */

        /*

         This is not the FULL solution but more of an overview to show how to solve these kinds of
         top problems

             ➔ let S be a stack/list of courses
             ➔ function Dfs(node)
             ➔     for each neighbor in adjacency list of node
             ➔          Dfs(neighbor)
             ➔     add node to S

            Algorithm

            1. Initialize a stack S that will contain the topologically sorted order of the courses in our graph.
            2. [IMPORTANT]Construct the adjacency list using the edge pairs given in the input.
                An important thing to note about the input for the problem is that a pair
                such as [a, b] represents that the course b needs to be taken in order
                to do the course a. This implies an edge of the form b ➔ a.
                Please take note of this when implementing the algorithm.
            3. For each of the nodes in our graph, we will run a depth first search
                in case that node was not already visited in some other node's DFS traversal.
            4. Suppose we are executing the depth first search for a node N.
                We will recursively traverse all of the neighbors of node N which have not been processed before.
            5. Once the processing of all the neighbors is done, we will add the
                node N to the stack. We are making use of a stack to simulate the ordering we need. When we add the node N to the stack, all the nodes that require the node N as a prerequisites (among others) will already be in the stack.
            6. Once all the nodes have been processed, we will simply return the
                nodes as they are present in the stack from top to bottom.

         */

        private static readonly int Black = 3;
        private static readonly int Gray = 2;
        private static readonly int White = 1;
        private readonly Dictionary<int, List<int>> adjList;
        private readonly Dictionary<int, int> color;
        private readonly List<int> topologicalOrder;
        private bool isPossible;

        public CourseSchedule2(int numCourses)
        {
            isPossible = true;
            color = new Dictionary<int, int>();
            adjList = new Dictionary<int, List<int>>();
            topologicalOrder = new List<int>();

            // By default all vertices are WHITE
            for (int i = 0; i < numCourses; i++)
                color[i] = White;
        }

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            // create adjacency list
            for (int i = 0; i < numCourses; i++)
                adjList.Add(i, new List<int>());

            // Create the adjacency list representation of the graph
            for (int i = 0; i < prerequisites.Length; i++)
            {
                int dest = prerequisites[i][0];
                int src = prerequisites[i][1];
                adjList[src].Add(dest);
            }

            // If the node is unprocessed, then call Dfs on it.
            for (int i = 0; i < numCourses; i++)
            {
                if (color[i] == White)
                    Dfs(i);
            }

            int[] order;
            if (isPossible)
            {
                order = new int[numCourses];
                // could prob just do topologicalOrder.Reverse() here
                for (int i = 0; i < numCourses; i++)
                    order[i] = topologicalOrder[numCourses - i - 1];
            }
            else
                order = new int[0];

            return order;
        }

        private void Dfs(int node)
        {
            // Don't recurse further if we found a cycle already
            if (!isPossible) return;

            // Start the recursion mark node as 'visiting'
            color[node] = Gray;

            // Traverse on neighboring vertices
            List<int> neighbors = adjList[node];
            foreach (int neighbor in neighbors)
            {
                if (color[neighbor] == White)
                    Dfs(neighbor);
                else if (color[neighbor] == Gray)
                    isPossible = false; // An edge to a GRAY vertex represents a cycle
            }

            // Recursion ends. We mark it as black mark node as 'visited'
            color[node] = Black;
            topologicalOrder.Add(node);
        }
    }
}