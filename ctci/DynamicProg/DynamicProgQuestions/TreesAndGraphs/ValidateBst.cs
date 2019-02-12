namespace TreesAndGraphs
{
    public class ValidateBst
    {
        public bool ValidateBinarySearchTree(TreeNode n, int min, int max)
        {
            // bool left = false; bool right = false; if (n.Val >= min && n.Val <= max & n.Left !=
            // null) { left = ValidateBinarySearchTree(n.Left, min, n.Val); }
            //
            // if (n.Val > min && n.Val < max & n.Right != null) { right =
            // ValidateBinarySearchTree(n.Right, n.Val, max); }

            if (n == null) return true;
            if (n.Val > min &&
                n.Val < max &&
                ValidateBinarySearchTree(n.Left, min, n.Val) &&
                ValidateBinarySearchTree(n.Right, n.Val, max))
            {
                return true;
            }

            return false;
        }

        public bool ValidateBinarySearchTree2(TreeNode n, int min, int max)
        {
            if (n == null) return true;
            if (n.Val <= min || n.Val > max) return false;
            return
                ValidateBinarySearchTree(n.Left, min, n.Val) &&
                ValidateBinarySearchTree(n.Right, n.Val, max);
        }
    }
}