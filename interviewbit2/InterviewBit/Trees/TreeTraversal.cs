using System;
using System.Collections.Generic;
using System.Linq;

namespace Trees
{
    public class TreeTraversal
    {
        public List<int> BottomView(TreeNode root)
        {
            /* (vivek) https://www.youtube.com/watch?v=c3SAvcjWb1E
             This is a combination of level order and vertical order

            Similar to topview, but just iterate the results from VerticalOrder
            and take the last element of each list

             */

            List<List<int>> verticalOrderResults = VerticalOrder(root);
            List<int> bottomViewResults = new List<int>();

            foreach (List<int> vor in verticalOrderResults)
            {
                bottomViewResults.Add(vor.Last());
            }

            return bottomViewResults;
        }

        public List<int> InOrderIterative1(TreeNode root)
        {
            /*
             * tushar
             * https://www.youtube.com/watch?v=nzmtCFNae9k
             *
             */

            if (root == null) return null;
            List<int> results = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;

            while (true)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (stack.Count == 0) break;
                    current = stack.Pop();
                    results.Add(current.Val);
                    current = current.Right;
                }
            }

            return results;
        }

        public List<int> InOrderIterative2(TreeNode root)
        {
            /*
                https://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion/
            1) Create an empty stack S.
            2) Initialize current node as root
            3) Push the current node to S and set current = current->left until current is NULL
            4) If current is NULL and stack is not empty then
                a) Pop the top item from stack.
                b) Print the popped item, set current = popped_item->right
                c) Go to step 3.
            5) If current is NULL and stack is empty then we are done.
            */

            if (root == null) return null;
            List<int> results = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode current = root;
            stack.Push(current);
            current = current.Left;

            while (current != null || stack.Count != 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                results.Add(current.Val);
                current = current.Right;
            }

            return results;
        }

        public List<int> InOrderRecursive(TreeNode root)
        {
            List<int> results = new List<int>();
            InOrderRecursiveHelper(root, results);
            return results;
        }

        public List<List<int>> LevelOrderIterative(TreeNode root)
        {
            List<List<int>> results = new List<List<int>>();
            LevelOrderIterativeHelper(root, results);
            return results;
        }

        public List<int> PostOrderIterative(TreeNode root)
        {
            /*
             * tushar
             * https://www.youtube.com/watch?v=qT65HltK2uE
             *
             */

            if (root == null) return null;
            List<int> results = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<TreeNode> resultStack = new Stack<TreeNode>();
            TreeNode current = root;
            stack.Push(current);
            while (stack.Count != 0)
            {
                current = stack.Pop();
                if (current.Left != null) stack.Push(current.Left);
                if (current.Right != null) stack.Push(current.Right);
                resultStack.Push(current);
            }

            while (resultStack.Count != 0)
                results.Add((resultStack.Pop()).Val);

            return results;
        }

        public List<int> PostOrderRecursive(TreeNode root)
        {
            if (root == null) return null;
            List<int> results = new List<int>();
            PostOrderRecursiveHelper(root, results);
            return results;
        }

        public List<int> PreOrderIterative(TreeNode root)
        {
            /*
             https://www.geeksforgeeks.org/iterative-preorder-traversal/
             https://www.youtube.com/watch?v=elQcrJrfObg
             * 1) Create an empty stack nodeStack and push root node to stack.
               2) Do following while nodeStack is not empty.
               ….a) Pop an item from stack and print it.
               ….b) Push right child of popped item to stack
               ….c) Push left child of popped item to stack

               Right child is pushed before left child to make sure that left subtree is processed first.
             */
            if (root == null) return null;
            List<int> results = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            stack.Push(root);

            while (stack.Count != 0)
            {
                TreeNode current = stack.Pop();
                results.Add(current.Val);

                if (current.Right != null) stack.Push(current.Right);
                if (current.Left != null) stack.Push(current.Left);
            }

            return results;
        }

        public List<int> PreOrderRecursive(TreeNode root)
        {
            List<int> results = new List<int>();
            PreOrderRecursiveHelper(root, results);
            return results;
        }

        public List<int> TopView(TreeNode root)
        {
            /* (vivek) https://www.youtube.com/watch?v=c3SAvcjWb1E
             This is a combination of level order and vertical order

            STEPS:
            1. Do modified level order and store all nodes in a list/queue
            2. Do a normal vertical order
            3. For each item in the list of lists returned by the vertical order, see which one
                appears first in 1
                Note: need to do this because in vertical order, you can have multiple nodes
                    along the same vertical

            Actually, I feel lik you can just do VerticalOrder normally and just take the first item
            in each list as they satisfy the necessary condition

             */

            List<List<int>> verticalOrderResults = VerticalOrder(root);
            List<int> topViewResult = new List<int>();

            foreach (List<int> vor in verticalOrderResults)
            {
                topViewResult.Add(vor[0]);
            }

            return topViewResult;
        }

        public void UpdateStore(Tuple<TreeNode, int> nodeAndHd, Dictionary<int, List<int>> store)
        {
            TreeNode root = nodeAndHd.Item1;
            int hd = nodeAndHd.Item2;
            if (!store.ContainsKey(hd))
            {
                List<int> newNode = new List<int>
                {
                    root.Val
                };
                store[hd] = newNode;
            }
            else
            {
                List<int> nodesVisited = store[hd];
                nodesVisited.Add(root.Val);
            }
        }

        public List<List<int>> VerticalOrder(TreeNode root)
        {
            /* STEPS
                Need to mark the node distance. This is a modification of level order (BFS)
                - will need a queue and hashtable

                hd = horizontal distance (this is the distance of the node from the root)

                1. Set root hd = 0
                2. Set root.Left hd = hd - 1
                3. Set root.Right hd = hd + 1
                4. As you visit node, add to hashtable

                    For example:

                        a (hd=0)
                       / \
              (hd=-1) b   c (hd=1)

              all nodes 'under' b will also be hd=-1 distance away from the root so they are all in the same 'vertical'

                key  | value
                 - 1 | {b, ....}
                   1 | {c, ...}
                  -2 | {whatver, etc}

            (vivek) https://www.youtube.com/watch?v=PQKkr036wRc
            (g4g) https://www.youtube.com/watch?v=5u7n4jWx5r0

            */

            Dictionary<int, List<int>> store = new Dictionary<int, List<int>>();
            VerticalOrderHelper(root, store);
            List<List<int>> result = store.OrderBy(s => s.Key).Select(v => v.Value).ToList();
            return result;
        }

        public void VerticalOrderHelper(TreeNode root, Dictionary<int, List<int>> store)
        {
            if (root == null) return;
            int hd = 0;
            Queue<Tuple<TreeNode, int>> q = new Queue<Tuple<TreeNode, int>>();
            q.Enqueue(new Tuple<TreeNode, int>(root, hd));

            while (q.Count != 0)
            {
                Tuple<TreeNode, int> tuple = q.Dequeue();
                UpdateStore(tuple, store);

                TreeNode current = tuple.Item1;
                hd = tuple.Item2;

                if (current.Left != null)
                    q.Enqueue(new Tuple<TreeNode, int>(current.Left, hd - 1));

                if (current.Right != null)
                    q.Enqueue(new Tuple<TreeNode, int>(current.Right, hd + 1));
            }
        }

        private void InOrderRecursiveHelper(TreeNode root, List<int> results)
        {
            if (root == null) return;
            InOrderRecursiveHelper(root.Left, results);
            results.Add(root.Val);
            InOrderRecursiveHelper(root.Right, results);
        }

        private void LevelOrderIterativeHelper(TreeNode root, List<List<int>> results)
        {
            if (root == null) return;
            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int currentQueueCount = queue.Count;
                List<int> levelResults = new List<int>();
                for (int i = 0; i < currentQueueCount; i++)
                {
                    TreeNode current = queue.Dequeue();
                    levelResults.Add(current.Val);
                    if (current.Left != null) queue.Enqueue(current.Left);
                    if (current.Right != null) queue.Enqueue(current.Right);
                }

                results.Add(levelResults);
            }
        }

        private void PostOrderRecursiveHelper(TreeNode root, List<int> results)
        {
            if (root == null) return;
            PostOrderRecursiveHelper(root.Left, results);
            PostOrderRecursiveHelper(root.Right, results);
            results.Add(root.Val);
        }

        private void PreOrderRecursiveHelper(TreeNode root, List<int> results)
        {
            if (root == null) return;
            results.Add(root.Val);
            PreOrderRecursiveHelper(root.Left, results);
            PreOrderRecursiveHelper(root.Right, results);
        }
    }
}