using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BstOperations
    {
        public TreeNode Delete(TreeNode root, int key)
        {
            // return root if null
            if (root == null) return root;

            // deal with case if the root node is the target
            if (root.Val == key)
            {
                // replace root with root->right if root->left is null
                if (root.Left == null)
                {
                    return root.Right;
                }

                // replace root with root->left if root->right is null
                if (root.Right == null)
                {
                    return root.Left;
                }

                // replace root with its successor if root has two children
                TreeNode p = FindSuccessor(root);
                root.Val = p.Val;
                root.Right = Delete(root.Right, p.Val);
                return root;
            }

            if (key > root.Val)
            {
                // find target in right subtree if root->val < key
                root.Left = Delete(root.Left, key);
            }
            else
            {
                // find target in left subtree if root->val > key
                root.Right = Delete(root.Right, key);
            }
            return root;
        }

        public TreeNode Insert(TreeNode root, int val)
        {
            /*
             * https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/141/basic-operations-in-a-bst/1003/
             */
            if (root == null)
            {
                // return a new node if root is null
                return new TreeNode(val);
            }
            if (root.Val < val)
            {
                // insert to the right subtree if val > root->val
                root.Right = Insert(root.Right, val);
            }
            else
            {
                // insert to the left subtree if val <= root->val
                root.Left = Insert(root.Left, val);
            }

            return root;
        }

        public TreeNode InsertWithCount(TreeNode root, int val)
        {
            /*
             * https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/141/basic-operations-in-a-bst/1003/
             */
            if (root == null)
            {
                // return a new node if root is null
                return new TreeNode(val, 1);
            }
            if (root.Val < val)
            {
                // insert to the right subtree if val > root->val
                root.Right = InsertWithCount(root.Right, val);
            }
            else
            {
                // insert to the left subtree if val <= root->val
                root.Left = InsertWithCount(root.Left, val);
            }

            root.Count++;
            return root;
        }

        public TreeNode Search(TreeNode root, int val)
        {
            /*
          *https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/141/basic-operations-in-a-bst/1000/
          *
          */
            if (root == null) return null;
            if (val == root.Val) return root;
            if (val < root.Val) return Search(root.Left, val);
            return Search(root.Right, val);
        }

        public TreeNode SearchAndStore(TreeNode root, int val, Dictionary<int, int> store)
        {
            /*
          *https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/141/basic-operations-in-a-bst/1000/
          *
          */
            if (root == null) return null;
            if (val == root.Val)
            {
                if (!store.ContainsKey(val)) store[val] = 1;
                else
                {
                    int count = store[val];
                    count += 1;
                    store[val] = count;
                }

                return root;
            }

            if (val < root.Val)
            {
                if (!store.ContainsKey(root.Val)) store[root.Val] = 1;
                else
                {
                    int count = store[root.Val];
                    count += 1;
                    store[root.Val] = count;
                }
                return SearchAndStore(root.Left, val, store);
            }
            else
            {
                if (!store.ContainsKey(root.Val)) store[root.Val] = 1;
                else
                {
                    int count = store[root.Val];
                    count += 1;
                    store[root.Val] = count;
                }
                return SearchAndStore(root.Right, val, store);
            }
        }

        private TreeNode FindSuccessor(TreeNode root)
        {
            /**
            * findSuccessor - Helper function for finding successor
            * In BST, successor of root is the leftmost child in root's right subtree
            */
            TreeNode cur = root.Right;
            while (cur?.Left != null)
            {
                cur = cur.Left;
            }
            return cur;
        }
    }
}