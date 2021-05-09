namespace lc_2021_01
{
    public class BinarySearchTreeFramework
    {
        private void BstGeneralized(TreeNode root, int target)
        {
            if ((int)root.Value == target)
            { }
            // When you find the target, your manipulation should be written here

            if ((int)root.Value < target)
                BstGeneralized(root.Right, target);

            if ((int)root.Value > target)
                BstGeneralized(root.Left, target);
        }

        public bool IsInBst(TreeNode root, int target)
        {
            if (root == null) return false;
            if ((int)root.Value == target) return true;
            if ((int)root.Value < target) return IsInBst(root.Right, target);
            if ((int)root.Value > target) return IsInBst(root.Left, target);
            return false;
        }

        public bool IsValidBst(TreeNode root)
        {
            return IsValidBstHelper(root, null, null);
        }

        private bool IsValidBstHelper(TreeNode root, TreeNode min, TreeNode max)
        {
            if (root == null) return true;
            if (min != null && (int)root.Value <= (int)min.Value) return false;
            if (max != null && (int)root.Value >= (int)max.Value) return false;
            return IsValidBstHelper(root.Left, min, root) && IsValidBstHelper(root.Right, root, max);
        }
    }
}