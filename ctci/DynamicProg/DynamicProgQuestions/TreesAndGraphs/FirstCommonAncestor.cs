using System.Collections.Generic;
using System.Linq;

namespace TreesAndGraphs
{
    public class FirstCommonAncestor
    {   /*
        4.8 First Common Ancestor: Design an algorithm and write code to find the first common ancestor
           of two nodes in a binary tree. Avoid storing additional nodes in a data structure. NOTE: This is not
           necessarily a binary search tree.
           Hints: # 10, #16, #28, #36, #46, #70, #80, #96
        */

        public TreeNode FirstCommonAnc(TreeNode n, int x, int y)
        {
            if (n == null) return null;

            List<TreeNode> xRes = InOrderTraversal(n, x);
            List<TreeNode> yRes = InOrderTraversal(n, y);
            IEnumerable<TreeNode> res = xRes.Intersect(yRes);
            return res.FirstOrDefault();
        }

        public List<TreeNode> InOrderTraversal(TreeNode n, int val)
        {
            if (n == null) return new List<TreeNode>();

            List<TreeNode> list = new List<TreeNode>();

            if (n.Val == val)
            {
                list.Add(n);
                return list;
            }

            if (n.Left != null) list.AddRange(InOrderTraversal(n.Left, val));
            list.Add(n);
            if (n.Right != null) list.AddRange(InOrderTraversal(n.Right, val));

            return list;
        }
    }
}