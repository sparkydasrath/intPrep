using System;

namespace BinarySearchTree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TreeNode root = new TreeNode(10)
            {
                Left = new TreeNode(5)
                {
                    Left = new TreeNode(2),
                    Right = new TreeNode(7)
                },
                Right = new TreeNode(5)
                // Right = new TreeNode(15)
                {
                    Left = new TreeNode(12),
                    Right = new TreeNode(17)
                }
            };

            ValidateBst v = new ValidateBst();
            bool result = v.ISValid(root);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}