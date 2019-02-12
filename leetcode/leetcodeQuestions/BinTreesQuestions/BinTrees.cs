using System;
using System.Collections.Generic;

namespace BinTreesQuestions
{
    public class BinTrees
    {
        public int Answer { get; set; }

        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();
            List<int> res = new List<int>();

            if (root.left != null) res.AddRange(InorderTraversal(root.left));
            res.Add(root.val);
            if (root.right != null) res.AddRange(InorderTraversal(root.right));
            return res;
        }

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return IsSymmetric(root.left, root.right);
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null) return res;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                int qCount = q.Count;
                List<int> levelResult = new List<int>();
                for (int i = 0; i < qCount; i++)
                {
                    TreeNode n = q.Dequeue();
                    levelResult.Add(n.val);
                    if (n.left != null) q.Enqueue(n.left);
                    if (n.right != null) q.Enqueue(n.right);
                }

                res.Add(levelResult);
            }

            return res;
        }

        public int MaxDepth(TreeNode root)
        {
            MaximumDepth(root, 1);
            return Answer;
        }

        public void MaximumDepth(TreeNode root, int depth)
        {
            if (root == null)
            {
                return;
            }
            if (root.left == null && root.right == null)
            {
                Answer = Math.Max(Answer, depth);
            }
            MaximumDepth(root.left, depth + 1);
            MaximumDepth(root.right, depth + 1);
        }

        public IList<int> PostorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();
            List<int> res = new List<int>();

            if (root.left != null) res.AddRange(PostorderTraversal(root.left));
            if (root.right != null) res.AddRange(PostorderTraversal(root.right));
            res.Add(root.val);

            return res;
        }

        public List<int> PreOrderSearch(TreeNode root, List<int> nodesList)
        {
            if (root == null) return new List<int>();
            nodesList.Add(root.val);
            if (root.left != null) PreOrderSearch(root.left, nodesList);
            if (root.right != null) PreOrderSearch(root.right, nodesList);

            return nodesList;
        }

        public List<int> PreOrderSearchRight(TreeNode root, List<int> nodesList)
        {
            if (root == null) return new List<int>();
            nodesList.Add(root.val);
            if (root.right != null) PreOrderSearch(root.right, nodesList);
            if (root.left != null) PreOrderSearch(root.left, nodesList);

            return nodesList;
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();
            List<int> res = new List<int>
            {
                root.val
            };
            if (root.left != null) res.AddRange(PreorderTraversal(root.left));
            if (root.right != null) res.AddRange(PreorderTraversal(root.right));

            return res;
        }

        private bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;

            if (left.val == right.val)
            {
                return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
            }
            return false;
        }
    }
}