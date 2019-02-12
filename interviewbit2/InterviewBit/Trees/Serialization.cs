using System.Collections.Generic;

namespace Trees
{
    public class Serialization
    {
        /*
         * https://www.geeksforgeeks.org/serialize-deserialize-binary-tree/
         *
         * Binary Tree
         * https://www.youtube.com/watch?v=jwzo6IsMAFQ&t=12s
         *
         * Binary Search Tree
         * https://www.youtube.com/watch?v=H594EV9OuDI
         */

        public void SerialBinaryTreeToArray(TreeNode root, List<int> output)
        {
            if (root == null)
            {
                /*this is just regular preorder DFS BUT each time you hit a null node,
                 you add -1 to the array
                 */
                output.Add(-1);
                return;
            }

            output.Add(root.Val);
            SerialBinaryTreeToArray(root.Left, output);
            SerialBinaryTreeToArray(root.Right, output);
        }

        public void SerializeBinarySearchTreeToArray(TreeNode root, List<int> output)
        {
            // this is just regular preorder DFS
            if (root == null) return;

            output.Add(root.Val);
            SerializeBinarySearchTreeToArray(root.Left, output);
            SerializeBinarySearchTreeToArray(root.Right, output);
        }

        public string SerializeToString(TreeNode root)
        {
            List<string> list = new List<string>();
            SerializeToStringHelper(root, list);
            string result = string.Join(",", list);
            return result;
        }

        public void SerializeToStringHelper(TreeNode root, List<string> list)
        {
            if (root == null)
            {
                // leaf
                list.Add("null");
                return;
            }

            // preorder
            list.Add(root.Val.ToString());
            SerializeToStringHelper(root.Left, list);
            SerializeToStringHelper(root.Right, list);
        }
    }
}